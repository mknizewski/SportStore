using System;
using System.ComponentModel;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela kluczy rejestracyjnych dla pracowników systemu SportStore
    /// Data:   10.11.15
    /// </summary>
    public class genereted_register_keys
    {
        public int Id { get; set; }
        public int RegisterPin { get; set; }

        [DefaultValue(false)]
        public bool IsUsed { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}