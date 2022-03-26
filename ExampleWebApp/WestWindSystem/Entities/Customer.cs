using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindSystem.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }
    }
}
