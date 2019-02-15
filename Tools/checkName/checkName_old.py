# coding=utf-8
import os
import os.path
import re
import  array
import copy
import cmd
import pdb
import pickle
import tempfile
import subprocess
 
startSign='正在解析...'
startTemp=startSign.decode(encoding='utf-8')
new_start_sign=startTemp.encode('gbk')
print  new_start_sign
rootdir=os.getcwd()
# rootdir="G:\Apps"
# 新建文件夹  os.path.isdir(rootdir+'/logout') 判断指定目录下该文件夹是否存在
if not os.path.isdir(rootdir+'/logout'):
    os.makedirs(rootdir + '/logout')
logPath=os.path.abspath('logout')
# 新建存放信息 的txt文档
file_nonstandard_info=open(logPath+'/non_standard_filename.txt','w')
file_standard_info=open(logPath+'/standard_filename.txt','w')
file_nonstandard_dirname=open(logPath+'/non_standard_dirname.txt','w')
file_standard_dirname=open(logPath+'/standard_dirname.txt','w')
# 标准的符号库
num="0123456789"
word="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
sym="_"
symBank=[]   #符号库
for key in word:
    symBank.append(key)
for key in num:
    symBank.append(key)
for key in sym:
    symBank.append(key)
# parent --- 父目录 dirnames --- 所有文件夹名字 # filenames --- 所有文件的名字
for parent,dirnames,filenames in os.walk(rootdir):
    # 遍历所有的该路径下的所有文件名
    for dirname  in dirnames:
         totalDirList=[]
         for value in dirname:
            totalDirList.append(value)
         # 判断文件名是否规范
         if not set(totalDirList).issubset(symBank):
             file_nonstandard_dirname.write(os.path.abspath(dirname)+'\n')
         else:
             file_standard_dirname.write(os.path.abspath(dirname)+'\n')
 
         print  "dirname is:"+dirname
 
    for filename in filenames:
        # print "parent is:"+parent
        # print "filename is:"+filename
        totalList=[];
        tempFilename = filename[0:filename.index('.')]
        filepath = os.path.abspath(filename)
        for value in tempFilename:
            totalList.append(value)
        if not set(totalList).issubset(symBank):
            file_nonstandard_info.write(filepath + '\n')
        else:
            file_standard_info.write(filepath+'\n')
endSign= '解析完成 结果存放在'+os.getcwd()+'\logout.txt...'
endTemp=endSign.decode(encoding='utf-8')
new_end_sign=endTemp.encode('gbk')
print  new_end_sign
os.system('wait')
# input()
 
# print  'lzk.exe'
# str='lfzk.exe'
# print str.index('.')
# print str[0:str.index('.')]
 
            # print  "the full name of the file is:"+os.path.join(parent,filename)
