using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using comp4513_blogsite.Data;
using comp4513_blogsite.Models;

namespace comp4513_blogsite.Pages;

public class IndexModel : PageModel
{
    private readonly BlogContext _context;

    public IndexModel(BlogContext context)
    {
        _context = context;
    }

    public List<Post> Posts { get; set; } = new();
    public async Task OnGet()
    {
        Posts = await _context.Posts
        .Include(p => p.Author)
        .Include(p => p.Category)
        .ToListAsync();
    }
}
