using ContactsList.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsList.Infraestructure.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }
    }
}
