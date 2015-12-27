using SportStore.Domain.Entities;
using System.Collections.Generic;

namespace SportStore.Web.Models.Client
{
    public class NotyficationsClientModel
    {
        public IEnumerable<client_notyfications> ClientNotyfications { get; set; }
        public IEnumerable<history_client_notyfications> HistoryClientNotyfications { get; set; }
    }
}