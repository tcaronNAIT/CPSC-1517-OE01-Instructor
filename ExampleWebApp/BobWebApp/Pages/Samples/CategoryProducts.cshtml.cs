using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WebApp.Helpers;
#endregion

namespace ExampleWebApp.Pages.Samples
{
    public class CategoryProductsModel : PageModel
    {
        #region Private services fields and class constructor
        private readonly ILogger<OrdersModel> _logger;
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;

        public CategoryProductsModel(ILogger<OrdersModel> logger, CategoryServices categoryServices, ProductServices productServices, SupplierServices supplierServices)
        {
            _logger = logger;
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;
        }
        #endregion

        [TempData]
        public string Feedback { get; set; }


        public void OnGet()
        {
        }
    }
}
