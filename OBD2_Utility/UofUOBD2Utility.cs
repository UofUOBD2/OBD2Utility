using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBD2_Utility
{
    public partial class UofUOBD2Utility : Form
    {

        List<List<Object>> data;
        List<dataPoint> decodedData;
        Graph graphData;

        public UofUOBD2Utility(List<List<Object>> incomingData)
        {
            InitializeComponent();
            graphDisplay.Paint += GraphDisplay_Paint;
            data = incomingData;
            decodedData = decodeData(data);
            
        }

        // CLICKING THE GRAPH OPTION
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setUpNextOption("graph");
            graphData = new Graph("bar", decodedData.Count, 10, 0, 10, decodedData);
            graphDisplay.Invalidate();
        }

        private List<dataPoint> decodeData(List<List<Object>> dataList)
        {
            int value;
            int i = 0;
             
            dataPoint dp;
            List<dataPoint> results = new List<dataPoint>();

            // THIS FUNCTION WILL NEED TO CHANGE ALOT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            foreach (List<object> data in dataList)
            {
                value = Convert.ToInt32((String)data[1]);
                dp = new dataPoint("Name", "Red", value, i);
                results.Add(dp);

                i++;
            }

            return results;
        }



        private void GraphDisplay_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect;

            foreach(dataPoint dp in graphData.dataEntries)
            {
                rect = new Rectangle((dp.xValue * 100) + 5, (545 - (dp.yValue * 4)), 50, (dp.yValue * 4));

                
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void UofUOBD2Utility_Load(object sender, EventArgs e)
        {
            setUpNextOption("start");
        }

        private void menuHome_Click(object sender, EventArgs e)
        {
            setUpNextOption("start");
        }


        private void setUpNextOption(String option)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name.Contains(option))
                {
                    c.Show();
                }
                else if (!(c.Name.Contains("menu")))
                {
                    c.Hide();
                }
            }
        }

    }
}
