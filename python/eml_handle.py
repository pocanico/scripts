
import email

fp = open(r"F:\GitHub\scripts\python\1.eml", "r")
msg = email.message_from_file(fp) # 直接文件创建message对象，这个时候也会做初步的解码
print msg
subject = msg.get("Subject").encode('gb2312') # 取信件头里的subject,　也就是主题
# 下面的三行代码只是为了解码象=?gbk?Q?=CF=E0=C6=AC?=这样的subject
h = email.Header.Header(subject)
dh = email.Header.decode_header(h)
subject = dh[0][0]
print "subject:", subject
print "from: ", email.utils.parseaddr(msg.get("from"))[1] # 取from
print "to: ", email.utils.parseaddr(msg.get("to"))[1] # 取to

fp.close()