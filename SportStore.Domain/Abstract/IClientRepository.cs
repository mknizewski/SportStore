using SportStore.Domain.Entities;
using System.Collections.Generic;

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

        void ChangePassword(int Id, string password);

        void ChangePersonalData(int Id, string street, string postalCode, string city);

        void MarkAsRead(int id);

        void DeleteNote(client_notyfications model);

        void AddHistoryNote(history_client_notyfications model);
    }
}