using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using System.Web.Mvc;
using SportStore.Web.Models.Home;
using SportStore.Web.Models.Client;
using SportStore.Domain.Concrete;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class RegisterHelper : IRegisterHelper
    {
        private IClientRepository _clientsRepository { get; set; }

        public RegisterHelper(IClientRepository clientRepository)
        {
            _clientsRepository = clientRepository;
        }

        Models.Client.RegisterModel IRegisterHelper.GetRegisterModel()
        {
            var model = new RegisterModel();
            var list = GetCitiesList(new EFDbContext().DictCities);

            model.Cities = list;

            return model;
        }

        void IRegisterHelper.Save(Models.Client.RegisterModel registerModel)
        {
            var model = new clients()
            {
                Name = registerModel.FirstName,
                Surname = registerModel.LastName,
                Email = registerModel.Email,
                DateOfBrith = registerModel.DateOfBrith,
                Password = PasswordHelper.Encrypt(registerModel.Password),
                Street  = registerModel.Street,
                PostalCode = registerModel.PostalCode,
                Id_City = registerModel.selectedCity,
                Id_Rule = (int)Rules.Client + 1 
            };

            _clientsRepository.Add(model);
        }

        private IEnumerable<SelectListItem> GetCitiesList(IEnumerable<_dict_cities> list)
        {
            var newList = new List<SelectListItem>();

            foreach (var element in list)
                newList.Add(new SelectListItem()
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });

            return newList;
        } 
    }
}