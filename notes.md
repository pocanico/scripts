# 信息搜集
## 发现存活主机
### 二层发现
数据链路层，对arp协议抓包（路由器一般不转发arp协议包）
速度快、可靠
不可路由
```
arping
nmap -sn 192.168.0.0/24 
nmap -iL addr.txt -sn 
netdiscover -i eth0 -r 192.168.0.0/24
netdiscover -l addr.txt
netdicover -p
```

### 三层发现
可路由
速度比二层慢，经常被边界防火墙过滤
```
ping 192.168.0.1 -c 1 
traceroute/ping -R(ping -R 返回外网口地址，traceroute 返回内网口地址)
```

### 四层发现--通过识别IP是否在线
可路由且结果可靠
不太可能被防火墙过滤
甚至可以发现所有端口都被过滤的主机

基于状态过滤的防火墙可能过滤扫描
全端口扫描速度慢

#### 基于TCP
直接发ack包


## 端口扫描
### UDP端口扫描
scapy：a = sr1(IP(dst=ip)/UDP(dport=port),timout=5,verbose=0)
nmap -sU 192.168.43.20
nmap -iL iplist.txt -sU -p 1-200
### TCP端口扫描
#### 全连接扫描
scapy
nmap -sT 192.168.43.32 -p1-100
dmitry -p 192.168.43.32
nc -nv -w 1 -z 192.168.43.32 1-100
#### 隐蔽扫描
scapy
nmap -sS 10.5.125.127  -p 1-100
hping3 10.25.125.127 --scan 1-100 -S

## 服务扫描
### banner捕获
nc
socket
dmitry -pb 192.168.43.32
nmap -sT 192.168.43.32 -p 22 --script=banner.nse
amap -B 192.168.43.32 1-100

### SNMP分析
服务端端口161；客户端端口162；
SNMP的身份验证信息:community；默认值为public(只读权限),如未修改public字符串，则任何人都可以通过SNMP客户端或扫描工具利用public这个community去连接目标设备，获取详细配置信息；如果值为private(可写权限)，则可以通过SNMP对目标服务器的配置信息进行修改；还有一些非标准的community特征字符，如admin、manager;可以构造一个community特征字段字典扫描；
国际化标准组织制定了一个通用的SNMP管理信息库(MIB库)；MIB库里存储查询指令的编号；客户端基于编号查询服务端信息，如CPU占用信息，内存，网络进程信息；不同设备厂商开发了MIB库，需要在客户端导入专有MIB库(思科的),发送特有编号给服务器查到厂家专有设备的信息；

onesixtyone -c dict.txt -i hosts -o my.log -w 100
snmpwalk 192.168.43.208 -c public -v 2c
snmap-check 192.168.43.208 -c public

## 服务识别
nmap -sV 192.168.43.32 -P1-100
amap 192.168.43.32 1-100  不如nmap精确；-q:不报告closed的端口，不打印未识别的端口；-b：以ascii格式输出

## 操作系统识别
scapy+ttl
nmap -o 192.168.43.32
xprobe2 192.168.43.32（不如nmap准确）
p0f

## SMB扫描
nmap -v 192.168.43.208 -p139,445 --open
nmap 192.168.43.208 -p139,445 --script=smb-os-discovery.nse
nmap -v -p139,445 --script=smb-check-vulns --script-argvs=unsafe=1 192.168.43.208 -Pn
nbtscan -r 192.168.43.0/24
enum4linux -a 192.168.43.208