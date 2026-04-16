using Microsoft.AspNetCore.Mvc;
using SistemaCompras.Data;
using System.Linq;

namespace SistemaCompras.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName, string password)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.UserName == userName && u.Password == password);

            if (usuario != null)
            {
                HttpContext.Session.SetString("usuario", usuario.UserName);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
