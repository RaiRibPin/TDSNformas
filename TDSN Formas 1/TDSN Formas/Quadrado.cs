namespace TDSNformas
{
    class Quadrado : FormaGeometrica
    {
        private double lado;

        public double Lado
        {
            get { return lado; }
            set { lado = value; }
        }

        public override double CalcularArea()
        {
            return System.Math.Pow(lado, 2);
        }

        public override double CalcularPerímetro()
        {
            return lado * 4;
        }
        public override string ToString()
        {
            return $"Quadrado({lado})";
        }
    }
}
