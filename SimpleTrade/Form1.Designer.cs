namespace SimpleTrade
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbGameTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuyPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSellPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tvProducer = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFaster = new System.Windows.Forms.Button();
            this.btnSlower = new System.Windows.Forms.Button();
            this.cbManual = new System.Windows.Forms.CheckBox();
            this.btTick = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbGameTime
            // 
            this.tbGameTime.Location = new System.Drawing.Point(35, 43);
            this.tbGameTime.Name = "tbGameTime";
            this.tbGameTime.Size = new System.Drawing.Size(100, 20);
            this.tbGameTime.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "GameTime";
            // 
            // tbBuyPrice
            // 
            this.tbBuyPrice.Location = new System.Drawing.Point(46, 164);
            this.tbBuyPrice.Name = "tbBuyPrice";
            this.tbBuyPrice.Size = new System.Drawing.Size(100, 20);
            this.tbBuyPrice.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buy Price";
            // 
            // tbSellPrice
            // 
            this.tbSellPrice.Location = new System.Drawing.Point(196, 167);
            this.tbSellPrice.Name = "tbSellPrice";
            this.tbSellPrice.Size = new System.Drawing.Size(100, 20);
            this.tbSellPrice.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sell Price";
            // 
            // tvProducer
            // 
            this.tvProducer.Location = new System.Drawing.Point(17, 267);
            this.tvProducer.Name = "tvProducer";
            this.tvProducer.Size = new System.Drawing.Size(232, 225);
            this.tvProducer.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 22);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnFaster
            // 
            this.btnFaster.Location = new System.Drawing.Point(35, 4);
            this.btnFaster.Name = "btnFaster";
            this.btnFaster.Size = new System.Drawing.Size(48, 23);
            this.btnFaster.TabIndex = 10;
            this.btnFaster.Text = "Faster";
            this.btnFaster.UseVisualStyleBackColor = true;
            this.btnFaster.Click += new System.EventHandler(this.btnFaster_Click);
            // 
            // btnSlower
            // 
            this.btnSlower.Location = new System.Drawing.Point(87, 4);
            this.btnSlower.Name = "btnSlower";
            this.btnSlower.Size = new System.Drawing.Size(48, 23);
            this.btnSlower.TabIndex = 10;
            this.btnSlower.Text = "Slower";
            this.btnSlower.UseVisualStyleBackColor = true;
            this.btnSlower.Click += new System.EventHandler(this.btnSlower_Click);
            // 
            // cbManual
            // 
            this.cbManual.AutoSize = true;
            this.cbManual.Location = new System.Drawing.Point(141, 4);
            this.cbManual.Name = "cbManual";
            this.cbManual.Size = new System.Drawing.Size(61, 17);
            this.cbManual.TabIndex = 11;
            this.cbManual.Text = "Manual";
            this.cbManual.UseVisualStyleBackColor = true;
            this.cbManual.CheckedChanged += new System.EventHandler(this.cbManual_CheckedChanged);
            // 
            // btTick
            // 
            this.btTick.Location = new System.Drawing.Point(141, 41);
            this.btTick.Name = "btTick";
            this.btTick.Size = new System.Drawing.Size(61, 22);
            this.btTick.TabIndex = 12;
            this.btTick.Text = "Tick";
            this.btTick.UseVisualStyleBackColor = true;
            this.btTick.Click += new System.EventHandler(this.btTick_Click);
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            this.chart1.Location = new System.Drawing.Point(483, 415);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.Name = "Series1";
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(276, 224);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(483, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Graph";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(481, 21);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(43, 20);
            this.btnData.TabIndex = 16;
            this.btnData.Text = "Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // listView1
            // 
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Location = new System.Drawing.Point(480, 56);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(278, 303);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 651);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btTick);
            this.Controls.Add(this.cbManual);
            this.Controls.Add(this.btnSlower);
            this.Controls.Add(this.btnFaster);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvProducer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSellPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBuyPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGameTime);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbGameTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuyPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSellPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvProducer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFaster;
        private System.Windows.Forms.Button btnSlower;
        private System.Windows.Forms.CheckBox cbManual;
        private System.Windows.Forms.Button btTick;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.ListView listView1;
    }
}

