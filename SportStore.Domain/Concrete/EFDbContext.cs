using SportStore.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SportStore.Domain.Concrete
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa bazowa bazy danych EF
    /// Data:   17.10.15
    /// </summary>
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            :base("EFDbContext")
        {
           
        }

        public DbSet<_dict_typeofnews_newsletter> DictNewsletter { get; set; }
        public DbSet<Newsletter> Newsletter { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<_dict_typeofnews_newsletter>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Newsletter>()
                .HasKey(e => e.Id);
        }
    }
}
