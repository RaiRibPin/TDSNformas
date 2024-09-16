namespace TDSNformas
{
    abstract class Triângulo : FormaGeometrica
    {
        protected double _base;

        public double Base
        {
            get { return _base; }
            set { _base = value; }
        }

        protected double altura;

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        public abstract double CalcularHipotenusa();
    }
}
