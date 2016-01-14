using SportStore.Web.Infrastructure;
using SportStore.Web.Models.Employee;
using System.Web.Mvc;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Kontroler pracowników
    /// Data:   20.11.15
    /// </summary>
    [RedirectClient]
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee
        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            return View();
        }
    }
}