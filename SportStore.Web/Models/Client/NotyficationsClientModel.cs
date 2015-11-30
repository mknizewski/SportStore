using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportStore.Domain.Entities;

namespace SportStore.Web.Models.Client
{
    public class NotyficationsClientModel
    {
        public IEnumerable<client_notyfications> ClientNotyfications { get; set; }
        public IEnumerable<history_client_notyfications> HistoryClientNotyfications { get; set; }
    }
}