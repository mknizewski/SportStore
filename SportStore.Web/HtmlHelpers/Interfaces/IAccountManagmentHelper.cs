using SportStore.Domain.Entities;
using SportStore.Web.Models.Client;
using System.Collections.Generic;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    /// <summary>
    /// Autor:  Matuesz Kniżewski
    /// Data:   21.11.15
    /// Opis:   Interfejs zarządzający kontem klienta serwisu SportStore
    /// </summary>
    public interface IAccountManagmentHelper
    {
        NotyficationsClientModel GetNotifications(int id);

        IEnumerable<orders> GetOrders(int id);

        IEnumerable<order_complaints> GetComplaints(int id);

        bool ChangePassword(int Id, string oldPassword, string newPassword);

        void ChangeDeliveryData(AccountModel model);

        void EditAccount();

        void RemoveAccount(int id);

        void MarkAsRead(List<MarkAsReadModel> ids);

        void ArchivizeNote(List<int> ids);
    }
}