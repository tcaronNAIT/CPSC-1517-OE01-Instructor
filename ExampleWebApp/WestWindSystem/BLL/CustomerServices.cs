using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class CustomerServices
    {
        #region Context Connection
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal CustomerServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #endregion

        #region Queries
        public List<Customer> Customer_List()
        {
            IEnumerable<Customer> info = _context.Customers.OrderBy(row => row.CompanyName);

            return info.ToList();
        }
        #endregion
    }
}
