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
    /// Opis:   Interfejs komunikacyjny pomiędzy bazą danych a klientami
    /// Data:   07.11.15
    /// </summary>
    public interface IClientRepository
    {
        IEnumerable<clients> Clients { get; set; }
        IEnumerable<client_notyfications> ClientNotyfications { get; set; }
        IEnumerable<history_client_notyfications> HistoryClientNotyfications { get; set; }
        void Add(clients client);
        void Delete(int id);
        void Edit(clients client);
        void MarkAsRead(int id);
        void DeleteNote(client_notyfications model);
        void AddHistoryNote(history_client_notyfications model);
    }
}
