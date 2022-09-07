using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ICE.Domain.Services;

namespace ICE.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            Dictionary<string, string> list = OperationService.GetOperations();

            var json = JsonConvert.SerializeObject(list);

            return json;
        }
    }
}
