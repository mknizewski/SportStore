using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class items_picutures
    {
        public int Id { get; set; }
        [Key, ForeignKey("Item")]
        public int Id_Item { get; set; }
        public byte[] PictureData { get; set;}
        public string PictureMimeType { get; set; }

        public virtual items Item { get; set; }
    }
}
