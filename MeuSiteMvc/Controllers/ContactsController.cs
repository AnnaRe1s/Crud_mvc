using Microsoft.AspNetCore.Mvc;

namespace MeuSiteMvc.Controllers
{

    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult DeletConfirmation()
        {
            return View();
        }

        public IActionResult Delete() {
            return Ok();
        }
    }
}
