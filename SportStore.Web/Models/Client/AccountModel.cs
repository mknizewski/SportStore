using System;

namespace SportStore.Web.Models.Client
{
    public class AccountModel
    {
        //Dane kontaktowe
        public int Id { get; set; }

        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //Dane wysyłkowe
        public int City_Id { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Inne
        public int? UnreadNotifications { get; set; }
    }
}