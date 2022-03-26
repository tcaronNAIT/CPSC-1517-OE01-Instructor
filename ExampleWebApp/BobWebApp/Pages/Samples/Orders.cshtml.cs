using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WebApp.Helpers;
#endregion

namespace ExampleWebApp.Pages.Samples
{
    public class OrdersModel : PageModel
    {
        #region Private services fields and class constructor
        private readonly ILogger<OrdersModel> _logger;
        private readonly OrderServices _orderServices;
        private readonly CustomerServices _customerServices;

        public OrdersModel(ILogger<OrdersModel> logger, OrderServices orderServices, CustomerServices customerServices)
        {
            _logger = logger;
            _orderServices = orderServices;
            _customerServices = customerServices;
        }
        #endregion

        #region Paginator
        //set the desired page size
        private const int PAGE_SIZE = 5;
        //be able to hold an instance of the Paginator Class
        public Paginator Pager { get; set; }
        #endregion

        [TempData]
        public string orderFeedback { get; set; }

        public List<Order> OrderResults { get; set; } = new List<Order>();

        [BindProperty(SupportsGet = true)]
        public string searchCustomerID { get; set; }

        public List<Customer> CustomerList { get; set; } = new List<Customer>();

        public void OnGet(int? currentPage)
        {
            CustomerList = _customerServices.Customer_List();

            if (!string.IsNullOrEmpty(searchCustomerID))
            {
                int totalCount;
                int pageNumber = currentPage.HasValue ? currentPage.Value : 1;
                PageState current = new(pageNumber, PAGE_SIZE);
                OrderResults = _orderServices.GetOrderByCustomerID(searchCustomerID, pageNumber, PAGE_SIZE, out totalCount);
                Pager = new Paginator(totalCount, current);
            }
            
        }

        public IActionResult OnPostDDLSearch()
        {
            if (string.IsNullOrEmpty(searchCustomerID))
            {
                orderFeedback = "Required: Must select a Customer.";
            }
            return RedirectToPage(new { searchCustomerID = searchCustomerID });
        }
    }
}
