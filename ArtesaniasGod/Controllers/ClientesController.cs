using Microsoft.AspNetCore.Mvc;

namespace AutenticacionASPNET.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
