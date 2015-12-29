using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;
using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Domain.Respositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private EFDbContext _efDbContext = new EFDbContext();

        IEnumerable<_dict_orders_delivery> IOrdersRepository.DictOrdersDelivery
        {
            get
            {
                return _efDbContext.DictOrdersDelivery;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_status_compleints> IOrdersRepository.DictStatusCompleints
        {
            get
            {
                return _efDbContext.DictStatusCompleints;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_status_orders> IOrdersRepository.DictStatusOrders
        {
            get
            {
                return _efDbContext.DictStatusOrders;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<history_orders> IOrdersRepository.HistoryOrders
        {
            get
            {
                return _efDbContext.HistoryOrders;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<history_orders_complaints> IOrdersRepository.HistoryOrdersComplaints
        {
            get
            {
                return _efDbContext.HistoryOrdersComplaints;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<history_orders_details> IOrdersRepository.HistoryOrdersDetails
        {
            get
            {
                return _efDbContext.HistoryOrdersDetails;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<order_details> IOrdersRepository.OrderDetails
        {
            get
            {
                return _efDbContext.OrderDetails;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<orders> IOrdersRepository.Orders
        {
            get
            {
                return _efDbContext.Orders;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<order_complaints> IOrdersRepository.OrdersComplaints
        {
            get
            {
                return _efDbContext.OrderComplaints;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        int IOrdersRepository.AddOrder(orders order)
        {
            _efDbContext.Orders.Add(order);
            _efDbContext.SaveChanges();

            var notyfications = new client_notyfications
            {
                Id_Client = order.Id_Client,
                AsRead = false,
                Message = "Złożono zamówienie o numerze " + order.Id + " w dniu " + order.InsertTime.ToShortDateString()
            };

            _efDbContext.ClientNotyfications.Add(notyfications);
            _efDbContext.SaveChanges();

            return order.Id;
        }

        void IOrdersRepository.AddOrderComplaints(order_complaints orderCompaints)
        {
            _efDbContext.OrderComplaints.Add(orderCompaints);
            _efDbContext.SaveChanges();
        }

        void IOrdersRepository.AddOrderDetails(IEnumerable<order_details> orderDetails)
        {
            foreach (var detail in orderDetails)
            {
                var quantityToGo = detail.Quantity;
                var quantityItems = _efDbContext.ItemsQuantity
                    .Where(x => x.Id_Item.Equals(detail.Id_Item))
                    .OrderBy(x => x.Quantity).ToList();
                bool inserted = false;
                int iterator = 0;

                while (!inserted)
                {
                    var shop = quantityItems[iterator];

                    if ((shop.Quantity >= quantityToGo) || quantityToGo == 0)
                    {
                        shop.Quantity -= quantityToGo;
                        inserted = true;
                    }
                    else
                    {
                        quantityToGo -= shop.Quantity;
                        shop.Quantity = 0;
                        iterator++;
                    }
                }

                _efDbContext.OrderDetails.Add(detail);
            }

            _efDbContext.SaveChanges();
        }

        void IOrdersRepository.DeleteOrder(int orderId)
        {
            var order = _efDbContext.Orders
                .Where(x => x.Id.Equals(orderId))
                .FirstOrDefault();

            _efDbContext.Orders.Remove(order);
            _efDbContext.SaveChanges();
        }

        void IOrdersRepository.DeleteOrderComplaints(int orderComplaintId)
        {
            var orderComplaints = _efDbContext.OrderComplaints
                .Where(x => x.Id.Equals(orderComplaintId))
                .FirstOrDefault();

            _efDbContext.OrderComplaints.Remove(orderComplaints);
            _efDbContext.SaveChanges();
        }

        void IOrdersRepository.EditOrder()
        {
            throw new NotImplementedException();
        }

        void IOrdersRepository.EditOrderComplaints()
        {
            throw new NotImplementedException();
        }

        int IOrdersRepository.GetIdOrder(orders model)
        {
            return _efDbContext.Orders
                .Where(x => x.Equals(model))
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        void IOrdersRepository.GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        void IOrdersRepository.GetOrderComplaintsById(int orderComplaintId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<orders> IOrdersRepository.GetOrdersByClientId(int clientId)
        {
            var ordersToReturn = _efDbContext.Orders
                .Where(x => x.Id_Client.Equals(clientId))
                .ToArray();

            return ordersToReturn;
        }

        void IOrdersRepository.GetOrdersComplaintsByClientId(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}