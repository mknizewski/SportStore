using SportStore.Domain.Abstract;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Infrastructure;
using SportStore.Web.Models.Employee;
using System.Web.Mvc;
using System.Web.Security;

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
        private IEmployeesHelper _employeesHelper { get; set; }
        private IDictionaryRepository _dictionaryRepository { get; set; }
        public EmployeeController(IEmployeesHelper employeesHelper, IDictionaryRepository dictionaryRepository)
        {
            _employeesHelper = employeesHelper;
            _dictionaryRepository = dictionaryRepository;
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (_employeesHelper.CheckLogin(loginModel))
            {
                FormsAuthentication.SetAuthCookie(loginModel.Login, false);
                var model = _employeesHelper.GetEmployeeModel(loginModel);

                this.Session["Employee"] = model;

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło!");
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            registerModel.Login += "@SportStore.pl";
            if (_employeesHelper.RegisterEmployee(registerModel))
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Podany kod rejestracyjny nie istnieje albo został wygaszony!");
                return View();
            }
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult CatalogManagment()
        {
            return View(_dictionaryRepository.DictCatalogs);
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult CatalogEdit(int id, string name)
        {
            _dictionaryRepository.ChangeCatalogName(id, name);

            return Json(new { succes = true, responseText = "Poprawnie wprowadzono zmiany" }, JsonRequestBehavior.AllowGet);
        }
    }
}