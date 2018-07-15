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
            // update stock info
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:61.0)" +
                " Gecko/20100101");
            Stream stream = webClient.OpenRead(
                "https://goodinfo.tw/StockInfo/StockList.asp");
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(stream, encode);
            String outputStr = streamReader.ReadToEnd();
            textBox1.Text = outputStr;
        }
    }
}
