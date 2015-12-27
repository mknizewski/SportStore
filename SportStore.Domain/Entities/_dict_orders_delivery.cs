using System;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela słownikowa opcji dostawy przedmiotów
    /// Data:   26.12.15
    /// </summary>
    public class _dict_orders_delivery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}