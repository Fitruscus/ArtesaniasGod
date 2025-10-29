using Microsoft.AspNetCore.Mvc;
using AutenticacionASPNET.Data;
using AutenticacionASPNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AutenticacionASPNET.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            var pedidos = _context.Pedidos.Include(p => p.Cliente).ToList();
            return View(pedidos);
        }

        public IActionResult Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id == null) return NotFound();
            var pedido = _context.Pedidos.Include(p => p.Cliente).Include(p => p.Detalles).ThenInclude(d => d.Producto).FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound();
            return View(pedido);
        }

        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            ViewBag.Clientes = _context.Clientes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedido pedido)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (ModelState.IsValid)
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Clientes.ToList();
            return View(pedido);
        }

        public IActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id == null) return NotFound();
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return NotFound();
            ViewBag.Clientes = _context.Clientes.ToList();
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pedido pedido)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id != pedido.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(pedido);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Clientes.ToList();
            return View(pedido);
        }

        public IActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id == null) return NotFound();
            var pedido = _context.Pedidos.Include(p => p.Cliente).FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound();
            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
