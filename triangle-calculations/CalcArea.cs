using System;
using System.Collections.Generic;
using System.Text;

namespace triangle_calculations
{
    public class CalcArea : Calculation
    {
        private double _base;
        private double _height;
        private double _area;

        public CalcArea(double baseT, double heightT)
        {
            _base = baseT;
            _height = heightT;
            _area = 0.5 * _base * _height;
            _area = Math.Round(_area, 2);
        }

        public override string Result
        {
            get
            {
                return _area.ToString();
            }
        }

        public override string Summary
        {
            get
            {
                return $"Area of Triangle\nGiven:\nBase: {_base}\nHeight: {_height}\nCalculated:\nArea = {Result}";
            }
        }
    }
}
