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

        [BindProperty]
        public int regionID { get; set; }

        public Region regionInfo { get; set; }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            //Region is greater than 0
            if(regionID <=0)
            {
                //If not gt0 then -> Tell the user they must provide a positive whole number
                FeedbackMessage = "Region ID must be a positive non-zero number.";
            }
            else
            {
                //If it is gt0 -> Query for the region
                regionInfo = _regionServices.Region_GetById(regionID);

                //Check if the return is a null
                if(regionInfo == null)
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
    }
}
