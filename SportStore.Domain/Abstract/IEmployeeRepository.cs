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
        IEnumerable<clients> Clients { get; set; }
        IEnumerable<employee_notyfications> EmployeeNotyfications { get; set; }
        IEnumerable<genereted_register_keys> GeneretedRegisterKeys { get; set; }
        IEnumerable<items> Items { get; set; }
        IEnumerable<items_opinions> ItemsOpinions { get; set; }
        IEnumerable<_dict_shops> DictShops { get; set;}
        IEnumerable<genereted_register_keys> RegisterKeys { get; set; }

        bool TryDeleteClient(int id);
        void DeleteKey(int id);
        bool TrySaveGenerateKey(int code);
        employees GetEmployeeModel(int id);
        void DeleteOpinion(int id);
        bool CheckRegisterKey(decimal key);
        void RegisterEmployee(employees model);
        void SetUsedKey(int id);
        void AddProduct(items item, List<items_picutures> itemPictures, _dict_items_details itemDetails, List<items_quantity> itemQuantity);
        void EditProduct(items item, List<items_picutures> itemPictures, _dict_items_details itemDetial, List<items_quantity> itemQuantity);
        clients GetClientById(int id);
    }
}
