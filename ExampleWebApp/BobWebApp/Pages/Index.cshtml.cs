using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace ExampleWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildVersionServices;

        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices)
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
        }

        [TempData]
        public string MyName { get; set; }

        public BuildVersion BuildVersionInfo { get; set; }

        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty(SupportsGet = true)]
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

            BuildVersionInfo = _buildVersionServices.GetBuildVersion();
        }

        public IActionResult OnPostAButton()
        {
            string buttonValue = Request.Form["theButton"];
            FeedbackMessage = $"The A handler button was pressed and the value was: {number}";
            return RedirectToPage(new { number = number });
        }

        public IActionResult OnPostBButton()
        {
            string buttonValue = Request.Form["theButton"];
            FeedbackMessage = $"The B handler button was pressed and the value was: {number}";
            return RedirectToPage(new { number = number });
        }  
    }
}