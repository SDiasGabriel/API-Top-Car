using API_Top_Car.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Top_Car.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ApoliceModel>> BuscarTodasApolice()
        {
            return Ok();
        }
    }
}
