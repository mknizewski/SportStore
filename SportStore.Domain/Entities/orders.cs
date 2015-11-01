using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela przechowująca aktualne zamówienia
    /// Data:   31.10.15
    /// </summary>
    public class orders
    {
        public int Id { get; set; }
        [Key, ForeignKey("Client")]
        public int Id_Client { get; set; }
        [Key, ForeignKey("OrderStatus")]
        public int Id_Status { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public decimal ToPay { get; set; }
        public string AdressToDelivery { get; set; }

        public virtual clients Client { get; set; }
        public virtual _dict_status_orders OrderStatus { get; set; }
    }
}
