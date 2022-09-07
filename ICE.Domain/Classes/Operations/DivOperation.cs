using ICE.Domain.Interfaces;

namespace ICE.Domain.Classes.Operations
{
    public class DivOperation : ICalc
    {
        public double Calc(double x, double y)
        {
            if (y == 0)
            {
                throw new ArgumentException("Cannot divide by zero");
            }

            return x / y;
        }

        public string GetSign()
        {
            return "/";
        }

        public string GetName()
        {
            return "Division";
        }
    }
}
