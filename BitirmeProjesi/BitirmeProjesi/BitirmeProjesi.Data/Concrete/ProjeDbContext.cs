using BitirmeProjesi.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Concrete
{
    public class ProjeDbContext : IdentityDbContext<User>
    {
        public ProjeDbContext(DbContextOptions<ProjeDbContext> options):base(options)
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PaidBills> PaidBills { get; set; }
    }
}
