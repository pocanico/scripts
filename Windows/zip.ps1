$EmlPath="C:\Users\LY\Desktop\test" #文件所在的文件夹
#$EmlPath= Split-Path -Parent $MyInvocation.MyCommand.Definition
#$ZipPath="C:\Users\LY\Desktop\" + (Get-Date).ToString('yyyy-MM-dd hh-mm-ss') + ".zip" #最终输出的Zip文件，以时间动态生成。
# $a = (Split-Path -Parent $MyInvocation.MyCommand.Definition).ToString() + "\"
$a = Convert-Path(Split-Path -Parent $MyInvocation.MyCommand.Definition) + "\"
$ZipPath=$a + (Get-Date).ToString('yyyy-MM-dd hh-mm-ss') + ".zip" #最终输出的Zip文件，以时间动态生成。
$zipPath
#加载依赖
[System.Reflection.Assembly]::Load("WindowsBase,Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")

#删除已有的压缩包
if (Test-Path($ZipPath))
{
	Remove-Item $ZipPath
}

#获取文件集合
$Di=New-Object System.IO.DirectoryInfo($EmlPath);
$files = $Di.GetFiles()
$files
if($files.Count -eq 0)
{
	exit
}

#打开压缩包
$pkg=[System.IO.Packaging.ZipPackage]::Open($ZipPath,[System.IO.FileMode]"OpenOrCreate", [System.IO.FileAccess]"ReadWrite")

#加入文件到压缩包
ForEach ($file In $files)
{
	$uriString="/" +$file.Name
	$partName=New-Object System.Uri($uriString, [System.UriKind]"Relative")
	$pkgPart=$pkg.CreatePart($partName, "application/zip",[System.IO.Packaging.CompressionOption]"Maximum")
	$bytes=[System.IO.File]::ReadAllBytes($file.FullName)
	$stream=$pkgPart.GetStream()
	$stream.Seek(0, [System.IO.SeekOrigin]"Begin");
	$stream.Write($bytes, 0, $bytes.Length)
	$stream.Close()
	#Remove-Item $file.FullName
}

#关闭压缩包
$pkg.Close()