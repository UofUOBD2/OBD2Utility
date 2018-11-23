using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBD2_Utility
{


    class GraphConfig
    {
        // Items needed for graphing
        public bool graphConfigured = false;
        public bool takingDown;
        public bool buildingUp;
        public bool graphUpdateDone;
        public bool firstTimeGraphing;

        public int incramentValue = 5;
        public int yMultiplier;
        public int yPixelScale = 1;
        public int OGgraphDisplayWidth;
        public int zoomLevel = 0;
        public int MAXZOOMLEVEL = 30;

        public List<dataPoint> decodedData;
        public List<String> firstDates;
        public List<String> secondDates;
        public List<List<Object>> google_results;
        public Point lastPoint;

        public List<Object> dataOptionsOne;
        public List<Object> dataOptionsTwo;
        public int dataOptionIndexOne;
        public int dataOptionIndexTwo;

        public Graph graphData;
        public Graph targetGraph;

        public PictureBox graphDisplay;

        public GraphConfig(int graphFlowPanelHeight, int graphFlowPanelWidth)
        {

            takingDown = false;
            buildingUp = false;
            graphUpdateDone = true;
            firstTimeGraphing = true;

            decodedData = new List<dataPoint>();
            firstDates = new List<string>();
            secondDates = new List<string>();
            google_results = new List<List<object>>();
            lastPoint = new Point();

            graphData = new Graph();
            targetGraph = new Graph();

            graphDisplay = new PictureBox();
            graphDisplay.Height = graphFlowPanelHeight - 20;
            graphDisplay.Width = graphFlowPanelWidth - 20;
            graphDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            graphDisplay.BackColor = System.Drawing.Color.Yellow;
            

            dataOptionsOne = new List<Object>();
            dataOptionsTwo = new List<Object>();
            dataOptionIndexOne = 0;
            dataOptionIndexTwo = 0;

            OGgraphDisplayWidth = graphDisplay.Width;

        }
    }
}
