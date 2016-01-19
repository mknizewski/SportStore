using SportStore.Domain.Entities;
using SportStore.Web.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface IEmployeesHelper
    {
        bool CheckLogin(LoginModel model);
        employees GetEmployeeModel(LoginModel model);
        bool RegisterEmployee(RegisterModel model);
    }
}
