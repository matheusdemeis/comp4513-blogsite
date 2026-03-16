using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using comp4513_blogsite.Data;
using comp4513_blogsite.Models;

namespace comp4513_blogsite.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly BlogContext _context;

        public DetailsModel(BlogContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;
        public List<Post> RelatedPosts { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            Post = post;

            RelatedPosts = await _context.Posts
                .Where(p => p.CategoryId == Post.CategoryId && p.Id != Post.Id)
                .ToListAsync();

            return Page();
        }
    }
}