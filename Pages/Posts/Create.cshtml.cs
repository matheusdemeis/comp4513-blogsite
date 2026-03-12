using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public SelectList AuthorOptions { get; set; }

        public SelectList CategoryOptions { get; set; }

        public IActionResult OnGet()
        {
            AuthorOptions = new SelectList(_context.Authors, "Id", "Name");
            CategoryOptions = new SelectList (_context.Categories, nameof(Category.Id), nameof(Category.Name));
            return Page();
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newPost = new Post();

            if (await TryUpdateModelAsync<Post>(
                newPost,
                "post", //prefix
                p => p.Title, p => p.Content,
                p => p.AuthorId, p => p.Category.Id
            ))
            {
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
