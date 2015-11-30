using SportStore.Domain.Entities;
using SportStore.Web.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    /// <summary>
    /// Autor:  Matuesz Kniżewski
    /// Data:   21.11.15
    /// Opis:   Interfejs zarządzający kontem klienta serwisu SportStore
    /// </summary>
    public interface IAccountManagmentHelper
    {
        IEnumerable<client_notyfications> GetNotifications(int id);
        IEnumerable<orders> GetOrders(int id);
        IEnumerable<order_complaints> GetComplaints(int id);
        void EditAccount();
        void RemoveAccount(int id);
        void MarkAsRead(List<MarkAsReadModel> ids);
    }
}
