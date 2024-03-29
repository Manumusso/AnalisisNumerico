﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico.BackEnd
{
    public class ParametrosEcuaciones
    {
        public int NumIncognitas { get; set; }
        public List<double> Coeficientes { get; set; }
        public double Tolerancia { get; set; }
        public int Iteraciones { get; set; }

        public ParametrosEcuaciones()
        {
            this.Coeficientes = new List<double>();
        }
    }
}
