﻿using SportStore.Domain.Entities;
using SportStore.Web.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface IEmployeesHelper
    {
        bool CheckLogin(LoginModel model);
        bool TryDeleteClient(int id);
        employees GetEmployeeModel(LoginModel model);
        bool RegisterEmployee(RegisterModel model);
        IEnumerable<items> GetItems();
        IEnumerable<genereted_register_keys> GetRegisterKeys();
        IEnumerable<clients> GetClients();
        clients GetClientById(int id);
        ItemModel GetItemById(int id);
        void AddProduct(ItemModel model, List<HttpPostedFileBase> files);
        void EditProduct(ItemModel model, HttpFileCollectionBase files);
        void DeleteOpinion(int id);
        int GenerateKey();
        void DeleteKey(int id);
        IEnumerable<items_opinions> GetOpinions();
        ItemModel GetEmptyItem();
    }
}
