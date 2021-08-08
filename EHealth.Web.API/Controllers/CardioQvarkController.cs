using EHealth.Application.Interfaces.CardioQvark;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EHealth.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardioQvarkController : ControllerBase
    {
        private readonly ICardioQvarkETL _etlService;

        public CardioQvarkController(ICardioQvarkETL etlService)
        {
            _etlService = etlService;
        }

        [HttpPost("ETL")]
        public async Task<IActionResult> ETL([FromBody] QueryParameters queryParameters)
        {
            await _etlService.Handle(queryParameters);

            return Ok();
        }
    }
}
