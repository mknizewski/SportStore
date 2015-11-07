using System;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela słownikowa uprawnień
    /// Data:   31.10.15
    /// </summary>
    public class _dict_rules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }

    public enum Rules
    { 
        Admin, Employee, Client
    }
}
