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

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorAvatar> AuthorAvatars { get; set; }
        public DbSet<DigitalAsset> DigitalAssets { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoArticle> VideoArticles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries()
            .Where(e => e.Entity is ILoggable && ((e.State == EntityState.Added || (e.State == EntityState.Modified))))) {

                if (((ILoggable)entry.Entity).CreatedOn == default(DateTime))
                {
                    ((ILoggable)entry.Entity).CreatedOn = DateTime.Now;
                }

                ((ILoggable)entry.Entity).LastModifiedOn = DateTime.Now;

            }

            return base.SaveChanges();
        }
    }
}
