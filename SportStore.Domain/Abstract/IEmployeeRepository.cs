using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<employees> Employees { get; set; }
        IEnumerable<employee_notyfications> EmployeeNotyfications { get; set; }
        IEnumerable<genereted_register_keys> GeneretedRegisterKeys { get; set; }

        employees GetEmployeeModel(int id);
        bool CheckRegisterKey(decimal key);
        void RegisterEmployee(employees model);
        void SetUsedKey(int id);
    }
}
