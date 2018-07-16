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
            webClient = new WebClient();
            webClient.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:61.0)" +
                " Gecko/20100101");
            Stream stream = webClient.OpenRead(
                "https://goodinfo.tw/StockInfo/StockList.asp");
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(stream, encode);
            String str = streamReader.ReadToEnd();

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_main_info_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

            textBox1.Text += URL;

            // Go to that URL and get HTML
            Stream stream = webClient.OpenRead(URL);
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(stream, encode);
            String str = streamReader.ReadToEnd();
            textBox1.Text += str;
            HAP_doc.LoadHtml(str);

            // iterate nodes and load it to comboBox2
            String xPath2 = "/html/body";
            var nodes = HAP_doc.DocumentNode.SelectNodes(xPath2);

            //textBox1.Text += (nodes.Count.ToString() + Environment.NewLine);
        }
    }
}
