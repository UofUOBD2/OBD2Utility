using System;
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
        bool graphConfigured = false;


        List<dataPoint> decodedData;
        List<String> firstDates;
        List<String> secondDates;
        List<List<Object>> google_results;
        Dictionary<int, String> xAxisDataPoints = new Dictionary<int, String>();
        Graph graphData;
        Graph targetGraph;


        int incramentValue = 5;
        int yMultiplier;
        int yPixelScale = 1;

        System.Windows.Forms.Timer time;

        bool takingDown;
        bool buildingUp;
        bool graphUpdateDone;


        bool firstTimeGraphing;

        Point lastPoint; 

        PictureBox graphDisplay;

        int OGgraphDisplayWidth;
        int zoomLevel = 0;
        const int MAXZOOMLEVEL = 30;


        // Initializes the form
        public UofUOBD2Utility()
        {
            InitializeComponent();

            takingDown = false;
            buildingUp = false;
            graphUpdateDone = true;
            firstTimeGraphing = true;

            graphDisplay = new PictureBox();
            graphDisplay.Height = graphFlowPanel.Height - 20;
            graphDisplay.Width = graphFlowPanel.Width - 20;
            graphDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            graphDisplay.BackColor = System.Drawing.Color.Black;

            graphFlowPanel.Controls.Add(graphDisplay);

            time = new System.Windows.Forms.Timer();
            time.Interval = 17;
            time.Tick += Time_Tick;
            time.Start();

            graphDisplay.Paint += GraphDisplay_Paint;

            bg.DoWork += Bg_DoWork;

            firstDates = new List<string>();
            secondDates = new List<string>();

            OGgraphDisplayWidth = graphDisplay.Width;

            menuStatusBar.Enabled = false;

            this.graphFlowPanel.MouseWheel += GraphFlowPanel_MouseWheel;

        }

        // OTHER CODE ------------------------------------------------------------------------------------------------------------------------------------------------

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

        private void UofUOBD2Utility_Load(object sender, EventArgs e)
        {
            setUpNextOption("start");
            this.Focus();
        }

        private void menuHome_Click(object sender, EventArgs e)
        {
            setUpNextOption("start");
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

        //GRAPHING CODE -----------------------------------------------------------------------------------------------------------------------------------------------

        // 1. CLICKING THE GRAPH OPTION
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setUpNextOption("graph");

            List<String> xOptions = new List<string>(new String[] { "1", "2", "3" });
            List<String> yOptions = new List<string>(new String[] { "Time", "Option 2", "Option 3" });

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

                } else
                {
                    nextDate = Convert.ToDateTime(data[3]);

                    if (graphOption3Select.SelectedItem.Equals("Seconds"))
                    {
                        if(nextDate.Second != recentDate.Second || nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day)
                        {
                            firstDates.Add(data[3].ToString());
                        }

                    } else if (graphOption3Select.SelectedItem.Equals("Minutes"))
                    {
                        if (nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day)
                        {
                            firstDates.Add(data[3].ToString());
                        }

                    } else if (graphOption3Select.SelectedItem.Equals("Hours"))
                    {
                        if (nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day)
                        {
                            firstDates.Add(data[3].ToString());
                        }
                    } else if (graphOption3Select.SelectedItem.Equals("Days"))
                    {
                        if (nextDate.Day != recentDate.Day)
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
           if(ReferenceEquals(graphOption1Select.SelectedItem, null) || ReferenceEquals(graphOption2Select.SelectedItem, null) || ReferenceEquals(graphOption3Select.SelectedItem, null))
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
                    } else if (graphOption3Select.SelectedValue.Equals("Minutes"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddMinutes(-1);
                    } else if (graphOption3Select.SelectedValue.Equals("Hours"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddHours(-1);
                    } else if (graphOption3Select.SelectedValue.Equals("Days"))
                    {
                        currentDate = Convert.ToDateTime(data[3]).AddDays(-1);
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

            decodedData = decodeData(narrowedData);

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

                if(slots >= 2000)
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

                if(pixelsPerRect <= 14)
                {

                    totalNumPixels = 14 * ((seconds * 2) - 1);
                    if(totalNumPixels > graphDisplay.Width)
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

            graphConfigured = true;
            return _graph;
        }

        private void configureYData(List<dataPoint> decodedData)
        {
            // Determine the largest Y value....

            int largestYValue = 0; 

            foreach(dataPoint dp in decodedData)
            {
                if(dp.yValue > largestYValue)
                {
                    largestYValue = dp.yValue;
                }
            }

            // Add some head room
            double amountToAdd = largestYValue * .20;
            largestYValue += Convert.ToInt32(Math.Round(amountToAdd));


            // Make a multiple of 10
            while (largestYValue % 10 != 0)
            {
                largestYValue++;
            }

            
            // Determine how many pixels should be used for each incrament

            int numPixels = graphDisplay.Height;

            if(largestYValue > numPixels)
            {
                yPixelScale = 1;

                while(largestYValue > numPixels)
                {
                    yPixelScale = yPixelScale * 10; 
                    largestYValue = largestYValue / 10;
                }

            } else
            {
                yPixelScale = 1;
            }
            while(numPixels % largestYValue != 0)
            {
                numPixels--;
            }
            if(yPixelScale > 10)
            {
                incramentValue = yPixelScale;
            } else
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
                if (nextDate.Second != recentDate.Second || nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day)
                {
                    return true;

                } else
                {
                    return false;
                }

            }
            else if (graphOption3Select.SelectedItem.Equals("Minutes"))
            {
                if (nextDate.Minute != recentDate.Minute || nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day)
                {
                    return true;

                } else
                {
                    return false;
                }

            }
            else if (graphOption3Select.SelectedItem.Equals("Hours"))
            {
                if (nextDate.Hour != recentDate.Hour || nextDate.Day != recentDate.Day)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            else if (graphOption3Select.SelectedItem.Equals("Days"))
            {
                if (nextDate.Day != recentDate.Day)
                {
                    return true;
                } else
                {
                   return false;
                }
            }

            return false;


        }

        // 7. TAKE THE GOOGLE DATA AND EXTRACT THE INFORMATION NECESSARY
        private List<dataPoint> decodeData(List<List<Object>> dataList)
        {
            int value;
            int i = 0;
             
            dataPoint dp;
            List<dataPoint> results = new List<dataPoint>();

            // THIS FUNCTION WILL NEED TO CHANGE ALOT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            foreach (List<object> data in dataList)
            {
                String fullDataValue = (String)data[1];
                String condensedData = fullDataValue.Substring(fullDataValue.LastIndexOf('-') + 1);

                value = Convert.ToInt32(condensedData);
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

            if (!graphUpdateDone)
            {
                if (takingDown)
                {
                    bool needToKeepGoing = false;

                    foreach (dataPoint dp in graphData.dataEntries)
                    {
                        if (dp.yValue != 0)
                        {
                            if((dp.yValue - incramentValue) < 0)
                            {
                                dp.yValue--;
                            } else
                            {
                                dp.yValue -= incramentValue;
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
                            if(graphData.dataEntries[i].yValue + incramentValue > targetGraph.dataEntries[i].yValue)
                            {
                                graphData.dataEntries[i].yValue++;
                            } else
                            {
                                graphData.dataEntries[i].yValue += incramentValue;
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

        // 9. DRAW THE GRAPH BEING STORED IN GLOBAL GRAPH OBJECT
        private void drawGraphData(PaintEventArgs e)
        {
            if (graphConfigured)
            {
                Rectangle rect;
                DateTime currDate;

                xAxisDataPoints.Clear();

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

                int currentSecondIndex = 0;
                int currentMinuteIndex = 0;
                int currentHourIndex = 0;
                int currentDayIndex = 0;

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
                                }
                            }
                            else if(graphData.timeInterval.Equals("hours") && (i % 24) == 0) 
                            {
                                   
                                currentDayIndex++;
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

                            if (firstTime)
                            {
                                currentMinuteIndex = currentDateMinute;
                                currentHourIndex = currentDateHour;
                                currentDayIndex = currentDateDay;
                                firstTime = false;
                            }

                            if (graphData.timeInterval == "seconds")
                            {
                                currentSecondIndex = currGraphIndex;

                                if (currentSecondIndex == currentDateSecond && currentMinuteIndex == currentDateMinute && currentHourIndex == currentDateHour
                                    && currentDayIndex == currentDateDay)
                                {
                                    dataPoint dp = graphData.dataEntries[dpIndex];


                                    // RECTANGLE
                                    if (graphData.graphType.Equals("bar"))
                                    {
                                        drawRectangle(dp, currXPixel, e);

                                    // LINE
                                    } else if (graphData.graphType.Equals("line"))
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

                                if(currentMinuteIndex == currentDateMinute && currentHourIndex == currentDateHour && currentDayIndex == currentDateDay)
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

                                if (currentHourIndex == currentDateHour && currentDayIndex == currentDateDay)
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

                                if (currentDayIndex == currentDateDay)
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
                            if(zoomLevel >= 17)
                            {
                                rect = new Rectangle(currXPixel + (((graphData.xInterval - (zoomLevel - 17)) / 2) - 1), graphDisplay.Height - 40, 1, 10);
                            } else
                            {
                                rect = new Rectangle(currXPixel + ((graphData.xInterval / 2) - 2), graphDisplay.Height - 40, 2, 10);
                            }
                            using (Pen pen = new Pen(System.Drawing.Color.Red, 2))
                            {
                                e.Graphics.DrawRectangle(pen, rect);
                            }


                            // TIMESTAMP ON X AXIS
                            int xIntervalCheckAmount; 
                            if(zoomLevel - 17 > 0)
                            {
                                xIntervalCheckAmount = zoomLevel - 17;
                            } else
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

    }
}
