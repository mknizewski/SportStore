using SportStore.Domain.Entities;
using System.Collections.Generic;

namespace SportStore.Domain.Abstract
{
    public interface IOrdersRepository
    {
        //Słownikowe
        IEnumerable<_dict_status_orders> DictStatusOrders { get; set; }

        IEnumerable<_dict_status_compleints> DictStatusCompleints { get; set; }
        IEnumerable<_dict_orders_delivery> DictOrdersDelivery { get; set; }

        //Aktualne
        IEnumerable<order_complaints> OrdersComplaints { get; set; }

        IEnumerable<order_details> OrderDetails { get; set; }
        IEnumerable<orders> Orders { get; set; }

        //Historyczne
        IEnumerable<history_orders> HistoryOrders { get; set; }

        IEnumerable<history_orders_complaints> HistoryOrdersComplaints { get; set; }
        IEnumerable<history_orders_details> HistoryOrdersDetails { get; set; }

        //CURD zamowienia
        int AddOrder(orders order);

        void AddOrderDetails(IEnumerable<order_details> orderDetails);

        void EditOrder();

        void DeleteOrder(int orderId);

        int GetIdOrder(orders model);

        void GetOrderById(int orderId);

        IEnumerable<orders> GetOrdersByClientId(int clientId);

        //CRUD reklamacji
        void AddOrderComplaints(order_complaints orderCompaints);

        void EditOrderComplaints();

        void DeleteOrderComplaints(int orderComplaintId);

        void GetOrderComplaintsById(int orderComplaintId);

        void GetOrdersComplaintsByClientId(int clientId);
    }
}