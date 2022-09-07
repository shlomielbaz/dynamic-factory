using ICE.Domain.Classes;
using ICE.Domain.Interfaces;
using ICE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Domain.Services
{
    public class OperationService
    {
        private readonly OperationFactory factory;

        public OperationService(OperationFactory factory)
        {
            this.factory = factory;
        }

        public ICalc GetOperation(string type)
        {
            try
            {
                return factory.GetOperation(type) ?? null;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static Dictionary<string, string> GetOperations()
        {
            Dictionary<string, string> list = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => typeof(ICalc).IsAssignableFrom(p) && p.IsClass && !p.IsInterface && !p.IsAbstract)
            .Select(t => (ICalc)Activator.CreateInstance(t))
            .ToDictionary(x => x.GetSign(), x => x.GetName());


            return list;
        }
    }
}
