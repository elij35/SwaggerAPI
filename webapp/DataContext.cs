using Microsoft.EntityFrameworkCore;
using webapp.Model;

namespace webapp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public static string ConnectionString =
                "Data Source=dist-6-505.uopnet.plymouth.ac.uk;" +
                "User Id=EBowen;" +
                "Password=NdzP574+;" +
                "TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

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