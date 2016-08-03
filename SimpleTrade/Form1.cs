using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace SimpleTrade
{
    public partial class Form1 : Form
    {
        CMarketPlace theMarket = new CMarketPlace();
        CMainTicker theTicker = new CMainTicker();
        CProducer theProducer;
        CConsumer theConsumer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            theTicker.tickTheseObjects.Add(theMarket);
            theProducer = new CProducer(new TimeSpan(30,0,0,0), theMarket, "test", new TimeSpan(30,1,0,0), new TimeSpan(2,0,0,0), 150);
            theTicker.tickTheseObjects.Add(theProducer);

            theConsumer = new CConsumer(new TimeSpan(30), theMarket);
            theTicker.tickTheseObjects.Add(theConsumer);
            theProducer.registerForDataCollection("totalIncome");
            CTickerObject.hideField(typeof(CProducer), "price");
            

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            theTicker.tick();
            tbGameTime.Text = CMainTicker.gameDateTime.ToLongDateString();

            tbBuyPrice.Text = theConsumer.offeredPrice().ToString();
            tbSellPrice.Text = theMarket.getLowestPrice().ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnFaster_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval / 2;
        }

        private void btnSlower_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval * 2;
        }

        private void cbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManual.Checked)
            {
                timer1.Enabled = false;
            }
            else timer1.Enabled = true;
        }

        private void btTick_Click(object sender, EventArgs e)
        {
            theTicker.tick();
            tbGameTime.Text = CMainTicker.gameDateTime.ToLongDateString();

            tbBuyPrice.Text = theConsumer.offeredPrice().ToString();
            tbSellPrice.Text = theMarket.getLowestPrice().ToString();
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.DataSource = theProducer.getCollectedData("totalIncome");
            chart1.Series[0].XValueMember = "thisDate";
            chart1.Series[0].YValueMembers = "value";
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.DataBind();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            ListViewItem[] lvArr = theProducer.getItemDataAsListViewItems();
            listView1.Items.Clear();
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("FieldName");
                listView1.Columns.Add("Value");
                listView1.Columns.Add("DataCollection");
            }
            listView1.Items.AddRange(lvArr);

        }
    }
}
