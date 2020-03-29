using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoMapDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LiveCharts.WinForms.GeoMap geoMap = new LiveCharts.WinForms.GeoMap();
            Dictionary<string, double> keyValues = new Dictionary<string, double> {
                {"US", 123776},
                {"IT", 92472 },
                {"ES", 73235 },
                {"DE", 57695 },
                {"FR", 37575},
                {"CN", 81439},
                {"IR", 35408 },
                {"UK", 17089 },
                {"CH",  14076},
                {"NL",  9762},
                {"KP", 9583},
                {"BE",  9143},
                {"AT", 8291 },
                {"TR", 7402 },
                {"CA",5655 },
                {"PT", 5170 },
                {"NO", 4037 },
                {"AU",3969 },
                {"BR", 3904 },
                {"IL", 3865 },
                {"SE", 3447 },
                {"IE", 2415 },
                {"MY", 2320 },
                {"DK", 2201 },
                {"CL",  1909},
                {"LU",  1831},
                {"EC",  1823},
                {"PL",  1717},
                {"JP",  1693},
                {"RU",  1534}
            };
            geoMap.HeatMap = keyValues;
            geoMap.Source = $"{Application.StartupPath}\\World.xml";

            this.Controls.Add(geoMap);
            geoMap.Dock = DockStyle.Fill;
        }
    }
}
