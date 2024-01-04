using Microsoft.EntityFrameworkCore;
using webapp.Model;

namespace webapp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CW2");
            modelBuilder.Entity<UserActivityLink>().HasNoKey().ToView("Favourite Activities");
            modelBuilder.Entity<ActivityName>().HasNoKey().ToView("Activity Names");
        }

        public DbSet<ActivityData> FavouriteActivities { get; set; }
        public DbSet<UserActivity> UserProfileFavouriteActivities { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserActivityLink> UserActivityLinkView { get; set; }
        public DbSet<ActivityName> ActivityNamesView { get; set; }
    }
}