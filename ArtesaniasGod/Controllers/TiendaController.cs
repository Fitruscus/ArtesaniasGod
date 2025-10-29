using Microsoft.AspNetCore.Mvc;
using AutenticacionASPNET.Data;
using AutenticacionASPNET.Models;
using Microsoft.EntityFrameworkCore;

namespace AutenticacionASPNET.Controllers
{
    public class TiendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        public IActionResult Detalle(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();
            return View(producto);
        }
    }
}
