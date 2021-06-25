using Microsoft.AspNetCore.Mvc;

namespace BackEndPreguntas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //GET
        [HttpGet]
        public string Get() {
            return "API RUN............................................................................";
        }
    }
}
