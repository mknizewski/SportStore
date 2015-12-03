﻿using System;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela słownikowa opisów przedmiotów
    /// Data:   31.10.15
    /// </summary>
    public class _dict_description_items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}