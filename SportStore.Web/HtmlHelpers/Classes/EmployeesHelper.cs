using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Employee;
using System;
using System.Linq;
using System.Collections.Generic;
using SportStore.Web.Models.Catalog;
using System.Web;
using System.Text;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class EmployeesHelper : IEmployeesHelper
    {
        private IEmployeeRepository _employeeRepository { get; set; }
        private ICatalogsRepository _catalogRepository { get; set; }

        public EmployeesHelper(IEmployeeRepository employeeRepository, ICatalogsRepository catalogRespository)
        {
            _employeeRepository = employeeRepository;
            _catalogRepository = catalogRespository;
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

        IEnumerable<items> IEmployeesHelper.GetItems()
        {
            return _employeeRepository.Items;
        }

        Models.Employee.ItemModel IEmployeesHelper.GetItemById(int id)
        {
            var item = _catalogRepository.Items
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var itemPictures = _catalogRepository.ItemsPicture
                .Where(x => x.Id_Item == id);

            var itemQuantity = _catalogRepository.ItemsQuantity
                .Where(x => x.Id_Item == id);

            var itemDetails = _catalogRepository.ItemsDetails
                .Where(x => x.Id_Item == id)
                .FirstOrDefault();

            var itemDetailsSplit = itemDetails.Name.Split(new char[] { ';' });

            var modelToSend = new Models.Employee.ItemModel
            {
                Item = item,
                DetailsItem = itemDetailsSplit.ToList(),
                Pictures = itemPictures.ToList(),
                Quantity = itemQuantity.ToList(),
                SelectedCategory = item.Id_Category
            };

            return modelToSend;
        }

        void IEmployeesHelper.EditProduct(Models.Employee.ItemModel model, HttpFileCollectionBase files)
        {
            //item
            var item = new items
            {
                Id = model.Item.Id,
                Title = model.Item.Title,
                Id_Category = model.SelectedCategory,
                Description = model.Item.Description,
                Id_Description = model.Item.Id_Description,
                Price = model.Item.Price
            };

            //item details
            StringBuilder stringBulider = new StringBuilder();
            for (int i = 0; i < model.DetailsItem.Count; i++)
            {
                if (!String.IsNullOrEmpty(model.DetailsItem[i]))
                {
                    stringBulider.Append(model.DetailsItem[i]);
                    stringBulider.Append(";");
                }
            }
            stringBulider.Remove(stringBulider.Length - 1, 1);
            var itemDetails = new _dict_items_details
            {
                Id_Item = model.Item.Id,
                Name = stringBulider.ToString()
            };

            //item quantity
            List<items_quantity> itemQuantity = new List<items_quantity>();
            foreach(var quantity in model.Quantity)
            {
                itemQuantity.Add(
                    new items_quantity
                    {
                        Id = quantity.Id,
                        Id_Shop = quantity.Id_Shop,
                        Quantity = quantity.Quantity    
                });
            }

            //item pictures
            List<items_picutures> itemPictures = new List<items_picutures>();
            foreach(string file in files)
            {
                if (files[file].ContentType.Equals("image/jpeg"))
                {
                    var picture = new items_picutures();

                    picture.PictureMimeType = files[file].ContentType;
                    picture.PictureData = new byte[files[file].ContentLength];

                    files[file].InputStream.Read(picture.PictureData, 0, files[file].ContentLength);

                    var ids = file.Split(new char[] { '-' });
                    picture.Id = int.Parse(ids[1]);

                    itemPictures.Add(picture);
                }
            }

            _employeeRepository.EditProduct(item, itemPictures, itemDetails, itemQuantity);
        }

        Models.Employee.ItemModel IEmployeesHelper.GetEmptyItem()
        {
            var itemModel = new Models.Employee.ItemModel();

            var shops = _employeeRepository.DictShops
                .Select(x => x)
                .ToList();

            var quanList = new List<items_quantity>();
            foreach (var item in shops)
            {
                var q = new items_quantity();

                q.Id_Shop = item.Id;
                q.Quantity = 0;
                q.Shop = item;

                quanList.Add(q);
            }

            itemModel.Quantity = quanList;
            itemModel.DetailsItem = new List<string>();

            return itemModel;
        }

        void IEmployeesHelper.AddProduct(Models.Employee.ItemModel model, List<HttpPostedFileBase> files)
        {
            //items
            var product = new items
            {
                Title = model.Item.Title,
                Price = model.Item.Price,
                Id_Category = model.SelectedCategory,
                Description = model.Item.Description
            };

            //item details
            StringBuilder stringBulider = new StringBuilder();
            for (int i = 0; i < model.DetailsItem.Count; i++)
            {
                if (!String.IsNullOrEmpty(model.DetailsItem[i]))
                {
                    stringBulider.Append(model.DetailsItem[i]);
                    stringBulider.Append(";");
                }
            }
            stringBulider.Remove(stringBulider.Length - 1, 1);
            var itemDetails = new _dict_items_details
            {
                Name = stringBulider.ToString()
            };

            //item quantity
            List<items_quantity> itemQuantity = new List<items_quantity>();
            foreach (var quantity in model.Quantity)
            {
                itemQuantity.Add(
                    new items_quantity
                    {
                        Id_Shop = quantity.Id_Shop,
                        Quantity = quantity.Quantity
                    });
            }

            //item pictures
            List<items_picutures> itemPictures = new List<items_picutures>();
            foreach (var file in files)
            {
                if (file.ContentType.Equals("image/jpeg"))
                {
                    var picture = new items_picutures();
                    picture.PictureMimeType = file.ContentType;
                    picture.PictureData = new byte[file.ContentLength];
                    
                    file.InputStream.Read(picture.PictureData, 0, file.ContentLength);

                    itemPictures.Add(picture);
                }
            }

            _employeeRepository.AddProduct(product, itemPictures, itemDetails, itemQuantity);
        }

        IEnumerable<items_opinions> IEmployeesHelper.GetOpinions()
        {
            return _employeeRepository
                .ItemsOpinions
                .Select(x => x);
        }

        void IEmployeesHelper.DeleteOpinion(int id)
        {
            _employeeRepository.DeleteOpinion(id);
        }


        int IEmployeesHelper.GenerateKey()
        {
            Random rand = new Random();
            int registerKey;
            do
            {
                registerKey = rand.Next(1000, 9999);
            }
            while (!_employeeRepository.TrySaveGenerateKey(registerKey));

            return registerKey;
        }

        IEnumerable<genereted_register_keys> IEmployeesHelper.GetRegisterKeys()
        {
            return _employeeRepository.GeneretedRegisterKeys;
        }

        void IEmployeesHelper.DeleteKey(int id)
        {
            _employeeRepository.DeleteKey(id);
        }

        IEnumerable<clients> IEmployeesHelper.GetClients()
        {
            return  _employeeRepository.Clients;
        }

        clients IEmployeesHelper.GetClientById(int id)
        {
            return _employeeRepository.GetClientById(id);
        }

        bool IEmployeesHelper.TryDeleteClient(int id)
        {
            var result = _employeeRepository.TryDeleteClient(id);

            if (result)
                return true;
            else
                return false;
        }

        IEnumerable<employees> IEmployeesHelper.GetEmployees()
        {
            return _employeeRepository.Employees;
        }

        void IEmployeesHelper.MakeAdmin(int id)
        {
            _employeeRepository.MakeAdmin(id);
        }

        void IEmployeesHelper.DeleteAdmin(int id)
        {
            _employeeRepository.DeleteAdmin(id);
        }

        DonautChartModel IEmployeesHelper.GetStatistic()
        {
            var dbData = _employeeRepository.GetStats();

            DonautChartModel model = new DonautChartModel
            {
                NewComment = dbData[0],
                NewOrders = dbData[1],
                NewNewsletters = dbData[2],
                UnusedKeys = dbData[3]
            };

            return model;
        }

        IEnumerable<orders> IEmployeesHelper.GetOrders()
        {
            return _employeeRepository.Orders;
        }

        void IEmployeesHelper.ChangeOrderStatus(int orderId, int statusId)
        {
            _employeeRepository.changeOrderStatus(orderId, statusId);
        }

        void IEmployeesHelper.DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        void IEmployeesHelper.DeleteOrder(int orderId)
        {
            _employeeRepository.DeleteOrder(orderId);
        }

        void IEmployeesHelper.DeleteItem(int id)
        {
            _employeeRepository.DeleteItem(id);
        }
    }
}