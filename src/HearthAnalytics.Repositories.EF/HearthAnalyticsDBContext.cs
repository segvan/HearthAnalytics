using HearthAnalytics.Infrastructure;
using HearthAnalytics.Model;
using HearthAnalytics.Model.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace HearthAnalytics.Repositories.EF
{
    public class HearthAnalyticsDBContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<ArchyType> ArchyTypes { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<ClassType> ClassTypes { get; set; }

        public DbSet<MatchResult> MatchResults { get; set; }

        public HearthAnalyticsDBContext(DbContextOptions<HearthAnalyticsDBContext> options):base(options)
        {            
        }

        public override int SaveChanges()
        {
            DateTracking();
            HasOwner();

            return base.SaveChanges();
        }

        private async void HasOwner()
        {
            var adminUser = await this.Users.FirstOrDefaultAsync(x => x.Email == "admin@microsoft.com");

            var items = ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) && e.Entity is IHasOwner<Guid>);

            foreach (EntityEntry item in items)
            {
                var addedItem = item.Entity as IHasOwner<Guid>;
                addedItem.OwnerUserId = adminUser.Id;
            }
        }

        private void DateTracking()
        {
            var modified = ChangeTracker.Entries().Where(
                           e => (e.State == EntityState.Modified || e.State == EntityState.Added)
                                   && e.Entity is IDateTracking);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.Created = DateTime.Now;
                    }
                    changedOrAddedItem.Modified = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchyType>().HasOne(a => a.Owner).WithMany(u => u.ArhcyTypes).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Deck>().HasOne(d => d.Owner).WithMany(u => u.Decks).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Deck>().HasOne(d => d.ArchyType).WithMany(a => a.Decks).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Match>().HasOne(m => m.Owner).WithMany(u => u.Matches).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>().HasOne(m => m.Deck).WithMany(d => d.Matches).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
