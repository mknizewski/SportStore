using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class history_orders
    {
        public int Id { get; set; }
        public int History_Id { get; set; }
        [Key, ForeignKey("Status")]
        public int Id_Status { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public decimal ToPay { get; set; }
        public string AdressToDelivery { get; set; }

        public virtual _dict_status_orders Status { get; set; }
    }
}
