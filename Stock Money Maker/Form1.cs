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
using System.Diagnostics;

namespace Stock_Money_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            // Parse HTML by using HTML Agility Pack
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(str);

            String xPath = "//div[@id='txtStockListMenu']/table[@id='" +
                "STOCK_LIST_ALL']/tr[position() > 1 and position() < 11]";

            try
            {
                var list = doc.DocumentNode.SelectNodes(xPath)
                    .ToList();
                int count = list.Count;
                textBox1.Text = count.ToString();
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            
        }
    }
}
