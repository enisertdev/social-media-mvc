using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewExcite.Entitiy.Concrete;


namespace NewExcite.DataAccess.Concrete.Data
{
    public class NewExciteDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserPostComment> UserPostComments { get; set; }
        public DbSet<UserPostLike> UserPostLikes { get; set; }
        public DbSet<UserFriendship> UserFriendships { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();
            var connectionString = configuration.GetConnectionString("connectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserPost>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserPosts)
                .HasForeignKey(x => x.UserId);

            builder.Entity<UserPostComment>()
                .HasOne(x => x.UserPost)
                .WithMany(x => x.PostComments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserPostComment>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserPostComments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserPostLike>(entity =>
            {
                entity.HasOne(x => x.UserPost)
                .WithMany(x => x.PostLikes)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.User)
                .WithMany(x => x.UserPostLikes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<UserFriendship>()
                .HasOne(x => x.UserFollowed)
                .WithMany(x => x.FollowedBy)
                .HasForeignKey(x => x.FollowedId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserFriendship>()
                .HasOne(x => x.UserFollower)
                .WithMany(x => x.Following)
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}
