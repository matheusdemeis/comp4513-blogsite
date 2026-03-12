using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using comp4513_blogsite.Data;
using comp4513_blogsite.Models;

namespace comp4513_blogsite.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly comp4513_blogsite.Data.BlogContext _context;

        public DetailsModel(comp4513_blogsite.Data.BlogContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FirstOrDefaultAsync(m => m.Id == id);

            if (post is not null)
            {
                Post = post;

                return Page();
            }

            return NotFound();
        }
    }
}
