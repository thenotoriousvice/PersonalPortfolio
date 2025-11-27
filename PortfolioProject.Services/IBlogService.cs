using PortfolioProject.Repository.Models;

namespace PortfolioProject.Services
{
    public interface IBlogService
    {

        Task<List<BlogPost>> GetAllPostsAsync();
        Task<BlogPost?> GetPostAsync(int id);

        Task AddCommentAsync(Comment comment);

        Task AddReplyAsync(Comment reply);

        Task AddPostLikeAsync(int postId);

        Task AddCommentLikeAsync(int commentId);
    }
}
