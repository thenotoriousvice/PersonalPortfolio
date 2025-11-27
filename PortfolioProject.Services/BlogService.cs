using Microsoft.EntityFrameworkCore;
using PortfolioProject.Repository;
using PortfolioProject.Repository.Models;


namespace PortfolioProject.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;
        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<BlogPost>> GetAllPostsAsync()
        {
            return await _context.BlogPosts.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }
        public async Task<BlogPost?> GetPostAsync(int id)
        {
            return await _context.BlogPosts.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
        public async Task AddReplyAsync(Comment reply)
        {
            _context.Comments.Add(reply);
            await _context.SaveChangesAsync();
        }
        public async Task AddPostLikeAsync(int postId)
        {
            var like = new PostLike { BlogPostId = postId };
            _context.PostLikes.Add(like);
            await _context.SaveChangesAsync();
        }
        public async Task AddCommentLikeAsync(int commentId)
        {
            var like = new CommentLike { CommentId = commentId };
            _context.CommentLikes.Add(like);
            await _context.SaveChangesAsync();
        }
    }
}
