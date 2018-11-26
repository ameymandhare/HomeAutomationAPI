using HomeAutomation.BLL.Services;
using HomeAutomation.Common.Entity;
using System.Net;
using System.Web.Http;

namespace HomeAutomation.Controllers
{
    public class ClientController : ApiController
    {
        public readonly UserService userService;

        public ClientController()
        {
            this.userService = new UserService();
        }

        [Route("api/Client/Authenticate")]
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody]Authentication authInfo)
        {
            var result = userService.Authenticate(authInfo);
            return Ok(result);
        }
    }
}
