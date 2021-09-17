using System;
using System.Collections.Generic;
using System.Text;

namespace triangle_calculations
{
    public class CalcPerimeter : Calculation
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;
        private double _perimeter;

        public CalcPerimeter(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            _perimeter = _sideA + _sideB + _sideC;
            _perimeter = Math.Round(_perimeter, 2);
        }

        public override string Result
        {
            get
            {
                return _perimeter.ToString();
            }
        }

        public override string Summary
        {
            get
            {
                return $"Perimeter of Triangle\nGiven:\nSide A: {_sideA}\nSide B: {_sideB}\nSide C: {_sideC}\nCalculated:\nPerimeter = {Result}";
            }
        }
    }
}
