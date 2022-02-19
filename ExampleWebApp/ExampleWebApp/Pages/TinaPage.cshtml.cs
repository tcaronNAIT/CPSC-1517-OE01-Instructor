using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleWebApp.Pages
{
    public class TinaPageModel : PageModel
    {
        [TempData]
        public string Feedback { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public double Rating { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FavouriteCourse { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public string Comments { get; set; } = null!;
        public void OnGet()
        {
            
        }

        //OnPost can be IActionResult or void.
        //Use IActionResult when you want to call OnGet
        public IActionResult OnPost()
        {
            Feedback = $"Rating {Rating}, Course {FavouriteCourse} \n Comments: \n {Comments}";
            return RedirectToPage(new {Rating = Rating, FavouriteCourse = FavouriteCourse, Comments = Comments});
        }
    }
}
