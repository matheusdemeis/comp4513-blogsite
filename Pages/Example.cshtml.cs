using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace comp4513_blogsite.Pages;

public class ExampleModel : PageModel
{
    [BindProperty]
    public string Name { get; set; } = "Alice";

    public void OnGet()
    {
        ViewData["Date"] = DateTime.Today.ToString("ddd, MM yyyy");
    }

    public IActionResult OnPost()
    {
        ViewData["Date"] = DateTime.Today.ToString("ddd, MM yyyy");
        return Page();
    }
}