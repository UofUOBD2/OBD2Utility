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
        public int xNum;
        public int yNum;
        public int xInterval;
        public int yInterval;

        public List<dataPoint> dataEntries; 

        // Default Constructor
        public Graph()
        {
            graphType = "";
            xNum = 0;
            yNum = 0;
            xInterval = 0;
            yInterval = 0;

            dataEntries = new List<dataPoint>();

        }

        // Specific Constructor
        public Graph(String _graphType, int _xNum, int _yNum, int _xInterval, int _yInterval, List<dataPoint> _dataEntries)
        {
            graphType = _graphType;
            xNum = _xNum;
            yNum = _yNum;
            xInterval = _xInterval;
            yInterval = _yInterval;
            dataEntries = _dataEntries;
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
