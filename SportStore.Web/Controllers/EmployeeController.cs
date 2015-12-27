using SportStore.Web.Models.Employee;
using System.Web.Mvc;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Kontroler pracowników
    /// Data:   20.11.15
    /// </summary>
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult Login()
        {
            return View();
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
    }
}