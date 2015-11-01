using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class items_quantity
    {
        public int Id { get; set; }
        [Key, ForeignKey("Item")]
        public int Id_Item { get; set; }
        [Key, ForeignKey("Shop")]
        public int Id_Shop { get; set; }
        public int Quantity { get; set; }

        public virtual items Item { get; set; }
        public virtual _dict_shops Shop { get; set; }
    }
}
