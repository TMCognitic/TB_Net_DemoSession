using DemoSession.Infrastructure;
using DemoSession.Models;
using DemoSession.Models.Sessions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, SessionManager sessionManager)
        {
            _logger = logger;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _sessionManager.User = new SessionUser() { Id = 1, Email = "thierry.morre@cognitic.be" };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}