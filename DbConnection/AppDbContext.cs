using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News_Portal.Models;

namespace News_Portal.DbConnection
{
    public class AppDbContext : IdentityDbContext<ApplicationUsers,IdentityRole, string>
    {
        public AppDbContext(DbContextOptions  options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Trending_News>().
                HasMany(x => x.Images)
                .WithOne(x => x.trending_News)
                .HasForeignKey(x => x.TrendingId).IsRequired();


            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Trending_News> trending_News { get; set; }
        public DbSet<Latest_News> latest_news { get; set; }
        public DbSet<Politics_News> Politics {  get; set; }
        public DbSet<Sports_News> Sports { get; set; }
        public DbSet<Business_News> Business { get; set; }
        public DbSet<Bollywood_News> bollywoods { get; set; }
        public DbSet<MultiplePhotoUpload> multiplePhotoUploads { get; set; }
        public DbSet<FileModals> fileModals { get; set; }

    }

}
 