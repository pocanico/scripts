# 创建一个Scrapy项目
```
scrapy startproject tutorial
```

# 第一个Spider
```
scrapy crawl quotes
```
Spiders是你需要定义的类，用它从网站中爬取信息。
Spiders必须是scrapy.Spider的子类和定义初始化的请求，选择如何在页面中跟踪链接，以及如何解析下载的页面内容以提取数据。

下面代码是我们第一次Spider代码。保存文件名为quotes_spider.py，同时保存在tutorial/spiders目录底下在你新建的Spiders项目中。

parse()方法通常解析响应，将剪贴数据提取为dicts，并寻找新的url来跟踪和创建来自它们的新请求(请求)。

```
import scrapy
 
 
class QuotesSpider(scrapy.Spider):
    name = "quotes" 
    def start_requests(self):
        urls = [
            'http://quotes.toscrape.com/page/1/',
            'http://quotes.toscrape.com/page/2/',
        ]
        for url in urls:
            yield scrapy.Request(url=url, callback=self.parse)
 
    def parse(self, response):
        page = response.url.split("/")[-2]
        filename = 'quotes-%s.html' % page
        with open(filename, 'wb') as f:
            f.write(response.body)
        self.log('Saved file %s' % filename)
```


