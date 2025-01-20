using Microsoft.AspNetCore.Mvc;

namespace wellcomePGSEZ.Controllers.Account
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
