using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela przechowująca klientów sklepu SportStore
    /// Data:   31.10.15
    /// </summary>
    public class clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Key, ForeignKey("City")]
        public int Id_City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfBrith { get; set; }
        [Key, ForeignKey("Rule")]
        public int Id_Rule { get; set; }

        public virtual _dict_cities City { get; set; }
        public virtual _dict_rules Rule { get; set; }
    }
}
