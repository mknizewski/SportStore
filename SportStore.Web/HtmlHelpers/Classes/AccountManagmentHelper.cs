using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class AccountManagmentHelper : IAccountManagmentHelper
    {
        private IClientRepository _clientRepository;

        public AccountManagmentHelper(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        IEnumerable<Domain.Entities.client_notyfications> IAccountManagmentHelper.GetNotifications(int id)
        {
            var dbData = (from client_notyfications c in _clientRepository.ClientNotyfications
                          where c.Id_Client == id
                          select c).ToArray();

            return dbData;
        }

        IEnumerable<Domain.Entities.orders> IAccountManagmentHelper.GetOrders(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Domain.Entities.order_complaints> IAccountManagmentHelper.GetComplaints(int id)
        {
            throw new NotImplementedException();
        }

        void IAccountManagmentHelper.EditAccount()
        {
            throw new NotImplementedException();
        }

        void IAccountManagmentHelper.RemoveAccount(int id)
        {
            throw new NotImplementedException();
        }

        void IAccountManagmentHelper.MarkAsRead(List<Models.Client.MarkAsReadModel> ids)
        {
            if (ids != null)
            {
                foreach (var item in ids)
                {
                    var dbItem = (from client_notyfications c in _clientRepository.ClientNotyfications
                                  where c.Id.Equals(item.Id)
                                  select c.AsRead).FirstOrDefault();

                    if (!dbItem)
                        _clientRepository.MarkAsRead(item.Id);
                }
            }
        }
    }
}