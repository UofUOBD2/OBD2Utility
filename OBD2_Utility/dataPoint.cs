using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBD2_Utility
{
    public class dataPoint
    {

        public String name;
        public String color;
        public int yValue;
        public int xValue;

        // Wazza 2

        public dataPoint()
        {
            name = "";
            color = "";
            yValue = 0;
            xValue = 0;
        } 

        public dataPoint(String _name, String _color, int _yValue, int _xValue)
        {
            name = _name;
            color = _color;
            yValue = _yValue;
            xValue = _xValue;
        }



    }
}
