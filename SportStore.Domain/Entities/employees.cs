using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela zawierająca pracowników SportStore
    /// Data:   31.10.15
    /// </summary>
    public class employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Key, ForeignKey("Shop")]
        public int Id_Shop { get; set; }
        [Key, ForeignKey("Rule")]
        public int Id_Rule { get; set; }

        public virtual _dict_shops Shop { get; set; }
        public virtual _dict_rules Rule { get; set; }
    }
}
