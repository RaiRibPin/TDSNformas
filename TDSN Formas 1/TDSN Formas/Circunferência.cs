using System;
namespace TDSNformas
{
    class Circunferência : FormaGeometrica
    {
        private double raio;

        public double Raio
        {
            get { return raio; }
            set { raio = value; }
        }

        public override double CalcularPerímetro()
        {
            return raio * 2 * 3.14;
        }
        public override double CalcularArea()
        {
            return 3.14 * Math.Pow(raio,2);
        }
        public override string ToString()
        {
            return $"Circunferência({raio})";
        }
    }
}
