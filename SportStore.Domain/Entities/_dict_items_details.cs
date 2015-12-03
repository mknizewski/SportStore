using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class _dict_items_details
    {
        public int Id { get; set; }

        [Key, ForeignKey("Item")]
        public int Id_Item { get; set; }

        public string Name { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual items Item { get; set; }
    }
}