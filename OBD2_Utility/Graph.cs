using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBD2_Utility
{
    public class Graph
    {
        public String graphType;
        public int xStart;
        public int xEnd;
        public int xNum;
        public int xInterval;
        public int yStart;
        public int yEnd;
        public int yNum;
        public int yInterval;
        public List<DateTime> dates;
        public String timeInterval;

        public List<dataPoint> dataEntries; 

        // Default Constructor
        public Graph()
        {
            graphType = "";
            xStart = 0;
            xEnd = 0;
            xNum = 0;
            xInterval = 0;
            yStart = 0;
            yEnd = 0;
            yNum = 0;
            yInterval = 0;
            dates = new List<DateTime>();
            timeInterval = "";

            dataEntries = new List<dataPoint>();

        }

        // Specific Constructor
        public Graph(String _graphType, int _xStart, int _xEnd, int _xInterval, int _xNum, String _timeInterval, 
            int _yStart, int _yEnd, int _yNum, int _yInterval, 
            List<dataPoint> _dataEntries, List<DateTime> _dates)
        {
            graphType = _graphType;
            xStart = _xStart;
            xEnd = _xEnd;
            xNum = _xNum;
            xInterval = _xInterval;
            yStart = _yStart;
            yEnd = _yEnd;
            yNum = _yNum;
            yInterval = _yInterval;
            dataEntries = _dataEntries;
            dates = _dates;
            timeInterval = _timeInterval;
        }


        // IF WE WANT TO MAKE THE CLASS PRIVATE
        // GETTERS AND SETTERS
        //public void setGraphType(String _graphType)
        //{
        //    graphType = _graphType;
        //}
        //public String getGraphType()
        //{
        //    return graphType;
        //}

        //public void setXNum(int _xNum)
        //{
        //    xNum = _xNum;
        //}
        //public int getXNum()
        //{
        //    return xNum;
        //}

        //public void setYNum(int _yNum)
        //{
        //    yNum = _yNum;
        //}
        //public int getYNum()
        //{
        //    return yNum;
        //}

        //public void setXInterval(int _xInterval)
        //{
        //    xInterval = _xInterval;
        //}
        //public int getXInterval()
        //{
        //    return xInterval;
        //}

        //public void setYInterval(int _yInterval)
        //{
        //    yInterval = _yInterval;
        //}
        //public int getYInterval()
        //{
        //    return yInterval;
        //}



    }
}
