using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TNTA_TEST.Models;

namespace TNTA_TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
