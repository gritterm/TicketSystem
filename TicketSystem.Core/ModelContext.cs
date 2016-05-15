using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Model;
using System.Data.Entity.Core.Objects;
using TicketSystem.Core.Interfaces;

namespace TicketSystem.Core
{
    public class ModelContext : IdentityDbContext<IdentityUser>
    {
        private const string connString = "Data Source=localhost;" +
        "Initial Catalog=Ticketing;" +
        "User id=sa;" +
        "Password=sa;";
        public ModelContext() : base(connString)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<TicketPurchase> TicketPurchases { get; set; }
        public DbSet<TicketPurchaseLine> TicketPurchaseLines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<TicketReceipt> TicketReceipts { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public void PreSave()
        {
            var validEntity = EntityState.Added | EntityState.Modified | EntityState.Deleted;
            var stateEntries = ChangeTracker.Entries<IEntity>().Where(z =>((z.State & validEntity) != 0));
            foreach (var stateEntry in stateEntries)
            {
                var entity = stateEntry.Entity as IEntity;
                if(!entity.PreSave(stateEntry.State))
                {
                    this.Entry(entity).State = EntityState.Detached;
                }
            }
        }
        public override int SaveChanges()
        {
            PreSave();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }


    }
}
