using SportStore.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SportStore.Domain.Concrete
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa bazowa bazy danych frameworku EF
    /// Data:   17.10.15
    /// </summary>
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            :base("EFDbContext")
        {
            
        }

        #region Tabele Słownikowe
        public DbSet<_dict_newsletter> DictNewsletter { get; set; }
        public DbSet<_dict_catalogs> DictCatalogs { get; set; }
        public DbSet<_dict_rules> DictRules { get; set; }
        public DbSet<_dict_status_orders> DictStatusOrders { get; set; }
        public DbSet<_dict_description_items> DictDescriptionItems { get; set; }
        public DbSet<_dict_status_compleints> DictStatusCompleints { get; set; }
        public DbSet<_dict_cities> DictCities { get; set; }
        public DbSet<_dict_shops> DictShops { get; set; }
        #endregion

        #region Zwykłe tabele
        public DbSet<Newsletter> Newsletter { get; set; }
        public DbSet<clients> Clients { get; set; }
        public DbSet<employees> Employees { get; set; }
        public DbSet<items> Items { get; set; }
        public DbSet<items_opinions> ItemsOpinions { get; set; }
        public DbSet<items_quantity> ItemsQuantity { get; set; }
        public DbSet<items_picutures> ItemsPictures { get; set; }
        public DbSet<orders> Orders { get; set; }
        public DbSet<order_details> OrderDetails { get; set; }
        public DbSet<order_complaints> OrderComplaints { get; set; }
        public DbSet<client_notyfications> ClientNotyfications { get; set; }
        public DbSet<employee_notyfications> EmployeeNotyfications { get; set; }
        #endregion

        #region Tabele historyczne
        // TODO: Zrobić historycze tabele!
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Słownikowe
            modelBuilder.Entity<_dict_newsletter>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<_dict_catalogs>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<_dict_rules>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<_dict_status_orders>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<_dict_description_items>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<_dict_status_compleints>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<_dict_cities>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<_dict_shops>()
                .HasKey(e => e.Id);
            #endregion

            #region Normalne
            modelBuilder.Entity<Newsletter>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<clients>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<employees>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<items>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<items_opinions>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<items_quantity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<items_picutures>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<orders>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<order_details>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<order_complaints>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<client_notyfications>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<employee_notyfications>()
                .HasKey(e => e.Id);
            #endregion

            #region Historyczne
            // TODO: Tutaj opisać idki tabel historycznych na wzór poprzednich
            #endregion
        }
        #endregion
    }
}
