#分别验证在pycharm中和cmd中下述的打印结果
s=u'林' #当程序执行时，'林'会被以unicode形式保存新的内存空间中
print s

#s指向的是unicode，因而可以编码成任意格式，都不会报encode错误
s1=s.encode('utf-8')
s2=s.encode('gbk')
print s1 #打印正常否？
print s2 #打印正常否


print repr(s) #u'\u6797'
print repr(s1) #'\xe6\x9e\x97' 编码一个汉字utf-8用3Bytes
print repr(s2) #'\xc1\xd6' 编码一个汉字gbk用2Bytes

print type(s) #<type 'unicode'>
print type(s1) #<type 'str'>
print type(s2) #<type 'str'>