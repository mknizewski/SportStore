using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class history_orders_complaints
    {
        public int Id { get; set; }
        public int History_Id { get; set; }
        [Key, ForeignKey("HistoryOrder")]
        public int Id_Order { get; set; }
        [Key, ForeignKey("Status")]
        public int Id_Status { get; set; }
        public string MessageFromClient { get; set; }
        [Key, ForeignKey("Employee")]
        public int? Id_employee { get; set; }

        public virtual history_orders HistoryOrder { get; set; }
        public virtual _dict_status_compleints Status { get; set; }
        public virtual employees Employee { get; set; }
    }
}
