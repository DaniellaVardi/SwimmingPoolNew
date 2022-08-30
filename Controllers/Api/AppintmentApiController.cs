
using Microsoft.AspNetCore.Mvc;
using SwimmingPoolNew.Services;

namespace SwimmingPoolNew.Controllers.Api
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppintmentApiController : Controller
    {
        private readonly IAppintmentServices _appintmentService;

        public AppintmentApiController(IAppintmentServices appintmentService)
        {
            _appintmentService = appintmentService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}

