using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Typ wyliczeniowy oceny produktów od 1 do 5
    /// Data:   31.10.15
    /// </summary>
    public enum Rating
    {
        VeryBad, Bad, Medium, Good, VeryGood
    }

    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela przechowująca opinie o produktach
    /// Data:   31.10.15
    /// </summary>
    public class items_opinions
    {
        public int Id { get; set; }
        public string Opinion { get; set; }
        public Rating Rate { get; set; }
        [Key, ForeignKey("Item")]
        public int Id_Item { get; set; }
        public DateTime InsertTime { get; set; }
        [Key, ForeignKey("Client")]
        public int? Id_Client { get; set; }

        public virtual items Item { get; set; }
        public virtual clients Client { get; set; }
    }
}
