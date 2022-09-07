namespace ICE.Domain.Interfaces
{
    public interface IOperationFactory
    {
        ICalc GetOperation(string type);
    }
}
