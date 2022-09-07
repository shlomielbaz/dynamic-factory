using Microsoft.AspNetCore.Mvc;
using ICE.Domain.Classes;
using ICE.Domain.Models;
using ICE.Domain.Services;

namespace ICE.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly OperationService service;

        public CalcController(OperationService service)
        {
            this.service = service;
        }

        // POST api/<CalcController>
        [HttpPost]
        public double Post(OperationDTO model)
        {
            try
            {
                return this.service.GetOperation(model.op)?.Calc(model.x, model.y) ?? 0;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
