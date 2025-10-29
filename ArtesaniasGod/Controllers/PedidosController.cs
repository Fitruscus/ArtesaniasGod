using Microsoft.AspNetCore.Mvc;

namespace AutenticacionASPNET.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
