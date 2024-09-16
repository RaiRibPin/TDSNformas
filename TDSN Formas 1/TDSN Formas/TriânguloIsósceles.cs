using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDSNformas
{
    class TriânguloIsósceles : Triângulo
    {
        private double lado;
        public double Lado
        {
            get { return lado; }
            set { lado = value; }
        }

        public override double CalcularArea()
        {
            altura = Math.Sqrt((Math.Pow(lado, 2)) - (Math.Pow((_base / 2), 2)));
            return (_base * altura) / 2;
        }
        public override double CalcularPerímetro()
        {
            return (lado * 2) + _base;
        }
        public override double CalcularHipotenusa()
        {
            return lado;
        }
        public override string ToString()
        {
            return $"T.Isósceles({lado}, {_base})";
        }
    }
}
