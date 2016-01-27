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

        IEnumerable<clients> IEmployeeRepository.Clients
        {
            get
            {
                return _context.Clients;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_shops> IEmployeeRepository.DictShops
        {
            get
            {
                return _context.DictShops;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

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

        IEnumerable<items_opinions> IEmployeeRepository.ItemsOpinions
        {
            get
            {
                return _context.ItemsOpinions;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<orders> IEmployeeRepository.Orders
        {
            get
            {
                return _context.Orders;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<genereted_register_keys> IEmployeeRepository.RegisterKeys
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

        void IEmployeeRepository.AddProduct(items item, List<items_picutures> itemPictures, _dict_items_details itemDetails, List<items_quantity> itemQuantity)
        {
            var desc = new _dict_description_items();
            desc.Name = item.Description.Name;
            desc.InsertTime = DateTime.Now;
            _context.DictDescriptionItems.Add(desc);

            item.Description = null;
            item.Id_Description = desc.Id;
            _context.Items.Add(item);

            itemDetails.Id_Item = item.Id;
            itemDetails.InsertTime = DateTime.Now;
            _context.DictItemsDetails.Add(itemDetails);

            foreach(var picture in itemPictures)
            {
                picture.Id_Item = item.Id;
                _context.ItemsPictures.Add(picture);
            }

            foreach(var q in itemQuantity)
            {
                q.Id_Item = item.Id;
                _context.ItemsQuantity.Add(q);
            }

            _context.SaveChanges();
        }

        void IEmployeeRepository.changeOrderStatus(int orderId, int statusId)
        {
            var item = _context.Orders.Find(orderId);
            item.Id_Status = statusId;

            _context.SaveChanges();
        }

        bool IEmployeeRepository.CheckRegisterKey(decimal key)
        {
            throw new NotImplementedException();
        }

        void IEmployeeRepository.DeleteAdmin(int id)
        {
            var item = _context.Employees.Find(id);

            item.Id_Rule = (int)Rules.Employee;
            _context.SaveChanges();
        }

        void IEmployeeRepository.DeleteEmployee(int id)
        {
            var item = _context.Employees.Find(id);

            _context.Employees.Remove(item);
            _context.SaveChanges();
        }

        void IEmployeeRepository.DeleteItem(int id)
        {
            var product = _context.Items.Find(id);
            var itemDetails = _context.DictItemsDetails.Where(x => x.Id_Item == id).FirstOrDefault();
            var itemPictures = _context.ItemsPictures.Where(x => x.Id_Item == id).ToList();
            var itemOpinions = _context.ItemsOpinions.Where(x => x.Id_Item == id).ToList();
            var descriptionItem = _context.DictDescriptionItems.Where(x => x.Id == product.Id_Description).FirstOrDefault();

            foreach (var item in itemPictures)
            {
                _context.ItemsPictures.Remove(item);
            }

            foreach (var item in itemOpinions)
            {
                _context.ItemsOpinions.Remove(item);
            }

            _context.DictDescriptionItems.Remove(descriptionItem);
            _context.DictItemsDetails.Remove(itemDetails);
            _context.Items.Remove(product);

            _context.SaveChanges();
        }

        void IEmployeeRepository.DeleteKey(int id)
        {
            var dbItem = _context.GeneretedRegisterKeys.Find(id);

            _context.GeneretedRegisterKeys.Remove(dbItem);
            _context.SaveChanges();
        }

        void IEmployeeRepository.DeleteOpinion(int id)
        {
            var dbItem = _context.ItemsOpinions.Find(id);

            _context.ItemsOpinions.Remove(dbItem);
            _context.SaveChanges();
        }

        void IEmployeeRepository.DeleteOrder(int orderId)
        {
            var order = _context.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            var orderDetails = _context.OrderDetails.Where(x => x.Id_Order == orderId).ToList();
            var orderComplaints = _context.OrderComplaints.Where(x => x.Id_Order == orderId).FirstOrDefault();

            foreach (var item in orderDetails)
            {
                _context.OrderDetails.Remove(item);
            }

            _context.OrderComplaints.Remove(orderComplaints);
            _context.Orders.Remove(order);
        }

        void IEmployeeRepository.EditProduct(items item, List<items_picutures> itemPictures, _dict_items_details itemDetial, List<items_quantity> itemQuantity)
        {
            //item
            var dbItem = _context.Items.Find(item.Id);

            dbItem.Id_Category = item.Id_Category;
            dbItem.Price = item.Price;
            dbItem.Title = item.Title;

            var dbDesc = _context.DictDescriptionItems.Find(item.Id_Description);
            dbDesc.Name = item.Description.Name;

            _context.SaveChanges();

            //images
            foreach(var picture in itemPictures)
            {
                var dbPic = _context.ItemsPictures.Find(picture.Id);

                dbPic.PictureData = picture.PictureData;
                dbPic.PictureMimeType = picture.PictureMimeType;

                _context.SaveChanges();
            }

            //itemDetail
            var dbDetail = _context.DictItemsDetails
                .Where(x => x.Id_Item == itemDetial.Id_Item)
                .FirstOrDefault();

            dbDetail.Name = itemDetial.Name;
            _context.SaveChanges();

            //itemQuantity
            foreach(var quantity in itemQuantity)
            {
                var dbQ = _context.ItemsQuantity.Find(quantity.Id);

                dbQ.Quantity = quantity.Quantity;

                _context.SaveChanges();
            }
        }

        clients IEmployeeRepository.GetClientById(int id)
        {
            var dbItem = _context.Clients.Find(id);

            return dbItem;
        }

        employees IEmployeeRepository.GetEmployeeModel(int id)
        {
            return _context.Employees
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();
        }

        int[] IEmployeeRepository.GetStats()
        {
            var lastMonth = DateTime.Now.AddMonths(-1);
            int newComments = _context.ItemsOpinions
                .Where(x => x.InsertTime > lastMonth)
                .Count();

            int newOrders = _context.Orders
                .Where(x => x.InsertTime > lastMonth)
                .Count();

            int newNewsletter = _context.Newsletter
                .Where(x => x.InsertTime > lastMonth)
                .Count();

            int unusedKeys = _context.GeneretedRegisterKeys
                .Where(x => x.IsUsed == false)
                .Count();

            int[] returnData = new int[4];
            returnData[0] = newComments;
            returnData[1] = newOrders;
            returnData[2] = newNewsletter;
            returnData[3] = unusedKeys;

            return returnData;
        }

        void IEmployeeRepository.MakeAdmin(int id)
        {
            var item = _context.Employees.Find(id);

            item.Id_Rule = (int)Rules.Admin;
            _context.SaveChanges();
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

        bool IEmployeeRepository.TryDeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            var orders = _context.Orders
                .Where(x => x.Id_Client == id)
                .ToList();
            var ordersToDelete = new List<orders>();
            var ordersDetailsToDelete = new List<order_details>();
            var ordersComplaintsToDelete = new List<order_complaints>();

            if (orders.Count != 0)
            {
                foreach (var item in orders)
                {
                    if (item.Id_Status == 3)
                    {
                        ordersToDelete.Add(item);

                        _context.OrderDetails
                        .Where(x => x.Id_Order == item.Id)
                        .ToList()
                        .ForEach(x => ordersDetailsToDelete.Add(x));

                        _context.OrderComplaints
                            .Where(x => x.Id_Order == item.Id)
                            .ToList()
                            .ForEach(x => ordersComplaintsToDelete.Add(x));
                    }
                }

                if (ordersToDelete.Count != 0)
                {
                    var clientNotyfications = _context.ClientNotyfications
                    .Where(x => x.Id_Client == id)
                    .ToList();

                    //proces usuwania zamówień
                    ordersComplaintsToDelete.ForEach(x => _context.OrderComplaints.Remove(x));
                    ordersDetailsToDelete.ForEach(x => _context.OrderDetails.Remove(x));
                    ordersToDelete.ForEach(x => _context.Orders.Remove(x));

                    //proces usuwania notyfikacji i klienta
                    clientNotyfications.ForEach(x => _context.ClientNotyfications.Remove(x));
                    _context.Clients.Remove(client);

                    //zapisanie zmian
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var clientNotyfications = _context.ClientNotyfications
                    .Where(x => x.Id_Client == id)
                    .ToList();

                //proces usuwania notyfikacji i klienta
                clientNotyfications.ForEach(x => _context.ClientNotyfications.Remove(x));
                _context.Clients.Remove(client);

                //zapisanie zmian
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        bool IEmployeeRepository.TrySaveGenerateKey(int code)
        {
            var codes = _context.GeneretedRegisterKeys
                .Where(x => x.RegisterPin == code)
                .Select(x =>x)
                .FirstOrDefault();

            if (codes == null)
            {
                var newCode = new genereted_register_keys 
                {
                    ExpirationDate = DateTime.Now.AddDays(7.0),
                    RegisterPin = code,
                    IsUsed = false
                };

                _context.GeneretedRegisterKeys.Add(newCode);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
