using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [TempData]
        public string MyName { get; set; }

        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public int number { get; set; }

        public void OnGet()
        {
            Random random = new Random();
            int value = random.Next(0, 100);

            if (value % 2 == 0)
            {
                MyName = $"To CPSC 1517 - Razor World! ({value})";
            }
            else
            {
                MyName = null;
            }
        }

        public IActionResult OnPost()
        {
            string buttonValue = Request.Form["theButton"];
            FeedbackMessage = buttonValue;
            return RedirectToPage();
        }
    }
}