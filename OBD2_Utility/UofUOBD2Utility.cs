﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace OBD2_Utility
{
    public partial class UofUOBD2Utility : Form
    {

        bool graphOneSelected;
        bool graphTwoSelected;
        bool graphThreeSelected;

        bool graphing;
        bool dashboard;

        bool first_time = true;

        // Items needed for graphing
        bool graphConfigured = false;
        bool takingDown;
        bool buildingUp;
        bool graphUpdateDone;
        bool firstTimeGraphing;

        int incramentValue;
        int yMultiplier;
        int yPixelScale;
        int OGgraphDisplayWidth;
        int zoomLevel;
        int MAXZOOMLEVEL;

        bool graphOneLoaded = false;
        bool graphTwoLoaded = false;
        bool graphThreeLoaded = false;

        int currGraph = 0;

        // How quickly the graphs should animate;
        int updateScale = 10;

        List<dataPoint> decodedData;
        List<String> firstDates;
        List<String> secondDates;
        List<List<Object>> google_results;
        Point lastPoint;



        Graph graphData;
        Graph targetGraph;

        System.Windows.Forms.Timer time;
        PictureBox graphDisplay;

        GraphConfig graphOne;
        GraphConfig graphTwo;
        GraphConfig graphThree;


        // Initializes the form
        public UofUOBD2Utility()
        {
            InitializeComponent();

            graphOne = new GraphConfig(graphFlowPanel.Height, graphFlowPanel.Width);
            graphTwo = new GraphConfig(graphFlowPanel.Height, graphFlowPanel.Width);
            graphThree = new GraphConfig(graphFlowPanel.Height, graphFlowPanel.Width);

            graphDisplay = new PictureBox();
            graphFlowPanel.Controls.Add(graphDisplay);

            time = new System.Windows.Forms.Timer();
            time.Interval = 17;
            time.Tick += Time_Tick;
            time.Start();

            dashboard = true;
            graphing = false;

            tabControl1.TabPages.Remove(tabPage1);
            //tabControl1.TabPages.Remove(tabPage2);


            graphDisplay.Paint += GraphDisplay_Paint;
            dashBoard.Paint += DashBoard_Paint;

            OGgraphDisplayWidth = graphDisplay.Width;

            menuStatusBar.Enabled = false;

            this.graphFlowPanel.MouseWheel += GraphFlowPanel_MouseWheel;

            graphGraphButton.Enabled = false;

        }

        private void DashBoard_Paint(object sender, PaintEventArgs e)
        {
            drawDashBoard(e);
        }

        // OTHER CODE ------------------------------------------------------------------------------------------------------------------------------------------------
        private void setUpNextOption(String option)
        {

            foreach (Control c in this.Controls)
            {
                if (c.Name.Contains(option) || c.Name.Contains("tab"))
                {
                    c.Show();
                }
                else if (!(c.Name.Contains("menu")))
                {
                    c.Hide();
                }
            }
        }

        private void UofUOBD2Utility_Load(object sender, EventArgs e)
        {
            setUpNextOption("dashBoard");
            this.Focus();
        }

        private void menuHome_Click(object sender, EventArgs e)
        {
            if (!dashboard)
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                graphing = false;
                dashboard = true;
            }
            //setUpNextOption("dashBoard");
        }

        private void GraphFlowPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 120)
            {
                if (zoomLevel == 0)
                {
                    zoomLevel = 0;
                }
                else
                {
                    zoomLevel--;
                }

            }
            else
            {
                if (zoomLevel == MAXZOOMLEVEL)
                {
                    zoomLevel = MAXZOOMLEVEL;
                }
                else
                {
                    zoomLevel++;
                }
            }
        }

        private void graphFlowPanel_MouseHover(object sender, EventArgs e)
        {
            graphFlowPanel.Focus();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            updateGraph();
            graphDisplay.Invalidate();
        }

        private double MonthDifference(DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }
        //GRAPHING CODE -----------------------------------------------------------------------------------------------------------------------------------------------

        // 1. CLICKING THE GRAPH OPTION
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            

            if(!graphing)
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
                graphing = true;
                dashboard = false;
            } 
            
            

            if (!first_time)
            {
                if (graphThreeSelected)
                {
                    switchGraphs(3);
                }
                else if (graphTwoSelected)
                {
                    switchGraphs(2);
                }
            }
            else
            {
                first_time = false;
            }


            graphThreeSelected = false;
            graphTwoSelected = false;
            graphOneSelected = true;

            currGraph = 1;

            if(graphOneLoaded != true)
            {
                graphGraphButton.Enabled = false;
            } else
            {
                graphGraphButton.Enabled = true;
            }

            setUpNextOption("graph");

            List<String> xOptions = new List<string>(new String[] { "RPM", "SPEED", "OIL TEMP", "FUEL", "ODOMETER" });
            List<String> yOptions = new List<string>(new String[] { "Time" });

            

            graphConfigured = graphOne.graphConfigured;
            takingDown = graphOne.takingDown;
            buildingUp = graphOne.buildingUp;
            graphUpdateDone = graphOne.graphUpdateDone;
            firstTimeGraphing = graphOne.firstTimeGraphing;

            incramentValue = graphOne.incramentValue;
            yMultiplier = graphOne.yMultiplier;
            yPixelScale = graphOne.yPixelScale;
            OGgraphDisplayWidth = graphOne.OGgraphDisplayWidth;
            zoomLevel = graphOne.zoomLevel;
            MAXZOOMLEVEL = graphOne.MAXZOOMLEVEL;

            decodedData = graphOne.decodedData;
            firstDates = graphOne.firstDates;
            secondDates = graphOne.secondDates;
            google_results = graphOne.google_results;
            lastPoint = graphOne.lastPoint;

            graphData = graphOne.graphData;
            targetGraph = graphOne.targetGraph;

            graphFlowPanel.Controls.RemoveAt(0);
            graphDisplay = new PictureBox();
            graphDisplay = graphOne.graphDisplay;
            graphFlowPanel.Controls.Add(graphDisplay);
            graphDisplay.Paint += GraphDisplay_Paint;

            graphOption1Select.DataSource = graphOne.dataOptionsOne;
            graphOption2Select.DataSource = graphOne.dataOptionsTwo;


            try
            {
                if (graphOption1Select.SelectedIndex != -1)
                {
                    graphOption1Select.SelectedIndex = graphOne.dataOptionIndexOne;
                }
                if (graphOption2Select.SelectedIndex != -1)
                {
                    graphOption2Select.SelectedIndex = graphOne.dataOptionIndexTwo;
                }
            } catch
            {
                graphOption1Select.SelectedIndex = 0;
                graphOption2Select.SelectedIndex = 0;
            }
            

            


            graphDisplay.Invalidate();

            configureOptionBox(xOptions, yOptions);
        }

        private void menuGraph2_Click(object sender, EventArgs e)
        {
            if (!graphing)
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
                graphing = true;
                dashboard = false;
            }

            if (!first_time)
            {
                if (graphThreeSelected)
                {
                    switchGraphs(3);
                }
                else if (graphOneSelected)
                {
                    switchGraphs(1);
                }
            } else
            {
                first_time = false;
            }

            currGraph = 2;

            graphThreeSelected = false;
            graphTwoSelected = true;
            graphOneSelected = false;

            if (graphTwoLoaded != true)
            {
                graphGraphButton.Enabled = false;
            }
            else
            {
                graphGraphButton.Enabled = true;
            }

            setUpNextOption("graph");

            List<String> xOptions = new List<string>(new String[] { "RPM", "SPEED", "OIL TEMP", "FUEL", "ODOMETER"});
            List<String> yOptions = new List<string>(new String[] { "Time"});

            graphConfigured = graphTwo.graphConfigured;
            takingDown = graphTwo.takingDown;
            buildingUp = graphTwo.buildingUp;
            graphUpdateDone = graphTwo.graphUpdateDone;
            firstTimeGraphing = graphTwo.firstTimeGraphing;

            incramentValue = graphTwo.incramentValue;
            yMultiplier = graphTwo.yMultiplier;
            yPixelScale = graphTwo.yPixelScale;
            OGgraphDisplayWidth = graphTwo.OGgraphDisplayWidth;
            zoomLevel = graphTwo.zoomLevel;
            MAXZOOMLEVEL = graphTwo.MAXZOOMLEVEL;

            decodedData = graphTwo.decodedData;
            firstDates = graphTwo.firstDates;
            secondDates = graphTwo.secondDates;
            google_results = graphTwo.google_results;
            lastPoint = graphTwo.lastPoint;

            graphData = graphTwo.graphData;
            targetGraph = graphTwo.targetGraph;

            graphFlowPanel.Controls.RemoveAt(0);
            graphDisplay = new PictureBox();
            graphDisplay = graphTwo.graphDisplay;
            graphFlowPanel.Controls.Add(graphDisplay);
            graphDisplay.Paint += GraphDisplay_Paint;

            graphOption1Select.DataSource = graphTwo.dataOptionsOne;
            graphOption2Select.DataSource = graphTwo.dataOptionsTwo;

            try
            {
                if (graphOption1Select.SelectedIndex != -1)
                {
                    graphOption1Select.SelectedIndex = graphTwo.dataOptionIndexOne;
                }
                if (graphOption2Select.SelectedIndex != -1)
                {
                    graphOption2Select.SelectedIndex = graphTwo.dataOptionIndexTwo;
                }
            } catch
            {
                graphOption1Select.SelectedIndex = 0;
                graphOption2Select.SelectedIndex = 0;
            }


            configureOptionBox(xOptions, yOptions);
        }

        private void menuGraph3_Click(object sender, EventArgs e)
        {
            if (!graphing)
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
                graphing = true;
                dashboard = false;
            }

            if (!first_time)
            {
                if (graphOneSelected)
                {
                    switchGraphs(1);
                }
                else if (graphTwoSelected)
                {
                    switchGraphs(2);
                }
            }
            else
            {
                first_time = false;
            }

            currGraph = 3;
            graphThreeSelected = true;
            graphTwoSelected = false;
            graphOneSelected = false;

            if (graphThreeLoaded != true)
            {
                graphGraphButton.Enabled = false;
            }
            else
            {
                graphGraphButton.Enabled = true;
            }

            setUpNextOption("graph");

            List<String> xOptions = new List<string>(new String[] { "RPM", "SPEED", "OIL TEMP", "FUEL", "ODOMETER" });
            List<String> yOptions = new List<string>(new String[] { "Time" });

            graphConfigured = graphThree.graphConfigured;
            takingDown = graphThree.takingDown;
            buildingUp = graphThree.buildingUp;
            graphUpdateDone = graphThree.graphUpdateDone;
            firstTimeGraphing = graphThree.firstTimeGraphing;

            incramentValue = graphThree.incramentValue;
            yMultiplier = graphThree.yMultiplier;
            yPixelScale = graphThree.yPixelScale;
            OGgraphDisplayWidth = graphThree.OGgraphDisplayWidth;
            zoomLevel = graphThree.zoomLevel;
            MAXZOOMLEVEL = graphThree.MAXZOOMLEVEL;

            decodedData = graphThree.decodedData;
            firstDates = graphThree.firstDates;
            secondDates = graphThree.secondDates;
            google_results = graphThree.google_results;
            lastPoint = graphThree.lastPoint;

            graphData = graphThree.graphData;
            targetGraph = graphThree.targetGraph;

            graphFlowPanel.Controls.RemoveAt(0);
            graphDisplay = new PictureBox();
            graphDisplay = graphThree.graphDisplay;
            graphFlowPanel.Controls.Add(graphDisplay);
            graphDisplay.Paint += GraphDisplay_Paint;

            graphOption1Select.DataSource = graphThree.dataOptionsOne;
            graphOption2Select.DataSource = graphThree.dataOptionsTwo;

            try
            {
                if (graphOption1Select.SelectedIndex != -1)
                {
                    graphOption1Select.SelectedIndex = graphThree.dataOptionIndexOne;
                }
                if (graphOption2Select.SelectedIndex != -1)
                {
                    graphOption2Select.SelectedIndex = graphThree.dataOptionIndexTwo;
                }
            }
             catch
            {
                graphOption1Select.SelectedIndex = 0;
                graphOption2Select.SelectedIndex = 0;
            }


            configureOptionBox(xOptions, yOptions);

        }


        // 2. SET UP THE OPTION BOX FOR THE USER
        private void configureOptionBox(List<String> xOptions, List<String> yOptions)
        {

            graphXAxisSelect.DataSource = xOptions;
            graphYAxisSelect.DataSource = yOptions;
        }

        // 3. WHEN THE USER SELECTS THE "LOAD DATA" BUTTON (PULL DATA FROM GOOGLE)
        private void graphGenerateButton_Click(object sender, EventArgs e)
        {
            if(currGraph == 1)
            {
                graphOneLoaded = true;
            } else if (currGraph == 2)
            {
                graphTwoLoaded = true;
                
            } else if (currGraph == 3)
            {
                graphThreeLoaded = true;
            }

            graphGraphButton.Enabled = true;
            graphDisplay.Image = null;
            firstDates = new List<string>();
            secondDates.Clear();

            menuStatusBar.Text = "Pulling most recent data from the cloud...";

            // The spreadsheet we want to connect to
            String spreadsheetId = "1buoculiAlX_jz9m9Tt8Y9YYF6LPOPOLEGSVmbB5bSHU";

            // Creates the object we will use to interact with spreadsheets
            SheetsService service = GoogleConnect.connectToGoogle();

            // Reads current data from the google spread sheet
            google_results = GoogleConnect.retreiveData("A:H", (String)graphXAxisSelect.SelectedItem, spreadsheetId, service);

            menuStatusBar.Text = "Configuring data...";

            menuStatusBar.Text = "Please Select the remaining parameters available...";

            foreach (List<Object> data in google_results)
            {

                String date = data[3].ToString();
                firstDates.Add(date);

            }

            graphOption1Select.DataSource = firstDates;

            List<String> timeOptions = new List<String>();
            timeOptions.Add("Seconds");
            timeOptions.Add("Minutes");
            timeOptions.Add("Hours");
            timeOptions.Add("Days");
            timeOptions.Add("Months");
            timeOptions.Add("Years");

            graphOption3Select.DataSource = timeOptions;


        }

        // 4. UPDATE OPTION BOX 2 AS THE USER CHANGES THEIR SELECTION FOR OPTION BOX 1
        private void graphOption1Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            secondDates.Clear();
            graphOption2Select.DataSource = new List<String>();

            foreach (String str in firstDates)
            {
                if (DateTime.Parse(str) > DateTime.Parse(graphOption1Select.SelectedItem.ToString()))
                {
                    secondDates.Add(str);
                }

            }

            graphOption2Select.DataSource = secondDates;

        }

        private void graphOption3Select_SelectedIndexChanged(object sender, EventArgs e)
        {

            bool first = true;
            DateTime recentDate = new DateTime();
            DateTime nextDate;

            graphOption1Select.DataSource = new List<String>();
            firstDates.Clear();

            foreach (List<Object> data in google_results)
            {

                if (first)
                {
                    String date = data[3].ToString();
                    recentDate = Convert.ToDateTime(data[3]);
                    firstDates.Add(date);
                    first = false;

                }
                else
                {
                    nextDate = Convert.ToDateTime(data[3]);

                    if (graphOption3Select.SelectedItem.Equals("Seconds"))
                    {
                        if (nextDate.Second != recentDate.Second || nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                        {
                            firstDates.Add(data[3].ToString());
                        }

                    }
                    else if (graphOption3Select.SelectedItem.Equals("Minutes"))
                    {
                        if (nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                        {
                            firstDates.Add(data[3].ToString());
                        }

                    }
                    else if (graphOption3Select.SelectedItem.Equals("Hours"))
                    {
                        if (nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                        {
                            firstDates.Add(data[3].ToString());
                        }
                    }
                    else if (graphOption3Select.SelectedItem.Equals("Days"))
                    {
                        if (nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                        {
                            firstDates.Add(data[3].ToString());
                        }
                    }
                    else if (graphOption3Select.SelectedItem.Equals("Months"))
                    {
                        if (nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                        {
                            firstDates.Add(data[3].ToString());
                        }
                    }
                    else if (graphOption3Select.SelectedItem.Equals("Years"))
                    {
                        if (nextDate.Year != recentDate.Year)
                        {
                            firstDates.Add(data[3].ToString());
                        }
                    }

                    recentDate = nextDate;
                }

            }

            graphOption1Select.DataSource = firstDates;

        }

        // 5. THE USER HAS SELECTED ALL REQUIRED DATA AND PRESSES GRAPH BUTTON
        private void graphGraphButton_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(graphOption1Select.SelectedItem, null) || ReferenceEquals(graphOption2Select.SelectedItem, null) || ReferenceEquals(graphOption3Select.SelectedItem, null))
            {
                MessageBox.Show("Please select all required boxes");
                return;
            }


            targetGraph = new Graph();


            if (firstTimeGraphing)
            {
                graphData = new Graph();
                graphUpdateDone = true;
                graphData = configureGraph(graphData);
                firstTimeGraphing = false;
            }
            else
            {
                graphUpdateDone = false;
                buildingUp = false;
                takingDown = true;
            }



        }

        // 6. CONFIGURE THE GRAPH SO THAT IT IS FORMATTED CORRECTLY FOR THE SCREEN
        private Graph configureGraph(Graph _graph)
        {
            bool first = true;

            String firstDate = (String)graphOption1Select.SelectedValue;
            String secondDate = (String)graphOption2Select.SelectedValue;

            List<List<Object>> narrowedData = new List<List<Object>>();
            List<DateTime> dates = new List<DateTime>();

            DateTime currentDate = new DateTime();
            DateTime lastDate = new DateTime();

            graphDisplay.Width = OGgraphDisplayWidth;

            int pixelsPerRect = 0;

            foreach (List<Object> data in google_results)
            {

                if (first)
                {
                    if (graphOption3Select.SelectedValue.Equals("Seconds"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddSeconds(-1);
                    }
                    else if (graphOption3Select.SelectedValue.Equals("Minutes"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddMinutes(-1);
                    }
                    else if (graphOption3Select.SelectedValue.Equals("Hours"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddHours(-1);
                    }
                    else if (graphOption3Select.SelectedValue.Equals("Days"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddDays(-1);
                    }
                    else if (graphOption3Select.SelectedValue.Equals("Months"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddMonths(-1);
                    }
                    else if (graphOption3Select.SelectedValue.Equals("Years"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddYears(-1);
                    }

                    first = false;
                }

                lastDate = currentDate;
                currentDate = Convert.ToDateTime(data[3]);

                currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second, 0);


                if (isValidDate(currentDate, lastDate) && ((currentDate >= DateTime.Parse(firstDate)) && (currentDate <= DateTime.Parse(secondDate))))
                {
                    narrowedData.Add(data);
                    dates.Add(currentDate);
                }


            }

            decodedData = decodeData(narrowedData, (String)graphXAxisSelect.SelectedValue);

            // Configure Y Pixels
            configureYData(decodedData);

            // Configure X Pixels
            TimeSpan totalTime = (dates[(dates.Count - 1)] - dates[0]);
            bool getOutOfLoop = false;

            if (graphOption3Select.SelectedItem.Equals("Seconds"))
            {
                double timeSpan = totalTime.TotalSeconds;
                // REPRESENTS HOW MANY INDICIES NEED TO BE PLOTTED ON THE GRAPH
                int seconds = Convert.ToInt32(timeSpan) + 1;
                // ROUND UP IF THERE ARE ANY MILLISECONDS
                if (((timeSpan + 1) - (double)seconds) > 0)
                {
                    seconds++;
                }
                int slots = (seconds * 2) - 1;

                if (slots >= 2000)
                {
                    MessageBox.Show("To many values, please make the distance between data point 1 and 2 smaller.");
                    return _graph;
                }
                // MAKE ROOM FOR THE BORDER
                int totalNumPixels = graphDisplay.Width - 8;

                // FIND A PICTURE BOX WIDTH THAT WILL FIT THE NUMBER OF REQUIRED INDICIES
                while (!getOutOfLoop)
                {
                    if (totalNumPixels % ((seconds * 2) - 1) != 0)
                    {
                        totalNumPixels--;
                    }
                    else
                    {
                        getOutOfLoop = true;
                    }
                }

                pixelsPerRect = totalNumPixels / ((seconds * 2) - 1);

                if (pixelsPerRect <= 14)
                {

                    totalNumPixels = 14 * ((seconds * 2) - 1);
                    if (totalNumPixels > graphDisplay.Width)
                    {
                        graphDisplay.Width = totalNumPixels + 50;
                    }

                }

                pixelsPerRect = totalNumPixels / ((seconds * 2) - 1);

                // DETERMINE WHAT KIND OF GRAPH IS BEING PLOTTED
                String graphType;

                if (graphBarBox.Checked)
                {
                    graphType = "bar";

                }
                else if (graphLineBox.Checked)
                {

                    graphType = "line";
                }
                else
                {
                    graphType = "bar";
                }

                TimeSpan ts = dates[dates.Count - 1].Subtract(dates[0]);

                _graph = new Graph(graphType, dates[0].Second, Convert.ToInt32(ts.TotalSeconds) + dates[0].Second, pixelsPerRect, (seconds * 2) - 1, "seconds",
                    0, 0, 0, 0,
                    decodedData, dates);
            }
            else if (graphOption3Select.SelectedItem.Equals("Minutes"))
            {
                double timeSpan = totalTime.TotalMinutes;
                // REPRESENTS HOW MANY INDICIES NEED TO BE PLOTTED ON THE GRAPH
                int minutes = Convert.ToInt32(timeSpan) + 1;
                // ROUND UP IF THERE ARE ANY MILLISECONDS
                if (((timeSpan + 1) - (double)minutes) > 0)
                {
                    minutes++;
                }
                int slots = (minutes * 2) - 1;

                if (slots >= 2000)
                {
                    MessageBox.Show("To many values, please make the distance between data point 1 and 2 smaller.");
                    return _graph;
                }

                // MAKE ROOM FOR THE BORDER
                int totalNumPixels = graphDisplay.Width - 4;

                // FIND A PICTURE BOX WIDTH THAT WILL FIT THE NUMBER OF REQUIRED INDICIES
                while (!getOutOfLoop)
                {
                    if (totalNumPixels % ((minutes * 2) - 1) != 0)
                    {
                        totalNumPixels--;
                    }
                    else
                    {
                        getOutOfLoop = true;
                    }
                }

                pixelsPerRect = totalNumPixels / ((minutes * 2) - 1);

                if (pixelsPerRect <= 14)
                {

                    totalNumPixels = 14 * ((minutes * 2) - 1);
                    if (totalNumPixels > graphDisplay.Width)
                    {
                        graphDisplay.Width = totalNumPixels + 50;
                    }
                }

                pixelsPerRect = totalNumPixels / ((minutes * 2) - 1);

                // DETERMINE WHAT KIND OF GRAPH IS BEING PLOTTED
                String graphType;

                if (graphBarBox.Checked)
                {
                    graphType = "bar";

                }
                else if (graphLineBox.Checked)
                {

                    graphType = "line";
                }
                else
                {
                    graphType = "bar";
                }

                TimeSpan ts = dates[dates.Count - 1].Subtract(dates[0]);


                _graph = new Graph(graphType, dates[0].Minute, Convert.ToInt32(ts.TotalMinutes) + dates[0].Minute, pixelsPerRect, (minutes * 2) - 1, "minutes",
                    0, 0, 0, 0,
                    decodedData, dates);
            }
            else if (graphOption3Select.SelectedItem.Equals("Hours"))
            {
                double timeSpan = totalTime.TotalHours;
                // REPRESENTS HOW MANY INDICIES NEED TO BE PLOTTED ON THE GRAPH
                int hours = Convert.ToInt32(timeSpan) + 1;
                // ROUND UP IF THERE ARE ANY MILLISECONDS
                if (((timeSpan + 1) - (double)hours) > 0)
                {
                    hours++;
                }
                int slots = (hours * 2) - 1;

                if (slots >= 2000)
                {
                    MessageBox.Show("To many values, please make the distance between data point 1 and 2 smaller.");
                    return _graph;
                }

                // MAKE ROOM FOR THE BORDER
                int totalNumPixels = graphDisplay.Width - 4;

                // FIND A PICTURE BOX WIDTH THAT WILL FIT THE NUMBER OF REQUIRED INDICIES
                while (!getOutOfLoop)
                {
                    if (totalNumPixels % ((hours * 2) - 1) != 0)
                    {
                        totalNumPixels--;
                    }
                    else
                    {
                        getOutOfLoop = true;
                    }
                }

                pixelsPerRect = totalNumPixels / ((hours * 2) - 1);

                if (pixelsPerRect <= 14)
                {

                    totalNumPixels = 14 * ((hours * 2) - 1);
                    if (totalNumPixels > graphDisplay.Width)
                    {
                        graphDisplay.Width = totalNumPixels + 50;
                    }
                }

                pixelsPerRect = totalNumPixels / ((hours * 2) - 1);

                // DETERMINE WHAT KIND OF GRAPH IS BEING PLOTTED
                String graphType;

                if (graphBarBox.Checked)
                {
                    graphType = "bar";

                }
                else if (graphLineBox.Checked)
                {

                    graphType = "line";
                }
                else
                {
                    graphType = "bar";
                }

                TimeSpan ts = dates[dates.Count - 1].Subtract(dates[0]);


                _graph = new Graph(graphType, dates[0].Hour, Convert.ToInt32(ts.TotalHours) + dates[0].Hour, pixelsPerRect, (hours * 2) - 1, "hours",
                    0, 0, 0, 0,
                    decodedData, dates);
            }
            else if (graphOption3Select.SelectedItem.Equals("Days"))
            {
                double timeSpan = totalTime.TotalDays;

                // REPRESENTS HOW MANY INDICIES NEED TO BE PLOTTED ON THE GRAPH
                int days = Convert.ToInt32(timeSpan) + 1;

                // ROUND UP IF THERE ARE ANY MILLISECONDS
                if (((timeSpan + 1) - (double)days) > 0)
                {
                    days++;
                }

                int slots = (days * 2) - 1;

                if (slots >= 2000)
                {
                    MessageBox.Show("To many values, please make the distance between data point 1 and 2 smaller.");
                    return _graph;
                }

                // MAKE ROOM FOR THE BORDER
                int totalNumPixels = graphDisplay.Width - 4;

                // FIND A PICTURE BOX WIDTH THAT WILL FIT THE NUMBER OF REQUIRED INDICIES
                while (!getOutOfLoop)
                {
                    if (totalNumPixels % ((days * 2) - 1) != 0)
                    {
                        totalNumPixels--;
                    }
                    else
                    {
                        getOutOfLoop = true;
                    }
                }

                pixelsPerRect = totalNumPixels / ((days * 2) - 1);

                if (pixelsPerRect <= 14)
                {

                    totalNumPixels = 14 * ((days * 2) - 1);
                    if (totalNumPixels > graphDisplay.Width)
                    {
                        graphDisplay.Width = totalNumPixels + 50;
                    }
                }

                pixelsPerRect = totalNumPixels / ((days * 2) - 1);

                // DETERMINE WHAT KIND OF GRAPH IS BEING PLOTTED
                String graphType;

                if (graphBarBox.Checked)
                {
                    graphType = "bar";

                }
                else if (graphLineBox.Checked)
                {

                    graphType = "line";
                }
                else
                {
                    graphType = "bar";
                }

                TimeSpan ts = dates[dates.Count - 1].Subtract(dates[0]);


                _graph = new Graph(graphType, dates[0].Day, days + dates[0].Day, pixelsPerRect, slots, "days",
                    0, 0, 0, 0,
                    decodedData, dates);
            }
            else if (graphOption3Select.SelectedItem.Equals("Months"))
            {
                double timeSpan = MonthDifference(dates[(dates.Count - 1)], dates[0]);

                // REPRESENTS HOW MANY INDICIES NEED TO BE PLOTTED ON THE GRAPH
                int months = Convert.ToInt32(timeSpan) + 1;

                // ROUND UP IF THERE ARE ANY MILLISECONDS
                if (((timeSpan + 1) - (double)months) > 0)
                {
                    months++;
                }

                int slots = (months * 2) - 1;

                if (slots >= 2000)
                {
                    MessageBox.Show("To many values, please make the distance between data point 1 and 2 smaller.");
                    return _graph;
                }

                // MAKE ROOM FOR THE BORDER
                int totalNumPixels = graphDisplay.Width - 4;

                // FIND A PICTURE BOX WIDTH THAT WILL FIT THE NUMBER OF REQUIRED INDICIES
                while (!getOutOfLoop)
                {
                    if (totalNumPixels % ((months * 2) - 1) != 0)
                    {
                        totalNumPixels--;
                    }
                    else
                    {
                        getOutOfLoop = true;
                    }
                }

                pixelsPerRect = totalNumPixels / ((months * 2) - 1);

                if (pixelsPerRect <= 14)
                {

                    totalNumPixels = 14 * ((months * 2) - 1);
                    if (totalNumPixels > graphDisplay.Width)
                    {
                        graphDisplay.Width = totalNumPixels + 50;
                    }
                }

                pixelsPerRect = totalNumPixels / ((months * 2) - 1);

                // DETERMINE WHAT KIND OF GRAPH IS BEING PLOTTED
                String graphType;

                if (graphBarBox.Checked)
                {
                    graphType = "bar";

                }
                else if (graphLineBox.Checked)
                {

                    graphType = "line";
                }
                else
                {
                    graphType = "bar";
                }

                TimeSpan ts = dates[dates.Count - 1].Subtract(dates[0]);


                _graph = new Graph(graphType, dates[0].Month, months + dates[0].Month, pixelsPerRect, slots, "months",
                    0, 0, 0, 0,
                    decodedData, dates);
            }
            else if (graphOption3Select.SelectedItem.Equals("Years"))
            {
                double timeSpan = dates[dates.Count - 1].Year - dates[0].Year;

                // REPRESENTS HOW MANY INDICIES NEED TO BE PLOTTED ON THE GRAPH
                int years = Convert.ToInt32(timeSpan) + 1;

                // ROUND UP IF THERE ARE ANY MILLISECONDS
                if (((timeSpan + 1) - (double)years) > 0)
                {
                    years++;
                }

                int slots = (years * 2) - 1;

                if (slots >= 2000)
                {
                    MessageBox.Show("To many values, please make the distance between data point 1 and 2 smaller.");
                    return _graph;
                }

                // MAKE ROOM FOR THE BORDER
                int totalNumPixels = graphDisplay.Width - 4;

                // FIND A PICTURE BOX WIDTH THAT WILL FIT THE NUMBER OF REQUIRED INDICIES
                while (!getOutOfLoop)
                {
                    if (totalNumPixels % ((years * 2) - 1) != 0)
                    {
                        totalNumPixels--;
                    }
                    else
                    {
                        getOutOfLoop = true;
                    }
                }

                pixelsPerRect = totalNumPixels / ((years * 2) - 1);

                if (pixelsPerRect <= 14)
                {

                    totalNumPixels = 14 * ((years * 2) - 1);
                    if (totalNumPixels > graphDisplay.Width)
                    {
                        graphDisplay.Width = totalNumPixels + 50;
                    }
                }

                pixelsPerRect = totalNumPixels / ((years * 2) - 1);

                // DETERMINE WHAT KIND OF GRAPH IS BEING PLOTTED
                String graphType;

                if (graphBarBox.Checked)
                {
                    graphType = "bar";

                }
                else if (graphLineBox.Checked)
                {

                    graphType = "line";
                }
                else
                {
                    graphType = "bar";
                }

                TimeSpan ts = dates[dates.Count - 1].Subtract(dates[0]);


                _graph = new Graph(graphType, dates[0].Year, years + dates[0].Year, pixelsPerRect, slots, "years",
                    0, 0, 0, 0,
                    decodedData, dates);
            }

            graphConfigured = true;
            return _graph;
        }

        private void configureYData(List<dataPoint> decodedData)
        {
            // Determine the largest Y value....

            int largestYValue = 0;

            foreach (dataPoint dp in decodedData)
            {
                if (dp.yValue > largestYValue)
                {
                    largestYValue = dp.yValue;
                }
            }

            // Add some head room
            double amountToAdd = largestYValue * .25;
            largestYValue += Convert.ToInt32(Math.Round(amountToAdd));


            // Make a multiple of 10
            while (largestYValue % 10 != 0)
            {
                largestYValue++;
            }


            // Determine how many pixels should be used for each incrament

            int numPixels = graphDisplay.Height;

            if (largestYValue > numPixels)
            {
                yPixelScale = 1;

                double pixelScale = 1;

                while (largestYValue > numPixels)
                {
                    pixelScale = pixelScale * (10.0/9);
                    largestYValue = Convert.ToInt32(largestYValue * .9);
                }

                yPixelScale = Convert.ToInt32(pixelScale);
            }
            else
            {
                yPixelScale = 1;
            }
            while (numPixels % largestYValue != 0)
            {
                numPixels--;
            }
            if (yPixelScale > 10)
            {
                incramentValue = yPixelScale;
            }
            else
            {
                incramentValue = 5;
            }

            yMultiplier = numPixels / largestYValue;

            // Try first with 1, if the pixels per index is 1 then try 10 and so on...

            // return the number to be multiplied to all values when they are graphed
        }

        private bool isValidDate(DateTime nextDate, DateTime recentDate)
        {


            if (graphOption3Select.SelectedItem.Equals("Seconds"))
            {
                if (nextDate.Second != recentDate.Second || nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else if (graphOption3Select.SelectedItem.Equals("Minutes"))
            {
                if (nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else if (graphOption3Select.SelectedItem.Equals("Hours"))
            {
                if (nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (graphOption3Select.SelectedItem.Equals("Days"))
            {
                if (nextDate.Day != recentDate.Day || nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (graphOption3Select.SelectedItem.Equals("Months"))
            {
                if (nextDate.Month != recentDate.Month || nextDate.Year != recentDate.Year)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (graphOption3Select.SelectedItem.Equals("Years"))
            {
                if (nextDate.Year != recentDate.Year)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;


        }

        // 7. TAKE THE GOOGLE DATA AND EXTRACT THE INFORMATION NECESSARY
        private List<dataPoint> decodeData(List<List<Object>> dataList, String dataType)
        {
            int value = 0;
            int i = 0;

            dataPoint dp;
            List<dataPoint> results = new List<dataPoint>();

            // ------------------------------------------------------------------------------------------------------------------------------------------------------------------
            foreach (List<object> data in dataList)
            {
                String[] dataValues = ((String)data[1]).Split('-');
                
            
                if(dataType.Equals("RPM"))
                {
                    int A = int.Parse(dataValues[5], System.Globalization.NumberStyles.HexNumber);
                    int B = int.Parse(dataValues[6], System.Globalization.NumberStyles.HexNumber);

                    value = ((256 * A) + B) / 4;
                }

                // Add other PID equations
                

                dp = new dataPoint("Name", "Red", value, i);
                results.Add(dp);

                i++;
            }

            return results;
        }

        // 8. THE PICTURE BOX HAS BEEN INVALIDATED
        private void GraphDisplay_Paint(object sender, PaintEventArgs e)
        {
            drawGraphData(e);
        }

        // ALLOWS GRAPH TO UPDATE WITH ANIMATION INSTEAD OF INSTANTANEOUSLY 
        private void updateGraph()
        {
            List<dataPoint> temp = new List<dataPoint>();
            int updateValue = incramentValue * updateScale;
            if (!graphUpdateDone)
            {
                if (takingDown)
                {
                    bool needToKeepGoing = false;

                    foreach (dataPoint dp in graphData.dataEntries)
                    {
                        if (dp.yValue != 0)
                        {
                            if ((dp.yValue - (updateValue)) < 0)
                            {
                                dp.yValue--;
                            }
                            else
                            {
                                dp.yValue -= updateValue;
                            }
                            needToKeepGoing = true;
                        }

                        temp.Add(dp);
                    }

                    graphData.dataEntries = temp;

                    if (!needToKeepGoing)
                    {

                        takingDown = false;
                        buildingUp = true;
                        graphData = new Graph();
                        graphData = configureGraph(graphData);
                        targetGraph = configureGraph(targetGraph);
                        graphData.dataEntries = zeroOut(graphData.dataEntries);
                    }


                }

                else if (buildingUp)
                {
                    bool needToKeepGoing = false;

                    for (int i = 0; i < graphData.dataEntries.Count; i++)
                    {
                        if (graphData.dataEntries[i].yValue != targetGraph.dataEntries[i].yValue)
                        {
                            if (graphData.dataEntries[i].yValue + updateValue > targetGraph.dataEntries[i].yValue)
                            {
                                graphData.dataEntries[i].yValue++;
                            }
                            else
                            {
                                graphData.dataEntries[i].yValue += updateValue;
                            }

                            needToKeepGoing = true;
                        }
                    }

                    if (!needToKeepGoing)
                    {
                        graphUpdateDone = true;
                    }

                }
            }
        }

        private void drawDashBoard(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle();


            //rect = new Rectangle(200, 200, 200, 200);

            using (Font myFont = new Font("Arial", 20))
            {
 
                e.Graphics.DrawString("Howdy Partner", myFont, Brushes.Red, 350, 40);

            }

            if(ReferenceEquals(null, google_results))
            {
                setGaugeValue("rpmGauge", 0);
                setGaugeValue("speedGauge", 0);
            }
            else
            {
                setGaugeValue("rpmGauge", 50);
                setGaugeValue("speedGauge", 50);
            }


        }

        // 9. DRAW THE GRAPH BEING STORED IN GLOBAL GRAPH OBJECT
        private void drawGraphData(PaintEventArgs e)
        {
            if (graphConfigured)
            {
                Rectangle rect;
                DateTime currDate;

                bool firstTime = true;
                bool firstPoint = true;

                bool firstDataPoint = true;

                int dpIndex = 0;
                int currXPixel = 4;
                int currGraphIndex = graphData.xStart;
                int currentDateSecond = 0;
                int currentDateMinute = 0;
                int currentDateHour = 0;
                int currentDateDay = 0;
                int currentDateMonth = 0;
                int currentDateYear = 0;

                int currentSecondIndex = 0;
                int currentMinuteIndex = 0;
                int currentHourIndex = 0;
                int currentDayIndex = 0;
                int currentMonthIndex = 0;
                int currentYearIndex = 0;

                if (graphData != null)
                {
                    // GO TO EACH INDEX ON THE GRAPH
                    for (int i = graphData.xStart; i <= graphData.xEnd; i++)
                    {
                        // Won't run if it is the first time, all these variables will be correctly set the first time through the loop below
                        if (i != graphData.xStart)
                        {
                            // Checking for intervals of 60 (Seconds and Minutes)
                            if ((graphData.timeInterval.Equals("seconds") || graphData.timeInterval.Equals("minutes")) && (i % 60) == 0)
                            {
                                if (graphData.timeInterval.Equals("seconds"))
                                {
                                    currentMinuteIndex++;
                                    currGraphIndex = 0;

                                    if ((currentMinuteIndex % 60) == 0)
                                    {
                                        currentHourIndex++;
                                        currentMinuteIndex = 0;
                                    }

                                    if ((currentHourIndex % 24) == 0)
                                    {
                                        currentDayIndex++;
                                        currentHourIndex = 0;
                                    }

                                    if ((currentDayIndex % 30) == 0)
                                    {
                                        currentMonthIndex++;
                                        currentDayIndex = 0;
                                    }

                                    if ((currentMonthIndex % 12) == 0)
                                    {
                                        currentYearIndex++;
                                        currentMonthIndex = 0;
                                    }
                                }
                                else if (graphData.timeInterval.Equals("minutes"))
                                {
                                    currentHourIndex++;
                                    currGraphIndex = 0;

                                    if ((currentHourIndex % 24) == 0)
                                    {
                                        currentDayIndex++;
                                        currentHourIndex = 0;
                                    }
                                    if ((currentDayIndex % 30) == 0)
                                    {
                                        currentMonthIndex++;
                                        currentDayIndex = 0;
                                    }

                                    if ((currentMonthIndex % 12) == 0)
                                    {
                                        currentYearIndex++;
                                        currentMonthIndex = 0;
                                    }
                                }
                            }
                            else if (graphData.timeInterval.Equals("hours") && (i % 24) == 0)
                            {

                                currentDayIndex++;
                                currGraphIndex = 0;

                                if ((currentDayIndex % 30) == 0)
                                {
                                    currentMonthIndex++;
                                    currentDayIndex = 0;
                                }

                                if ((currentMonthIndex % 12) == 0)
                                {
                                    currentYearIndex++;
                                    currentMonthIndex = 0;
                                }

                            } else if(graphData.timeInterval.Equals("days") && (i % 30) == 0)
                            {
                                currentMonthIndex++;
                                currGraphIndex = 0;

                                if ((currentMonthIndex % 12) == 0)
                                {
                                    currentYearIndex++;
                                    currentMonthIndex = 0;
                                }

                            } else if(graphData.timeInterval.Equals("months") && (i % 12) == 0)
                            {
                                currentYearIndex++;
                                currGraphIndex = 0;
                            }
                            else
                            {
                                currGraphIndex++;
                            }
                        }

                        // AT EACH INDEX, CHECK THE CURRENT INDEX TO A DATE IN THE "DATES" LIST
                        for (int j = 0; j < graphData.dates.Count; j++)
                        {

                            currDate = graphData.dates[j];

                            currentDateSecond = currDate.Second;
                            currentDateMinute = currDate.Minute;
                            currentDateHour = currDate.Hour;
                            currentDateDay = currDate.Day;
                            currentDateMonth = currDate.Month;
                            currentDateYear = currDate.Year;

                            if (firstTime)
                            {
                                currentMinuteIndex = currentDateMinute;
                                currentHourIndex = currentDateHour;
                                currentDayIndex = currentDateDay;
                                currentMonthIndex = currentDateMonth;
                                currentYearIndex = currentDateYear;
                                firstTime = false;
                            }

                            if (graphData.timeInterval == "seconds")
                            {
                                currentSecondIndex = currGraphIndex;

                                if (currentSecondIndex == currentDateSecond && currentMinuteIndex == currentDateMinute && currentHourIndex == currentDateHour
                                    && currentDayIndex == currentDateDay && currentMonthIndex == currentDateMonth && currentYearIndex == currentDateYear)
                                {
                                    dataPoint dp = graphData.dataEntries[dpIndex];


                                    // RECTANGLE
                                    if (graphData.graphType.Equals("bar"))
                                    {
                                        drawRectangle(dp, currXPixel, e);

                                    // LINE
                                    }
                                    else if (graphData.graphType.Equals("line"))
                                    {
                                        firstPoint = drawDot(dp, currXPixel, e, firstPoint);
                                    }

                                    // Y VALUE
                                    firstDataPoint = drawYValue(dp, currXPixel, e, firstDataPoint);

                                    dpIndex++;
                                    j = graphData.dates.Count;
                                }
                            }
                            else if (graphData.timeInterval == "minutes")
                            {
                                currentMinuteIndex = currGraphIndex;

                                if (currentMinuteIndex == currentDateMinute && currentHourIndex == currentDateHour && currentDayIndex == currentDateDay
                                    && currentMonthIndex == currentDateMonth && currentYearIndex == currentDateYear)
                                {
                                    dataPoint dp = graphData.dataEntries[dpIndex];
                                    if (graphData.graphType.Equals("bar"))
                                    {
                                        drawRectangle(dp, currXPixel, e);
                                    }
                                    else if (graphData.graphType.Equals("line"))
                                    {
                                        firstPoint = drawDot(dp, currXPixel, e, firstPoint);
                                    }
                                    firstDataPoint = drawYValue(dp, currXPixel, e, firstDataPoint);
                                    dpIndex++;
                                    j = graphData.dates.Count;
                                }
                            }
                            else if (graphData.timeInterval == "hours")
                            {
                                currentHourIndex = currGraphIndex;

                                if (currentHourIndex == currentDateHour && currentDayIndex == currentDateDay
                                    && currentMonthIndex == currentDateMonth && currentYearIndex == currentDateYear)
                                {
                                    dataPoint dp = graphData.dataEntries[dpIndex];
                                    if (graphData.graphType.Equals("bar"))
                                    {
                                        drawRectangle(dp, currXPixel, e);
                                    }
                                    else if (graphData.graphType.Equals("line"))
                                    {
                                        firstPoint = drawDot(dp, currXPixel, e, firstPoint);
                                    }
                                    firstDataPoint = drawYValue(dp, currXPixel, e, firstDataPoint);
                                    dpIndex++;
                                    j = graphData.dates.Count;
                                }
                            }
                            else if (graphData.timeInterval == "days")
                            {
                                currentDayIndex = currGraphIndex;

                                if (currentDayIndex == currentDateDay && currentMonthIndex == currentDateMonth && currentYearIndex == currentDateYear)
                                {
                                    dataPoint dp = graphData.dataEntries[dpIndex];
                                    if (graphData.graphType.Equals("bar"))
                                    {
                                        drawRectangle(dp, currXPixel, e);
                                    }
                                    else if (graphData.graphType.Equals("line"))
                                    {
                                        firstPoint = drawDot(dp, currXPixel, e, firstPoint);
                                    }
                                    firstDataPoint = drawYValue(dp, currXPixel, e, firstDataPoint);
                                    dpIndex++;
                                    j = graphData.dates.Count;
                                }
                            }
                            else if (graphData.timeInterval == "months")
                            {
                                currentMonthIndex = currGraphIndex;

                                if (currentMonthIndex == currentDateMonth && currentYearIndex == currentDateYear)
                                {
                                    dataPoint dp = graphData.dataEntries[dpIndex];

                                    if (graphData.graphType.Equals("bar"))
                                    {
                                        drawRectangle(dp, currXPixel, e);
                                    }
                                    else if (graphData.graphType.Equals("line"))
                                    {
                                        firstPoint = drawDot(dp, currXPixel, e, firstPoint);
                                    }
                                    firstDataPoint = drawYValue(dp, currXPixel, e, firstDataPoint);
                                    dpIndex++;
                                    j = graphData.dates.Count;
                                }
                            }
                            else if (graphData.timeInterval == "years")
                            {
                                currentYearIndex = currGraphIndex;

                                if (currentYearIndex == currentDateYear)
                                {
                                    dataPoint dp = graphData.dataEntries[dpIndex];

                                    if (graphData.graphType.Equals("bar"))
                                    {
                                        drawRectangle(dp, currXPixel, e);
                                    }
                                    else if (graphData.graphType.Equals("line"))
                                    {
                                        firstPoint = drawDot(dp, currXPixel, e, firstPoint);
                                    }
                                    firstDataPoint = drawYValue(dp, currXPixel, e, firstDataPoint);
                                    dpIndex++;
                                    j = graphData.dates.Count;
                                }
                            }

                            // LITTLE MARK FOR EACH INDEX
                            if (zoomLevel >= 17)
                            {
                                rect = new Rectangle(currXPixel + (((graphData.xInterval - (zoomLevel - 17)) / 2) - 1), graphDisplay.Height - 40, 1, 10);
                            }
                            else
                            {
                                rect = new Rectangle(currXPixel + ((graphData.xInterval / 2) - 2), graphDisplay.Height - 40, 2, 10);
                            }
                            using (Pen pen = new Pen(System.Drawing.Color.Red, 2))
                            {
                                e.Graphics.DrawRectangle(pen, rect);
                            }


                            // TIMESTAMP ON X AXIS
                            int xIntervalCheckAmount;
                            if (zoomLevel - 17 > 0)
                            {
                                xIntervalCheckAmount = zoomLevel - 17;
                            }
                            else
                            {
                                xIntervalCheckAmount = 0;
                            }
                            if (graphData.xInterval - (xIntervalCheckAmount) >= 14)
                            {
                                if (graphData.xInterval > 60)
                                {
                                    using (Font myFont = new Font("Arial", 9))
                                    {
                                        e.Graphics.DrawString(currentDayIndex + ":" + currentHourIndex + ":" + currentMinuteIndex + ":" + currentSecondIndex, myFont, Brushes.Red, new Point((currXPixel + ((graphData.xInterval / 2))) - 30, graphDisplay.Height - 25));
                                    }
                                }
                                else
                                {

                                    using (Font myFont = new Font("Arial", 9))
                                    {
                                        if (graphData.timeInterval.Equals("seconds"))
                                        {
                                            e.Graphics.DrawString(currentSecondIndex.ToString(), myFont, Brushes.Red, new Point((currXPixel + ((graphData.xInterval / 2))) - 5, graphDisplay.Height - 25));
                                        }
                                        else if (graphData.timeInterval.Equals("minutes"))
                                        {
                                            e.Graphics.DrawString(currentMinuteIndex.ToString(), myFont, Brushes.Red, new Point((currXPixel + ((graphData.xInterval / 2))) - 5, graphDisplay.Height - 25));
                                        }
                                        else if (graphData.timeInterval.Equals("hours"))
                                        {
                                            e.Graphics.DrawString(currentHourIndex.ToString(), myFont, Brushes.Red, new Point((currXPixel + ((graphData.xInterval / 2))) - 5, graphDisplay.Height - 25));
                                        }
                                        else if (graphData.timeInterval.Equals("days"))
                                        {
                                            e.Graphics.DrawString(currentDayIndex.ToString(), myFont, Brushes.Red, new Point((currXPixel + ((graphData.xInterval / 2))) - 5, graphDisplay.Height - 25));
                                        }
                                    }
                                }
                            }
                        }

                        // INCRAMENT THE INDEX
                        currXPixel = (currXPixel + (graphData.xInterval * 2)) - zoomLevel;

                    }
                }
            }
        }

        private void drawRectangle(dataPoint dp, int currXPixel, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle();

            if (zoomLevel >= 17)
            {
                rect = new Rectangle(currXPixel, ((graphDisplay.Height - 30) - ((dp.yValue * yMultiplier)) / yPixelScale), (graphData.xInterval - 2) - (zoomLevel - 17), ((dp.yValue * yMultiplier) / yPixelScale - 2));
            }
            else
            {
                rect = new Rectangle(currXPixel, ((graphDisplay.Height - 30) - ((dp.yValue * yMultiplier)) / yPixelScale), (graphData.xInterval - 2), ((dp.yValue * yMultiplier) / yPixelScale - 2));
            }
            using (SolidBrush brush = new SolidBrush(System.Drawing.Color.Red))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private bool drawDot(dataPoint dp, int currXPixel, PaintEventArgs e, bool firstPoint)
        {
            using (Pen pen = new Pen(System.Drawing.Color.Red, 2))
            {
                Point p = new Point(currXPixel + ((graphData.xInterval / 2) - 2), ((graphDisplay.Height - 45) - (dp.yValue * yMultiplier) / yPixelScale) + 5);
                e.Graphics.DrawEllipse(pen, currXPixel + ((graphData.xInterval / 2) - 2) - 5, ((graphDisplay.Height - 45) - (dp.yValue * yMultiplier) / yPixelScale), 10, 10);

                if (!firstPoint)
                {
                    e.Graphics.DrawLine(pen, lastPoint, p);
                }

                lastPoint = p;

            }

            return false;
        }

        private bool drawYValue(dataPoint dp, int currXPixel, PaintEventArgs e, bool firstDataPoint)
        {
            using (Font myFont = new Font("Arial", 9))
            {
                if (firstDataPoint)
                {
                    e.Graphics.DrawString(dp.yValue.ToString(), myFont, Brushes.Red, new Point((currXPixel + ((graphData.xInterval / 2))) - 10, (graphDisplay.Height - (dp.yValue * yMultiplier) / yPixelScale) - 65));
                }
                else
                {
                    e.Graphics.DrawString(dp.yValue.ToString(), myFont, Brushes.Red, new Point((currXPixel + ((graphData.xInterval / 2))) - 15, (graphDisplay.Height - (dp.yValue * yMultiplier) / yPixelScale) - 65));
                }
            }

            return false;
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        // USED TO TAKE A LIST OF DATAPOINTS AND MAKE ALL Y VALUES = 0
        private List<dataPoint> zeroOut(List<dataPoint> dp)
        {
            List<dataPoint> temp = new List<dataPoint>();

            foreach (dataPoint _dp in dp)
            {
                _dp.yValue = 0;
                temp.Add(_dp);
            }

            dp = temp;
            return dp;
        }

        private void switchGraphs(int num)
        {
            if (num == 1)
            {
                graphOne.graphConfigured = graphConfigured;
                graphOne.takingDown = takingDown;
                graphOne.buildingUp = buildingUp;
                graphOne.graphUpdateDone = graphUpdateDone;
                graphOne.firstTimeGraphing = firstTimeGraphing;

                graphOne.incramentValue = incramentValue;
                graphOne.yMultiplier = yMultiplier;
                graphOne.yPixelScale = yPixelScale;
                graphOne.OGgraphDisplayWidth = OGgraphDisplayWidth;
                graphOne.zoomLevel = zoomLevel;
                graphOne.MAXZOOMLEVEL = MAXZOOMLEVEL;

                graphOne.decodedData = decodedData;
                graphOne.firstDates = firstDates;
                graphOne.secondDates = secondDates;
                graphOne.google_results = google_results;
                graphOne.lastPoint = lastPoint;

                graphOne.graphData = graphData;
                graphOne.targetGraph = targetGraph;

                Object[] objArray = new Object[graphOption1Select.Items.Count];
                graphOption1Select.Items.CopyTo(objArray, 0);

                objArray = new Object[graphOption2Select.Items.Count];
                graphOption2Select.Items.CopyTo(objArray, 0);

                graphOne.dataOptionsOne = objArray.ToList<Object>();
                graphOne.dataOptionsTwo = objArray.ToList<Object>();

                graphOne.dataOptionIndexOne = graphOption1Select.SelectedIndex;
                graphOne.dataOptionIndexTwo = graphOption2Select.SelectedIndex;

                graphOne.graphDisplay = graphDisplay;

            } else if(num == 2)
            {
                graphTwo.graphConfigured = graphConfigured;
                graphTwo.takingDown = takingDown;
                graphTwo.buildingUp = buildingUp;
                graphTwo.graphUpdateDone = graphUpdateDone;
                graphTwo.firstTimeGraphing = firstTimeGraphing;

                graphTwo.incramentValue = incramentValue;
                graphTwo.yMultiplier = yMultiplier;
                graphTwo.yPixelScale = yPixelScale;
                graphTwo.OGgraphDisplayWidth = OGgraphDisplayWidth;
                graphTwo.zoomLevel = zoomLevel;
                graphTwo.MAXZOOMLEVEL = MAXZOOMLEVEL;

                graphTwo.decodedData = decodedData;
                graphTwo.firstDates = firstDates;
                graphTwo.secondDates = secondDates;
                graphTwo.google_results = google_results;
                graphTwo.lastPoint = lastPoint;

                graphTwo.graphData = graphData;
                graphTwo.targetGraph = targetGraph;

                Object[] objArray = new Object[graphOption1Select.Items.Count];
                graphOption1Select.Items.CopyTo(objArray, 0);

                objArray = new Object[graphOption2Select.Items.Count];
                graphOption2Select.Items.CopyTo(objArray, 0);

                graphTwo.dataOptionsOne = objArray.ToList<Object>();
                graphTwo.dataOptionsTwo = objArray.ToList<Object>();

                graphTwo.dataOptionIndexOne = graphOption1Select.SelectedIndex;
                graphTwo.dataOptionIndexTwo = graphOption2Select.SelectedIndex;

                graphTwo.graphDisplay = graphDisplay;

            } else if(num == 3)
            {
                graphThree.graphConfigured = graphConfigured;
                graphThree.takingDown = takingDown;
                graphThree.buildingUp = buildingUp;
                graphThree.graphUpdateDone = graphUpdateDone;
                graphThree.firstTimeGraphing = firstTimeGraphing;

                graphThree.incramentValue = incramentValue;
                graphThree.yMultiplier = yMultiplier;
                graphThree.yPixelScale = yPixelScale;
                graphThree.OGgraphDisplayWidth = OGgraphDisplayWidth;
                graphThree.zoomLevel = zoomLevel;
                graphThree.MAXZOOMLEVEL = MAXZOOMLEVEL;

                graphThree.decodedData = decodedData;
                graphThree.firstDates = firstDates;
                graphThree.secondDates = secondDates;
                graphThree.google_results = google_results;
                graphThree.lastPoint = lastPoint;

                graphThree.graphData = graphData;
                graphThree.targetGraph = targetGraph;

                Object[] objArray = new Object[graphOption1Select.Items.Count];
                graphOption1Select.Items.CopyTo(objArray, 0);

                objArray = new Object[graphOption2Select.Items.Count];
                graphOption2Select.Items.CopyTo(objArray, 0);

                graphThree.dataOptionsOne = objArray.ToList<Object>();
                graphThree.dataOptionsTwo = objArray.ToList<Object>();

                graphThree.dataOptionIndexOne = graphOption1Select.SelectedIndex;
                graphThree.dataOptionIndexTwo = graphOption2Select.SelectedIndex;

                graphThree.graphDisplay = graphDisplay;
            }
        }

        private void dashBoard_Click(object sender, EventArgs e)
        {

        }

        private void graphOption2Select_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        // HELPER FUNCTIONS FOR GAUGES

        private void setGaugeValue(String name, int value)
        {
            var control = this.Controls.Find(name, true);

            foreach (AGauge c in control)
            {
                c.Value = value;
            }

        }
    }
}
