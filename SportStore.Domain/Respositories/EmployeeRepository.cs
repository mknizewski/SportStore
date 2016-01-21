using SportStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;
using SportStore.Domain.Concrete;

namespace SportStore.Domain.Respositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EFDbContext _context = new EFDbContext();
        IEnumerable<employee_notyfications> IEmployeeRepository.EmployeeNotyfications
        {
            get
            {
                return _context.EmployeeNotyfications;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<employees> IEmployeeRepository.Employees
        {
            get
            {
                return _context.Employees;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<genereted_register_keys> IEmployeeRepository.GeneretedRegisterKeys
        {
            get
            {
                return _context.GeneretedRegisterKeys;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<items> IEmployeeRepository.Items
        {
            get
            {
                return _context.Items;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        bool IEmployeeRepository.CheckRegisterKey(decimal key)
        {
            throw new NotImplementedException();
        }

        employees IEmployeeRepository.GetEmployeeModel(int id)
        {
            return _context.Employees
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();
        }

        void IEmployeeRepository.RegisterEmployee(employees model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
        }

        void IEmployeeRepository.SetUsedKey(int id)
        {
            var item = _context.GeneretedRegisterKeys.Find(id);
            item.IsUsed = true;

            _context.SaveChanges();
        }
    }
}
