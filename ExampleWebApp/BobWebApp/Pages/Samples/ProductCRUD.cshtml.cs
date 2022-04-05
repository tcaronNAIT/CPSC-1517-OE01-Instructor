using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WebApp.Helpers;
#endregion

namespace ExampleWebApp.Pages.Samples
{
    public class ProductCRUDModel : PageModel
    {
        #region Private services fields and class constructor
        private readonly ILogger<OrdersModel> _logger;
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;

        public ProductCRUDModel(ILogger<OrdersModel> logger, CategoryServices categoryServices, ProductServices productServices, SupplierServices supplierServices)
        {
            _logger = logger;
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;
        }
        #endregion

        #region Feedback and Error Messages
        public string Feedback { get; set; }

        public bool HasFeedback => !string.IsNullOrWhiteSpace(Feedback);

        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);

        #endregion
        [BindProperty(SupportsGet = true)]
        public int? productID { get; set; }

        [BindProperty]
        public Product ProductInfo { get; set; }

        [BindProperty]
        public List<Category> CategoryList { get; set; }

        [BindProperty]
        public List<Supplier> SuppierList { get; set; }


        public void OnGet()
        {
        }
    }
}
