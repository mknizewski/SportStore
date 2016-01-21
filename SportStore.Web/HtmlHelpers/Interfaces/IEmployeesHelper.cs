using SportStore.Domain.Entities;
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
        employees GetEmployeeModel(LoginModel model);
        bool RegisterEmployee(RegisterModel model);
        IEnumerable<items> GetItems();
        ItemModel GetItemById(int id);
        void AddProduct(ItemModel model, List<HttpPostedFileBase> files);
        void EditProduct(ItemModel model, HttpFileCollectionBase files);
        void DeleteOpinion(int id);
        IEnumerable<items_opinions> GetOpinions();
        ItemModel GetEmptyItem();
    }
}
