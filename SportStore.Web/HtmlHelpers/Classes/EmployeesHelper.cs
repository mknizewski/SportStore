using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Employee;
using System;
using System.Linq;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class EmployeesHelper : IEmployeesHelper
    {
        private IEmployeeRepository _employeeRepository { get; set; }

        public EmployeesHelper(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        bool IEmployeesHelper.CheckLogin(LoginModel model)
        {
            var dbEmployee = _employeeRepository.Employees
                .Where(x => x.Email.Equals(model.Login))
                .FirstOrDefault();

            if (dbEmployee != null)
            {
                var decryptedPassword = PasswordHelper.Decrypt(dbEmployee.Password);

                if (String.Equals(decryptedPassword, model.Password))
                    return true;
            }

            return false;
        }

        employees IEmployeesHelper.GetEmployeeModel(LoginModel model)
        {
            var dbEmployee = _employeeRepository.Employees
                .Where(x => x.Email.Equals(model.Login))
                .FirstOrDefault();

            return dbEmployee;
        }

        bool IEmployeesHelper.RegisterEmployee(RegisterModel model)
        {
            var registeredKey = _employeeRepository.GeneretedRegisterKeys
                .Where(x => x.RegisterPin == model.RegisterKey)
                .FirstOrDefault();

            if (registeredKey != null)
            {
                if (registeredKey.IsUsed != true)
                {
                    if (registeredKey.ExpirationDate >= DateTime.Now)
                    {
                        var modelToSave = new employees
                        {
                            Email = model.Login,
                            Password = PasswordHelper.Encrypt(model.Password),
                            Name = model.Name,
                            Surname = model.Surname,
                            Id_Rule = (int)Rules.Employee
                        };

                        _employeeRepository.RegisterEmployee(modelToSave);
                        _employeeRepository.SetUsedKey(registeredKey.Id);

                        return true;
                    }
                }
            }
            return false;
        }
    }
}