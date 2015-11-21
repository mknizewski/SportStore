using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class history_orders_details
    {
        public int Id { get; set; }
        public int History_Id { get; set; }
        [Key, ForeignKey("HistoryOrder")]
        public int Id_Order { get; set; }
        [Key, ForeignKey("Item")]
        public int Id_Item { get; set; }
        public int Quantity { get; set; }

        public virtual history_orders HistoryOrder { get; set; }
        public virtual items Item { get; set; }
    }
}
