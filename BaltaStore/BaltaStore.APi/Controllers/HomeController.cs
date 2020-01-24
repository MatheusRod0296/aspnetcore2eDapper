using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.APi.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        [Route("Homes")]
        public string Get(){
            return "Hello world";
        }

        [HttpPost]
        [Route("Homes")]
        public string Post(){
            return "Hello world";
        }
    }
}