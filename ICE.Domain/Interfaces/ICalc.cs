namespace ICE.Domain.Interfaces
{
    public interface ICalc
    {
        double Calc(double x, double y);

        string GetSign();

        string GetName();
    }
}
