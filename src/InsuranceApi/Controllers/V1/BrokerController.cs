using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    public class BrokerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
