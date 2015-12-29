using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class AccountManagmentHelper : IAccountManagmentHelper
    {
        private IClientRepository _clientRepository;

        public AccountManagmentHelper(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
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

        void IAccountManagmentHelper.ArchivizeNote(List<int> ids)
        {
            if (ids != null)
            {
                foreach (var id in ids)
                {
                    var dbItem = (from client_notyfications c in _clientRepository.ClientNotyfications
                                  where c.Id.Equals(id)
                                  select c).FirstOrDefault();

                    var historyItem = new history_client_notyfications
                    {
                        History_Id = dbItem.Id,
                        Id_Client = dbItem.Id_Client,
                        Message = dbItem.Message,
                        InsertTime = DateTime.Now,
                        AsRead = dbItem.AsRead
                    };

                    //usunięcie z notyfications_client
                    _clientRepository.DeleteNote(dbItem);

                    //archiwizacja
                    _clientRepository.AddHistoryNote(historyItem);
                }
            }
        }

        NotyficationsClientModel IAccountManagmentHelper.GetNotifications(int id)
        {
            var notyfications = (from client_notyfications c in _clientRepository.ClientNotyfications
                                 where c.Id_Client == id
                                 select c).ToArray();

            var historyNotyfications = (from history_client_notyfications h in _clientRepository.HistoryClientNotyfications
                                        where h.Id_Client == id
                                        select h).ToArray();

            var modelToReturn = new NotyficationsClientModel
            {
                ClientNotyfications = notyfications,
                HistoryClientNotyfications = historyNotyfications
            };

            return modelToReturn;
        }

        bool IAccountManagmentHelper.ChangePassword(int Id, string oldPassword, string newPassword)
        {
            if (checkPassword(Id, oldPassword))
            {
                _clientRepository.ChangePassword(Id, PasswordHelper.Encrypt(newPassword));
                return true;
            }
            else
                return false;  

        }

        private bool checkPassword(int Id, string Password)
        {
            var client = _clientRepository.Clients
                .Where(x => x.Id.Equals(Id))
                .FirstOrDefault();

            var password = PasswordHelper.Decrypt(client.Password);

            if (password == Password)
                return true;
            else
                return false;
        }

        void IAccountManagmentHelper.ChangeDeliveryData(AccountModel model)
        {
            _clientRepository.ChangePersonalData(model.Id, model.Street, model.PostalCode, model.City);
        }
    }
}