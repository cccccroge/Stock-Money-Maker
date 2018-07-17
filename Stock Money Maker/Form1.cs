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

            // iterate nodes and load data to candlestick chart
            String xPath2 = "//div[@id='divPriceDetail']" +
                "/table[@class='solid_1_padding_3_0_tbl']" +
                "/tr";
            var nodes2 = HAP_doc.DocumentNode.SelectNodes(xPath2);

            chart1.Series[0].Points.Clear();
            foreach (var node in nodes2)
            {
                String date = node.SelectSingleNode("./td[1]/nobr").InnerText;
                String highStr = node.SelectSingleNode("./td[3]/nobr").InnerText;
                float high = Convert.ToSingle(highStr);
                String lowStr = node.SelectSingleNode("./td[4]/nobr").InnerText;
                float low = Convert.ToSingle(lowStr);
                String openStr = node.SelectSingleNode("./td[2]/nobr").InnerText;
                float open = Convert.ToSingle(openStr);
                String closeStr = node.SelectSingleNode("./td[5]/nobr").InnerText;
                float close = Convert.ToSingle(closeStr);

                chart1.Series[0].Points.AddXY(date, low, high, open, close);
            }

            //textBox1.Text += nodes2.Count.ToString();
        }
    }
}
