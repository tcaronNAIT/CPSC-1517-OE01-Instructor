using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace ExampleWebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private services fields and class constructor
        private readonly ILogger<PartialFilterSearchModel> _logger;
        private readonly TerritoryServices _territoryServices;

        public PartialFilterSearchModel(ILogger<PartialFilterSearchModel> logger, TerritoryServices territoryServices)
        {
            _logger = logger;
            _territoryServices = territoryServices;
        }
        #endregion

        [TempData]
        public string partialSearchFeedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public string partialSearchText { get; set; }

        public List<Territory> TerritoryResults { get; set; } = new List<Territory>();

        public void OnGet()
        {
                if(!string.IsNullOrEmpty(partialSearchText))
			{
                TerritoryResults = _territoryServices.GetByPartialDescription(partialSearchText);
			}
        }

        public IActionResult OnPostSearch()
        {
            if (string.IsNullOrEmpty(partialSearchText))
            {
                partialSearchFeedback = "Required: Search string is empty.";
            }

            return RedirectToPage(new { partialSearchText = partialSearchText });
        }
    }
}
