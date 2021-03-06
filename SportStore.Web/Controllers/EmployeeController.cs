﻿using SportStore.Domain.Abstract;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Infrastructure;
using SportStore.Web.Models.Employee;
using System.Net;
using System.Net.Mime;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Domain.Entities;

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
        private IOrderHelper _orderHelper { get; set; }
        public EmployeeController(IEmployeesHelper employeesHelper, IDictionaryRepository dictionaryRepository, IOrderHelper orderHelper)
        {
            _employeesHelper = employeesHelper;
            _dictionaryRepository = dictionaryRepository;
            _orderHelper = orderHelper;
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

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult CatalogAdd(string catalogName)
        {
            _dictionaryRepository.AddCatalog(catalogName);

            return Json(new { succes = true, data = "Poprawnie dodano " + catalogName }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult CatalogDelete(int id)
        { 
            if (_dictionaryRepository.DeleteCatalog(id))
            {
                return Json(new { succes = true, data = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("", MediaTypeNames.Text.Plain);
            }
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult ItemsManagment()
        {
            return View(_employeesHelper.GetItems());
        }

        [Authorize]
        [EmployeeAuthentication]
        [HttpGet]
        public ActionResult ItemsEdit(int id)
        {
            var catalogs = _dictionaryRepository.DictCatalogs;
            var list = new List<SelectListItem>();

            foreach (var item in catalogs)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Catalogs = list;
            return View(_employeesHelper.GetItemById(id));
        }

        [Authorize]
        [EmployeeAuthentication]
        [HttpPost]
        public ActionResult ItemsEdit(ItemModel model)
        {
            _employeesHelper.EditProduct(model, Request.Files);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie zmodyfikowano produkt!");

            return RedirectToAction("ItemsManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult ItemAdd()
        {
            var catalogs = _dictionaryRepository.DictCatalogs;
            var list = new List<SelectListItem>();

            foreach (var item in catalogs)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Catalogs = list;

            return View(_employeesHelper.GetEmptyItem());
        }

        [Authorize]
        [EmployeeAuthentication]
        [HttpPost]
        public ActionResult ItemAdd(ItemModel model, List<HttpPostedFileBase> fileUpload)
        {
            _employeesHelper.AddProduct(model, fileUpload);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie dodano produkt!");

            return RedirectToAction("ItemsManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult DeleteItem(int id)
        {
            _employeesHelper.DeleteItem(id);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie usunięto produkt!");

            return RedirectToAction("ItemsManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult Opinions()
        {
            return View(_employeesHelper.GetOpinions());
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult DeleteOpinion(int id)
        {
            _employeesHelper.DeleteOpinion(id);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie usunięto opinię!");

            return RedirectToAction("Opinions");
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult GenerateRegisterKey()
        {
            int generateCode = _employeesHelper.GenerateKey();

            return Json(generateCode, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult RegisterKeys()
        {
            return View(_employeesHelper.GetRegisterKeys());
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult DeleteKey(int id)
        {
            _employeesHelper.DeleteKey(id);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie usunięto kod!");

            return RedirectToAction("RegisterKeys");
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult ClientManagment()
        {
            return View(_employeesHelper.GetClients());
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult ClientDetail(int id)
        {
            return View(_employeesHelper.GetClientById(id));
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult ClientDelete(int id)
        {
            var result = _employeesHelper.TryDeleteClient(id);

            if (result)
                TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie usunięto klienta!");
            else
                TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Danger, "Brak możliwości usunięcia! Klient posiada aktywne zamówienia!");

            return RedirectToAction("ClientManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult EmployeeManagment()
        {
            return View(_employeesHelper.GetEmployees());
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult DeleteEmployee(int id)
        {
            var seesion = Session["Employee"] as employees;

            if (seesion.Id == id)
            {
                TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Danger, "Nie możesz usunąć samego siebie!");
            }
            else
            {
                _employeesHelper.DeleteEmployee(id);
                TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie usunięto pracownika!");
            }

            return RedirectToAction("EmployeeManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult MakeAdmin(int id)
        {
            _employeesHelper.MakeAdmin(id);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie nadano uprawnienia!");

            return RedirectToAction("EmployeeManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        [OnlyAdmin]
        public ActionResult DeleteAdmin(int id)
        {
            var session = Session["Employee"] as employees;

            if (session.Id == id)
            {
                TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Danger, "Nie możesz sam sobie odebrać uprawnień!");
            }
            else
            {
                _employeesHelper.DeleteAdmin(id);
                TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie odebrano uprawnienia!");
            }

            return RedirectToAction("EmployeeManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult Stats()
        {
            return View(_employeesHelper.GetStatistic());
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult OrderManagment()
        {
            var dictStatus = _dictionaryRepository.DictStatusOrders;
            var list = new List<SelectListItem>();

            foreach (var item in dictStatus)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Status = list;
            return View(_employeesHelper.GetOrders());
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult DeleteOrder(int id)
        {
            _employeesHelper.DeleteOrder(id);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie usnięto zamówienie!");

            return RedirectToAction("OrderManagment");
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult OrderDetail(int id)
        {
            return View(_orderHelper.GetPDF(id));
        }

        [Authorize]
        [EmployeeAuthentication]
        public ActionResult ChangeOrderStatus(int id, int newStatus)
        {
            _employeesHelper.ChangeOrderStatus(id, newStatus);
            TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Succes, "Poprawnie zmieniono status!");

            return Json(new { success = true, data = "" }, JsonRequestBehavior.AllowGet);
        }
    }
}