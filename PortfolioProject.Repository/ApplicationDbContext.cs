using Microsoft.EntityFrameworkCore;

namespace PortfolioProject.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.BlogPost> BlogPosts { get; set; }
        public DbSet<Models.Comment> Comments { get; set; }
        public DbSet<Models.PostLike> PostLikes { get; set; }
        public DbSet<Models.CommentLike> CommentLikes { get; set; }
    }
}
