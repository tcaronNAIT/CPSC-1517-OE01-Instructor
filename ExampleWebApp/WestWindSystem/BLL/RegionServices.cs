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
    public class RegionServices
    {
        #region Context Connection
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal RegionServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #endregion

        #region Queries

        public Region Region_GetById(int regionID)
        {
            Region info = _context.Regions
                            .Where(row => row.RegionID == regionID)
                            .FirstOrDefault();

        //foreach(Region row in RegionCollection)
        //{
        //  if(row.RegionID == regionID)
        //  {  do something to return the record }
        //}

            return info;
        }

        public List<Region> Region_List()
        {
            IEnumerable<Region> info = _context.Regions.OrderBy(row => row.RegionDescription);

            return info.ToList();
        }

        #endregion
    }
}
