using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tablica przechowująca szczegóły aktualnych zamówień
    /// Data:   31.10.15
    /// </summary>
    public class order_details
    {
        public int Id { get; set; }
        [Key, ForeignKey("Order")]
        public int Id_Order { get; set; }
        [Key, ForeignKey("Item")]
        public int Id_Item { get; set; }
        public int Quantity { get; set; }

        public virtual orders Order { get; set; }
        public virtual items Item { get; set; }
    }
}
