using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Repository;
using PortfolioProject.Services;

namespace PortfolioProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Blog()
        {
            var posts = _context.BlogPosts.ToList();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> LikeComment(int postId)
        {
  
            _blogService.AddPostLikeAsync(postId);


            return Ok();
        }
    }
}
