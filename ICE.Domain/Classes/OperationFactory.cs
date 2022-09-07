using ICE.Domain.Interfaces;

namespace ICE.Domain.Classes
{
    public class OperationFactory: IOperationFactory
    {
        public ICalc GetOperation(string type)
        {
            ICalc operation = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(ICalc).IsAssignableFrom(p) && p.IsClass && !p.IsInterface && !p.IsAbstract)
                .Select(t => (ICalc)Activator.CreateInstance(t))
                .FirstOrDefault(x => x.GetSign() == type);

            if (operation == null)
            {
                throw new Exception("Operation not suported");
            }

            return operation;
        }
    }
}
