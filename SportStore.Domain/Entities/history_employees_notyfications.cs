using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    public class history_employees_notyfications
    {
        public int Id { get; set; }
        public int History_Id { get; set; }
        [Key, ForeignKey("Employee")]
        public int Id_Employee { get; set; }
        public string Message { get; set; }
        public DateTime InsertTime { get; set; }
        public bool AsRead { get; set; }

        public virtual employees Employee { get; set; }
    }
}
