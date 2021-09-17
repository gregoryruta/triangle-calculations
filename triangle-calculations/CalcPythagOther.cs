using System;
using System.Collections.Generic;
using System.Text;

namespace triangle_calculations
{
    public class CalcPythagOther : Calculation
    {
        private double _hypotenuse;
        private double _sideA;
        private double _sideB;

        public CalcPythagOther(double hypotenuse, double otherSideA)
        {
            _hypotenuse = hypotenuse;
            _sideA = otherSideA;
            _sideB = Math.Sqrt(Math.Pow(_hypotenuse, 2) - Math.Pow(_sideA, 2));
            _sideB = Math.Round(_sideB, 2);
        }

        public override string Result
        {
            get
            {
                return _sideB.ToString();
            }
        }

        public override string Summary
        {
            get
            {
                return $"Pythagoraus Theorum\nGiven:\nHypotenuse: {_hypotenuse}\nSide A: {_sideA}\nCalculated:\nSide B = {Result}";
            }
        }
    }
}
