﻿using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
