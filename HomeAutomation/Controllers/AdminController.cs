using HomeAutomation.BLL.Services;
using HomeAutomation.Common.Entity;
using System.Net;
using System.Web.Http;

namespace HomeAutomation.Controllers
{
    public class AdminController : ApiController
    {
        public readonly UserService userService;
        public readonly DeviceService deviceService;

        public AdminController()
        {
            this.userService = new UserService();
            this.deviceService = new DeviceService();
        }

        [Route("api/Admin/Register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody]Consumer Consumer)
        {
            var isSuccess = userService.RegisterUser(Consumer);
            if (isSuccess)
                return Ok("User registered succefully.");
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }

        [Route("api/Admin/UpdatePublicIp")]
        [HttpPost]
        public IHttpActionResult UpdatePublicIp([FromBody]Device device)
        {
            var isSuccess = deviceService.UpdatePublicIp(device);
            if (isSuccess)
                return Ok("Ip Updated succefully.");
            else
                return StatusCode(HttpStatusCode.NotFound);
        }

        [Route("api/Admin/GetDeviceInfo")]
        [HttpPost]
        public IHttpActionResult GetDeviceInfo([FromBody]string MacId)
        {
            var result = deviceService.GetDeviceInfo(MacId);
            return Ok(result);
        }
    }
}
