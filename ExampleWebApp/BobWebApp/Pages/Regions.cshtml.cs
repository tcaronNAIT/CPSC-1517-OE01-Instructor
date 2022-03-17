using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace ExampleWebApp.Pages
{
    public class RegionsModel : PageModel
    {
        #region Private services fields and class constructor
        private readonly ILogger<RegionsModel> _logger;
        private readonly RegionServices _regionServices;
        
        public RegionsModel(ILogger<RegionsModel> logger, RegionServices regionServices)
        {
            _logger = logger;
            _regionServices = regionServices;
        }
        #endregion

        [TempData]
        public string FeedbackMessage { get; set; }

        //BindProperty is bond to the asp-for help tag
        //Adding SupportGet = true will allow this property to be match to
        //a routing parameter of the same name.
        [BindProperty(SupportsGet = true)]
        public int regionID { get; set; }

        public List<Region> RegionList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int selectedRegionID { get; set; }
        public Region regionInfo { get; set; }
        public void OnGet()
        {
            //Check first for region id > 0
            if (regionID > 0)
            {
                //Region is greater than 0
                if (regionID <= 0)
                {
                    //If not gt0 then -> Tell the user they must provide a positive whole number
                    FeedbackMessage = "Region ID must be a positive non-zero number.";
                }
                else
                {
                    //If it is gt0 -> Query for the region
                    regionInfo = _regionServices.Region_GetById(regionID);

                    //Check if the return is a null
                    if (regionInfo == null)
                    {
                        //If the return is a null -> Tell the user the region id was not valid.
                        FeedbackMessage = "Region ID is not valid. No region exists with the supplied ID.";
                    }
                    else
                    {
                        //If the return is not null -> Tell the user the region id and region description!
                        FeedbackMessage = $"ID: {regionInfo.RegionID} Description: {regionInfo.RegionDescription}";
                    }
                }
            }
            RegionList = _regionServices.Region_List();
        }

        public void OnPost()
        {
            FeedbackMessage = "WARNING!!! No OnPost page handler found. Execution defaulted to the coded OnPost()";
        }

        public IActionResult OnPostFetch()
        {
            if (regionID < 1)
            {
                FeedbackMessage = "Region ID must be a positive non-zero number.";
            }
                return RedirectToPage(new { regionID = regionID });
        }

        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            //regionID = 0;
            ModelState.Clear();
            return RedirectToPage(new {regionID = (int?)null});
        }
    }
}
