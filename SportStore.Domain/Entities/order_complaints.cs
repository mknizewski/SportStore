using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class order_complaints
    {
        public int Id { get; set; }

        [Key, ForeignKey("Order")]
        public int Id_Order { get; set; }

        [Key, ForeignKey("Status")]
        public int Id_Status { get; set; }

        public string MessageFromClient { get; set; }

        [Key, ForeignKey("Employee")]
        public int? Id_Employee { get; set; }

        public virtual orders Order { get; set; }
        public virtual _dict_status_compleints Status { get; set; }
        public virtual employees Employee { get; set; }
    }
}