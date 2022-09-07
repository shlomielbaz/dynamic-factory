using ICE.Domain.Interfaces;

namespace ICE.Domain.Classes.Operations
{
    public class MulOperation : ICalc
    {
        public double Calc(double x, double y)
        {
            return x * y;
        }

        public string GetSign()
        {
            return "*";
        }

        public string GetName()
        {
            return "Multiplication";
        }
    }
}
