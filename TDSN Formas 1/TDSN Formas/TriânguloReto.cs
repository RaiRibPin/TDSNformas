using System;

namespace TDSNformas
{
    class TriânguloReto : Triângulo
    {
        public override double CalcularArea()
        {
           return (_base * altura) / 2;
        }
        public override double CalcularHipotenusa()
        {
            return Math.Sqrt(Math.Pow(_base, 2) + Math.Pow(altura, 2));
        }
        public override double CalcularPerímetro()
        {
            return _base + altura + CalcularHipotenusa();
        }
        
        public override string ToString()
        {
            return $"T.Reto({_base}, {altura})";
        }
    }
}
