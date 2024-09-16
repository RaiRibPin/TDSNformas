using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACACO
{
    abstract class Triangulo : FormaGeometrica
    {
        private double _base, altura;

        public double Base
        {
            get { return _base; }
            set { _base = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        public override double CalcularArea()
        {
            return _base * altura;
        }
        public override double CalcularPerimetro()
        {
            return (_base * 2) + (altura * 2);
        }
    }
}
