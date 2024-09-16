using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDSNformas
{
    class TriânguloEquilátero : Triângulo
    {
        public override double CalcularArea()
        {
            altura = _base * (Math.Sqrt(3)) / 2;
            return (_base * altura) / 2;
        }

        public override double CalcularPerímetro()
        {
            return _base * 3;
        }
        public override double CalcularHipotenusa()
        {
            return Math.Sqrt(Math.Pow(_base, 2) + Math.Pow(altura, 2));
        }
        public override string ToString()
        {
            return $"T.Equilátero({_base}, {altura})";
        }
    }
}
