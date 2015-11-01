using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class client_notyfications
    {
        public int Id { get; set; }
        [Key, ForeignKey("Client")]
        public int Id_Client { get; set; }
        public string Message { get; set; }
        public bool AsRead { get; set; }

        public virtual clients Client { get; set; }
    }
}
