using Microsoft.EntityFrameworkCore;
using SimpleContactManager.Models;

namespace SimpleContactManager.InMemoryDb
{
    public class ContactDbContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Contacts");
        }
    }
}
