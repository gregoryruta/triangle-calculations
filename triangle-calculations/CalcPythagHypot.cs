using System;
using System.Collections.Generic;
using System.Text;

namespace triangle_calculations
{
    public class CalcPythagHypot : Calculation
    {
        private double _sideA;
        private double _sideB;
        private double _hypotenuse;

        public CalcPythagHypot(double sideA, double sideB)
        {
            _sideA = sideA;
            _sideB = sideB;
            _hypotenuse = Math.Sqrt(Math.Pow(_sideA, 2) + Math.Pow(_sideB, 2));
            _hypotenuse = Math.Round(_hypotenuse, 2);
        }

        public override string Result
        {
            get
            {
                return _hypotenuse.ToString();
            }
        }

        public override string Summary
        {
            get
            {
                return $"Pythagoraus Theorum\nGiven:\nSide A: {_sideA}\nSide B: {_sideB}\nCalculated:\nHypotenuse = {Result}";
            }
        }
    }
}
