using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa tabeli słownikowej _dict_typeofnews_newsletter
    /// Data:   17.10.15
    /// </summary>
    public class _dict_typeofnews_newsletter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
