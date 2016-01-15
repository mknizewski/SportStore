using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Web.Models.Client;
using System.Collections.Generic;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface IOrderHelper
    {
        OrderModel GetOrderModel(Cart cart, AccountModel client);

        OrderModel RecalculateOrder(OrderModel model);

        void AddOrder(OrderModel model);

        IEnumerable<orders> GetOrdersByClientId(int clientId);

        OrderPDFModel GetPDF(int orderId);
    }
}