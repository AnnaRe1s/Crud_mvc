using MeuSiteMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteMvc.Data
{
    public class ContextContacts : DbContext
    {
        public ContextContacts(DbContextOptions<ContextContacts> options) : base(options) => Database.EnsureCreated();
        


        //Referenciando o modelo do banco e o nome  (o contact model e como se fosse o schema)
        public DbSet<ContactsModel> Contacts { get; set; }

    }
}
