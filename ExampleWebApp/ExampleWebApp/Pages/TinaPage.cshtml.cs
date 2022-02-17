using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleWebApp.Pages
{
    public class TinaPageModel : PageModel
    {
        public string Whatever { get; set; }
        public void OnGet()
        {
            Whatever = "";
        }
    }
}
