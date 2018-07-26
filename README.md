# Stock-Money-Maker
a helper application for viewing K-line of stock market in Taiwan
![程式介面](https://i.imgur.com/rv2crO9.png)
---
## 目前功能
-自動讀取來自[台灣股市資訊網](https://goodinfo.tw/StockInfo/index.asp)的股價資訊
-可以選擇任一類股
-客製化分析:
> -20日移動均線+排除5%極端值

## 使用工具
-使用者介面：[Microsoft .NET Windows Form](https://zh.wikipedia.org/wiki/Windows_Forms)
-爬蟲相關
> 解析HTML工具(C#)：[HTML Agility Pack](http://html-agility-pack.net/) 
> 模擬瀏覽器行為：[Selenium](https://www.seleniumhq.org/)
---
## 尚未修正項目
-會不必要的開啟瀏覽器
-滑鼠移動到非股價之資料點也會給出提示
-有時候無法成功載入一年的資訊，只能三個月
-繪圖前移動到圖表會有黑線
-第一次查詢後再切換其他股票會shutdown
-空的資料點仍會佔據空間

## 追加功能
-超過涵蓋範圍將資料點顯示為灰色
-改由其他股市資訊網站，將資料擴增為5年以上
-其他分析項目
