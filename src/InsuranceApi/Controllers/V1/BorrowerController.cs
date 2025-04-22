using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    public class BorrowerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
