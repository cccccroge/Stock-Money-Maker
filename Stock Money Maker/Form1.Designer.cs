﻿using System.Net;

namespace Stock_Money_Maker
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_instruction = new System.Windows.Forms.Label();
            this.label_main_info = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.myGroupBox1 = new Stock_Money_Maker.myGroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.myGroupBox2 = new Stock_Money_Maker.myGroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.myGroupBox1.SuspendLayout();
            this.myGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label_instruction);
            this.panel1.Controls.Add(this.label_main_info);
            this.panel1.Location = new System.Drawing.Point(57, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 86);
            this.panel1.TabIndex = 0;
            // 
            // label_instruction
            // 
            this.label_instruction.AutoSize = true;
            this.label_instruction.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_instruction.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_instruction.Location = new System.Drawing.Point(27, 46);
            this.label_instruction.Name = "label_instruction";
            this.label_instruction.Size = new System.Drawing.Size(253, 30);
            this.label_instruction.TabIndex = 2;
            this.label_instruction.Text = "請選擇您的股票代號。";
            // 
            // label_main_info
            // 
            this.label_main_info.AutoSize = true;
            this.label_main_info.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_main_info.Location = new System.Drawing.Point(25, 6);
            this.label_main_info.Name = "label_main_info";
            this.label_main_info.Size = new System.Drawing.Size(177, 40);
            this.label_main_info.TabIndex = 1;
            this.label_main_info.Text = "歡迎回來！";
            // 
            // splitContainer1
            // 
            this.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::Stock_Money_Maker.Properties.Resources.top_bar;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(787, 714);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.myGroupBox1);
            this.flowLayoutPanel1.Controls.Add(this.myGroupBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(57, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(674, 569);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.myGroupBox1.Controls.Add(this.comboBox2);
            this.myGroupBox1.Controls.Add(this.comboBox1);
            this.myGroupBox1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.myGroupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.myGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(671, 84);
            this.myGroupBox1.TabIndex = 1;
            this.myGroupBox1.TabStop = false;
            this.myGroupBox1.Text = "選擇類股 / 代號";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(234, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 35);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 35);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // myGroupBox2
            // 
            this.myGroupBox2.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.myGroupBox2.Controls.Add(this.textBox1);
            this.myGroupBox2.Controls.Add(this.chart1);
            this.myGroupBox2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.myGroupBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.myGroupBox2.Location = new System.Drawing.Point(3, 93);
            this.myGroupBox2.Name = "myGroupBox2";
            this.myGroupBox2.Size = new System.Drawing.Size(671, 447);
            this.myGroupBox2.TabIndex = 2;
            this.myGroupBox2.TabStop = false;
            this.myGroupBox2.Text = "20日K線(涵蓋率95%)";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(20, 402);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(628, 28);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chart1
            // 
            this.chart1.BorderlineWidth = 0;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.LabelStyle.Format = "yyyy/MM/dd";
            chartArea2.AxisX.MajorGrid.LineWidth = 0;
            chartArea2.AxisY.InterlacedColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.IsInterlaced = true;
            chartArea2.AxisY.MajorGrid.LineWidth = 0;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorX.LineColor = System.Drawing.Color.DimGray;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(20, 34);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series4.CustomProperties = "PixelPointWidth=3, PriceDownColor=50\\, 255\\, 150, PointWidth=1, PriceUpColor=255\\" +
    ", 50\\, 100";
            series4.Legend = "Legend1";
            series4.MarkerBorderColor = System.Drawing.Color.Black;
            series4.Name = "股價";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValuesPerPoint = 4;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Color = System.Drawing.Color.LightSalmon;
            series5.CustomProperties = "IsXAxisQuantitative=True, EmptyPointValue=Zero";
            series5.Legend = "Legend1";
            series5.Name = "移動平均";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.BorderWidth = 0;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series6.Legend = "Legend1";
            series6.Name = "Series3";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.YValuesPerPoint = 2;
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(628, 373);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(784, 711);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "Form1";
            this.Text = "Stock Money Maker";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox2.ResumeLayout(false);
            this.myGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_instruction;
        private System.Windows.Forms.Label label_main_info;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private myGroupBox myGroupBox1;
        private myGroupBox myGroupBox2;
        private System.Windows.Forms.ComboBox comboBox2;

        private HtmlAgilityPack.HtmlDocument HAP_doc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

