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

        bool IEmployeeRepository.CheckRegisterKey(decimal key)
        {
            throw new NotImplementedException();
        }

        void IEmployeeRepository.DeleteOpinion(int id)
        {
            var dbItem = _context.ItemsOpinions.Find(id);

            _context.ItemsOpinions.Remove(dbItem);
            _context.SaveChanges();
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
