using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    public class ProductVersionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
