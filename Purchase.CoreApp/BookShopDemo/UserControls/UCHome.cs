using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopDemo.UserControls
{
    public partial class UCHome : UserControl
    {
        public UCHome()
        {
            InitializeComponent();
            LoadChart();
        }

        Random random = new Random();

        private void LoadChart()
        {
            for(int i=0;i<12;i++)
            {
                chart1.Series[0].Points.AddY(random.Next(0, 500));
            }

            pieReceived.ChartAreas.Clear();
            pieReceived.Titles.Clear();
            pieReceived.Series.Clear();
            pieReceived.Legends.Clear();

            pieReceived.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("chartArea"));
            pieReceived.ChartAreas["chartArea"].AxisX.IsMarginVisible = false;
            pieReceived.ChartAreas["chartArea"].Area3DStyle.Enable3D = false;

            pieReceived.Series.Add("data");
            pieReceived.Series["data"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;

            pieReceived.Series["data"].Points.AddY(random.Next(300));
            pieReceived.Series["data"].Points.AddY(random.Next(300));

            // piePaid
            piePaid.ChartAreas.Clear();
            piePaid.Titles.Clear();
            piePaid.Series.Clear();
            piePaid.Legends.Clear();

            piePaid.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("chartArea"));
            piePaid.ChartAreas["chartArea"].AxisX.IsMarginVisible = false;
            piePaid.ChartAreas["chartArea"].Area3DStyle.Enable3D = false;

            piePaid.Series.Add("data");
            piePaid.Series["data"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;

            piePaid.Series["data"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0d, random.Next(30))
            {
                Color = Color.White
            });
            piePaid.Series["data"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0d, random.Next(90)) { 
                Color = Color.Purple
            });

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            LoadChart();
        }
    }
}
