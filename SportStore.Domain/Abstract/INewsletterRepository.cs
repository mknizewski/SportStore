using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Abstract
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Interfejs komunikacyjny pomiędzy systemem a bazą danych dot. newslettera
    /// Data:   17.10.15
    /// </summary>
    public interface INewsletterRepository
    {
        IEnumerable<Newsletter> Newsletters { get; set; }
        IEnumerable<_dict_typeofnews_newsletter> TypeOfNews { get; set; }
        void Add(Newsletter news);
        void Delete(int id);
    }
}
