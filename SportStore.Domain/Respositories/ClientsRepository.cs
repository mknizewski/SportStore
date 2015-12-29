using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Respositories
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa logiki bazodanowej klientów
    /// Data:   07.11.15
    /// </summary>
    public class ClientsRepository : IClientRepository
    {
        private EFDbContext _context = new EFDbContext();

        IEnumerable<Entities.clients> IClientRepository.Clients
        {
            get
            {
                return _context.Clients;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void IClientRepository.Add(Entities.clients client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        void IClientRepository.Delete(int id)
        {
            var clientToDelete = _context.Clients.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
            _context.Clients.Remove(clientToDelete);
            _context.SaveChanges();
        }

        void IClientRepository.Edit(Entities.clients client)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Entities.client_notyfications> IClientRepository.ClientNotyfications
        {
            get
            {
                return _context.ClientNotyfications;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<Entities.history_client_notyfications> IClientRepository.HistoryClientNotyfications
        {
            get
            {
                return _context.HistoryClientNotyfications;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void IClientRepository.MarkAsRead(int id)
        {
            var orginal = _context.ClientNotyfications.Find(id);

            orginal.AsRead = true;

            _context.SaveChanges();
        }

        void IClientRepository.DeleteNote(Entities.client_notyfications model)
        {
            _context.ClientNotyfications.Remove(model);
            _context.SaveChanges();
        }

        void IClientRepository.AddHistoryNote(Entities.history_client_notyfications model)
        {
            _context.HistoryClientNotyfications.Add(model);
            _context.SaveChanges();
        }

        void IClientRepository.ChangePassword(int Id, string password)
        {
            var client = _context.Clients
                .Where(x => x.Id.Equals(Id))
                .FirstOrDefault();

            client.Password = password;

            _context.SaveChanges();
        }

        void IClientRepository.ChangePersonalData(int Id, string street, string postalCode, string city)
        {
            var client = _context.Clients
                .Find(Id);

            client.Street = street;
            client.PostalCode = postalCode;

            var cityId = _context.DictCities
                .Where(x => x.Name.ToLower().Equals(city.ToLower()))
                .FirstOrDefault();

            if (cityId != null)
                client.Id_City = cityId.Id;

            _context.SaveChanges();
        }
    }
}