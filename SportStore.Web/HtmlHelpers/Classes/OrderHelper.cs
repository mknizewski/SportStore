using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class OrderHelper : IOrderHelper
    {
        private IOrdersRepository _ordersRepository;

        public OrderHelper(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        void IOrderHelper.AddOrder(OrderModel model)
        {
            var adress = model.Client.Name + " " + model.Client.Surname 
                + ";" + model.Client.Street + ";" + model.Client.PostalCode 
                + ";" + model.Client.City;

            var order = new orders
            {
                Id_Client = model.Client.Id,
                Id_Delivery = model.selectedDeliveryId,
                Id_Status = 1,
                ToPay = model.cart.ComputeTotalValue(),
                AdressToDelivery = adress,
                InsertTime = DateTime.Now,
            };

            //dodanie nowego zamówienia => przejscie do wypełnienia szczegółów zamówienia
            var orderId = _ordersRepository.AddOrder(order);

            var orderDetails = new List<order_details>();
            var arrayToList = model.cart.Lines.ToList();

            for (int i = 0; i < arrayToList.Count - 1; i++)
            {
                orderDetails.Add(new order_details
                {
                    Id_Order = orderId,
                    Id_Item = arrayToList[i].Item.Id,
                    Quantity = arrayToList[i].Quantity
                });
            }

            _ordersRepository.AddOrderDetails(orderDetails);
        }

        OrderModel IOrderHelper.GetOrderModel(Cart cart, AccountModel client)
        {
            var delivery = _ordersRepository.DictOrdersDelivery;
            var selectListItemDelivery = new List<SelectListItem>();
            var modelToReturn = new OrderModel();

            foreach (var item in delivery)
            {
                selectListItemDelivery.Add(new SelectListItem
                {
                    Text = item.Name + " - " + item.Price.ToString("c"),
                    Value = item.Id.ToString()
                });
            }

            modelToReturn.OrderDelivery = selectListItemDelivery;
            modelToReturn.cart = cart;
            modelToReturn.Client = client;
            modelToReturn.TotalPrice = cart.ComputeTotalValue();

            return modelToReturn;
        }

        IEnumerable<orders> IOrderHelper.GetOrdersByClientId(int clientId)
        {
            var model = _ordersRepository.GetOrdersByClientId(clientId);

            return model;
        }

        OrderPDFModel IOrderHelper.GetPDF(int orderId)
        {
            var order = _ordersRepository.Orders
                .Where(x => x.Id.Equals(orderId))
                .FirstOrDefault();

            var orderDetails = _ordersRepository.OrderDetails
                .Where(x => x.Id_Order.Equals(orderId))
                .ToArray();

            var model = new OrderPDFModel
            {
                Order = order,
                OrderDetails = orderDetails
            };

            return model;
        }

        OrderModel IOrderHelper.RecalculateOrder(OrderModel model)
        {
            var selectedOrderId = model.selectedDeliveryId;
            var selectedOrder = _ordersRepository.DictOrdersDelivery
                .Where(x => x.Id.Equals(selectedOrderId))
                .FirstOrDefault();

            var delivery = _ordersRepository.DictOrdersDelivery;
            var selectListItemDelivery = new List<SelectListItem>();

            foreach (var item in delivery)
            {
                selectListItemDelivery.Add(new SelectListItem
                {
                    Text = item.Name + " - " + item.Price.ToString("c"),
                    Value = item.Id.ToString()
                });
            }

            model.OrderDelivery = selectListItemDelivery;

            var deliveryItem = model.cart.Lines
                .Where(x => x.Item.Id.Equals(0))
                .FirstOrDefault();

            if (deliveryItem == null)
            {
                model.cart.AddItem(
                    new items
                    {
                        Title = selectedOrder.Name,
                        Price = selectedOrder.Price
                    }, 1);

                model.TotalPrice = model.cart.ComputeTotalValue();
            }
            else
            {
                var item = new items
                {
                    Title = selectedOrder.Name,
                    Price = selectedOrder.Price
                };

                model.cart.RemoveItem(deliveryItem.Item);
                model.cart.AddItem(item, 1);

                model.TotalPrice = model.cart.ComputeTotalValue();
            }

            return model;
        }
    }
}