获取当前路径
获取版本
获得当前目录及子目录所有文件，且显示这些文件的路径
ls -Recurse | select fullname

#输出D:\下所有文件的文件名
Get-ChildItem D:\ | ForEach-Object -Process{
if($_ -is [System.IO.FileInfo])
{
Write-Host($_.name);
}
}
#列出今天创建的文件
Get-ChildItem D:\ | ForEach-Object -Process{
if($_ -is [System.IO.FileInfo] -and ($_.CreationTime -ge [System.DateTime]::Today))
{
Write-Host($_.name,$_.CreationTime);
}
}
#找出D盘根目录下的所有文件
Get-ChildItem d:\ | ?{$_.psiscontainer -eq $false}

如果要找文件夹，则把$false换成$true
--------------------- 
作者：saga_gallon 
来源：CSDN 
原文：https://blog.csdn.net/saga_gallon/article/details/51943724 
版权声明：本文为博主原创文章，转载请附上博文链接！