using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Stock_Money_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitCategories();
        }

        private void InitCategories()
        {
            // Get HTML string of stock list page at goodinfo.tw
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:61.0)" +
                " Gecko/20100101");
            Stream stream = webClient.OpenRead(
                "https://goodinfo.tw/StockInfo/StockList.asp");
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(stream, encode);
            String str = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();
            webClient.Dispose();


            // Get 9 rows of stock list by using HTML Agility Pack
            HAP_doc = new HtmlAgilityPack.HtmlDocument();
            HAP_doc.LoadHtml(str);
            String xPath = "//div[@id='txtStockListMenu']/table[@id='" +
                "STOCK_LIST_ALL']/tr[position() > 1 and position() < 11]";
            HtmlAgilityPack.HtmlNodeCollection nodes =
                HAP_doc.DocumentNode.SelectNodes(xPath);

            // Iterate nodes, get all categories and load it to combobox
            foreach (var node in nodes)
            {
                var nodes2 = node.SelectNodes("./td");
                foreach (var node2 in nodes2)
                {
                    var node3 = node2.SelectSingleNode("./a");
                    if (node3 != null)
                    {
                        comboBox1.Items.Add(node3.InnerText);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // find URL of provided category
            String id = comboBox1.SelectedItem.ToString();
            String xPath = "//div[@id='txtStockListMenu']/table[@id='" +
                "STOCK_LIST_ALL']/tr/td/a[text()='" + id + "']";
            String index = "https://goodinfo.tw/StockInfo/";
            String URL = index + HAP_doc.DocumentNode.SelectSingleNode(xPath)
                .Attributes["href"].Value;

            // Go to that URL and get HTML
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:61.0)" +
                " Gecko/20100101");
            Stream stream = webClient.OpenRead(URL);
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(stream, encode);
            String str = streamReader.ReadToEnd();
            HAP_doc.LoadHtml(str);

            stream.Close();
            streamReader.Close();
            webClient.Dispose();

            // iterate nodes and load it to comboBox2
            String xPath2 = "//div[@id='divStockList']" +
                "/table[@class='solid_1_padding_3_1_tbl']" +
                "/tr";
            var nodes = HAP_doc.DocumentNode.SelectNodes(xPath2);

            comboBox2.Items.Clear();
            foreach (var node in nodes)
            {
                String stkId = node.SelectSingleNode("./td[1]//a").InnerText;
                String stkName = node.SelectSingleNode("./td[2]//a").InnerText;

                comboBox2.Items.Add(stkId + " " + stkName);
            }
            GC.Collect();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change big label
            label_main_info.Text = "正在分析...";
            label_instruction.Text = comboBox2.SelectedItem.ToString();

            // find URL of provided id
            String xPath = "//div[@id='divStockList']" +
                "/table[@class='solid_1_padding_3_1_tbl']" +
                "/tr";
            var nodes = HAP_doc.DocumentNode.SelectNodes(xPath);

            String subURL = "";
            foreach (var node in nodes)
            {
                String specifiedStr = comboBox2.SelectedItem.ToString().Remove(4);
                if (node.SelectSingleNode("./td[1]//a").InnerText == specifiedStr)
                {
                    var node2 = node.SelectSingleNode("./td[17]//a");
                    subURL = node2.Attributes["href"].Value.ToString();
                    break;
                }
            }

            String index = "https://goodinfo.tw/StockInfo/";
            String URL = index + subURL;

            // Go to that URL and get one yeardata-HTML
            // (using Selenium)
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(URL);
            int count1 = driver.PageSource.Length;

            IWebElement select = driver.FindElement(By.Id("selK_ChartPeriod"));
            IList<IWebElement> options =
                select.FindElements(By.TagName("option"));
            foreach (var option in options)
            {
                if (option.Text == "一年")
                {
                    option.Click();
                    break;
                }
            }

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                int count2 = driver.PageSource.Length;
                if (count1 != count2)
                    break;
            }
            HAP_doc.LoadHtml(driver.PageSource);

            // iterate nodes and load data to candlestick chart
            String xPath2 = "//div[@id='divPriceDetail']" +
                "/table[@class='solid_1_padding_3_0_tbl']" +
                "/tbody/tr";
            var nodes2 = HAP_doc.DocumentNode.SelectNodes(xPath2);

            chart1.Series[0].Points.Clear();
            String prevM = "00";
            String curM = "00";
            int trackYear = DateTime.Now.Year;
            foreach (var node in nodes2)
            {
                String date = node.SelectSingleNode("./td[1]/nobr").InnerText;
                prevM = curM;
                curM = date.Remove(2);
                if (prevM == "01" && curM == "12")
                    trackYear -= 1;
                Object dateObj = Convert.ToDateTime(trackYear + "/" + date);

                String highStr = node.SelectSingleNode("./td[3]/nobr").InnerText;
                float high = Convert.ToSingle(highStr);
                String lowStr = node.SelectSingleNode("./td[4]/nobr").InnerText;
                float low = Convert.ToSingle(lowStr);
                String openStr = node.SelectSingleNode("./td[2]/nobr").InnerText;
                float open = Convert.ToSingle(openStr);
                String closeStr = node.SelectSingleNode("./td[5]/nobr").InnerText;
                float close = Convert.ToSingle(closeStr);

                chart1.Series[0].Points.AddXY(dateObj, low, high, open, close);
            }

            // calculate K-line of 20 day
            var points = chart1.Series[0].Points;
            double sum = 0;
            for (var i = points.Count - 1; i > points.Count - 21; i--)
            {
                double y = chart1.Series[0].Points[i].GetValueByName("Y4");
                sum += y;
            }

            for (var i = points.Count - 21; i >= 0; i--)
            {
                double currentY = chart1.Series[0].Points[i].GetValueByName("Y4");
                double removeY = chart1.Series[0].Points[i + 20].GetValueByName("Y4");
                sum = sum + currentY - removeY;

                double average = sum / 20;
                var date = chart1.Series[0].Points[i].XValue;
                var date2 = DateTime.FromOADate(date);

                chart1.Series[1].Points.AddXY(date2, average);
            }

            // adjust y-axis value boundary
            double maxPrice = chart1.Series[0].Points.FindMaxByValue("Y2")
                .GetValueByName("Y2");
            double maxAverge = chart1.Series[1].Points.FindMaxByValue("Y")
                .GetValueByName("Y");
            double max = (maxPrice >= maxAverge) ? maxPrice : maxAverge;
            chart1.ChartAreas[0].AxisY.Maximum = (int)(max + 2);

            double minPrice = chart1.Series[0].Points.FindMinByValue("Y1")
                .GetValueByName("Y1");
            double minAverge = chart1.Series[1].Points.FindMinByValue("Y")
                .GetValueByName("Y");
            double min = (minPrice <= minAverge) ? minPrice : minAverge;
            chart1.ChartAreas[0].AxisY.Minimum = (int)(min - 2);

            // TODO: draw an area from k-line which covers 0.95 of points

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            // clear info and hint
            if (textBox1.Text != "")
                textBox1.Text = "";
            chart1.ChartAreas[0].CursorX.Position = 0;
            chart1.ChartAreas[0].CursorY.Position = 0;

            // check if mouse is on point
            var pos = e.Location;
            var results = chart1.HitTest(pos.X, pos.Y, false, System.Windows
                .Forms.DataVisualization.Charting.ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == System.Windows
                .Forms.DataVisualization.Charting.ChartElementType.DataPoint)
                {
                    // Show data
                    var index = result.PointIndex;
                    var point = chart1.Series[0].Points[index];
                    textBox1.Text = DateTime.FromOADate(point.XValue)
                        .ToString("yyyy/MM/dd");
                    textBox1.Text += "          ";
                    textBox1.Text += "最低:" + Math.Round(point.YValues[0], 2)
                        .ToString() + " ";
                    textBox1.Text += "最高:" + Math.Round(point.YValues[1], 2)
                        .ToString() + " ";
                    textBox1.Text += "開盤:" + Math.Round(point.YValues[2], 2)
                        .ToString() + " ";
                    textBox1.Text += "收盤:" + Math.Round(point.YValues[3], 2)
                        .ToString();
                    textBox1.Refresh();

                    // Snap the cursor to point
                    chart1.ChartAreas[0].CursorX.Position = point.XValue;
                    chart1.ChartAreas[0].CursorY.Position = point.YValues[3];

                }
            }
        }
    }
}
