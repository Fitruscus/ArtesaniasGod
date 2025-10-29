using Microsoft.AspNetCore.Mvc;
using AutenticacionASPNET.Data;
using AutenticacionASPNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AutenticacionASPNET.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            return View(_context.Clientes.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id == null) return NotFound();
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id == null) return NotFound();
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id != cliente.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            if (id == null) return NotFound();
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return View("~/Views/Account/AccessDenied.cshtml");
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
