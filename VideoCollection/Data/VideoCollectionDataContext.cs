using System.Data.Entity;
using VideoCollection.Data.Models;
using System.Linq;
using System;

namespace VideoCollection.Data
{
    public class VideoCollectionDataContext : DbContext
    {
        public VideoCollectionDataContext ()
            : base(nameOrConnectionString: "VideoCollectionDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<DigitalAsset> DigitalAssets { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries()
            .Where(e => e.Entity is ILoggable &&
                ((e.State == EntityState.Added || (e.State == EntityState.Modified)))))
            {

                if (((ILoggable)entry.Entity).CreatedOn == null)
                {
                    ((ILoggable)entry.Entity).CreatedOn = DateTime.UtcNow;
                }

                ((ILoggable)entry.Entity).LastModifiedOn = DateTime.UtcNow;

            }

            return base.SaveChanges();
        }
    }
}
