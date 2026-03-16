using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using comp4513_blogsite.Data;
using comp4513_blogsite.Models;

namespace comp4513_blogsite.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly BlogContext _context;

        public CreateModel(BlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        public SelectList AuthorOptions { get; set; } = default!;
        public SelectList CategoryOptions { get; set; } = default!;

        public IActionResult OnGet()
        {
            LoadSelections();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelections();
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        private void LoadSelections()
        {
            AuthorOptions = new SelectList(_context.Authors.ToList(), "Id", "Name");
            CategoryOptions = new SelectList(_context.Categories.ToList(), "Id", "Name");
        }
    }
}