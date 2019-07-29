using Projekt.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Threading;
using Projekt.Extensions;


namespace Projekt.DB
{
    public class TellContext : DbContext
    {
        public TellContext(DbContextOptions<TellContext> options)
            : base(options)
        { }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Operator> Operators{ get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneOperator> PhoneOperators { get; set; }
        
        public DbSet<BaseModel> Basemodels { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);            foreach (var fk in cascadeFKs)
               fk.DeleteBehavior = DeleteBehavior.Restrict;            
               
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
        // used for tracking columns
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if(entry.Entity is BaseModel)
                {
                    var now = DateTime.UtcNow;
                    BaseModel entity = (BaseModel) entry.Entity;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entity.UpdatedAt = now;
                            break;
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            break;
                    }
                }
            }
        }

    }
}