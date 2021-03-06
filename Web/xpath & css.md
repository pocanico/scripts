# XPath 术语
## 节点（Node）
在 XPath 中，有七种类型的节点：元素、属性、文本、命名空间、处理指令、注释以及文档（根）节点。

## 基本值（或称原子值，Atomic value）
基本值是无父或无子的节点。 

## 项目（Item）
项目是基本值或者节点。

## 节点关系
父（Parent）
子（Children）
同胞（Sibling）
某节点的父、父的父，等等。 
后代（Descendant）

# XPath 语法
## XML 实例文档
```
<?xml version="1.0" encoding="ISO-8859-1"?>

<bookstore>

<book>
  <title lang="eng">Harry Potter</title>
  <price>29.99</price>
</book>

<book>
  <title lang="eng">Learning XML</title>
  <price>39.95</price>
</book>

</bookstore>
```
## 选取节点
![path](images\path.png)


![bookstore](images\bookstore.png)

## 谓语（Predicates）
谓语用来查找某个特定的节点或者包含某个指定的值的节点。
谓语被嵌在方括号中。
![Predicates](images\Predicates.png)

## 选取未知节点
![tongpei](images\tongpei.png)