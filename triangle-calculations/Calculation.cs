using System;
using System.Collections.Generic;
using System.Text;

namespace triangle_calculations
{
    public abstract class Calculation
    {
        private string _timestamp;

        public Calculation()
        {
            DateTime now = DateTime.Now;
            _timestamp = now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string Timestamp
        {
            get
            {
                return _timestamp;
            }
        }

        public abstract string Result { get; }

        public abstract string Summary { get; }
    }
}
