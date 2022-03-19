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
	public class TerritoryServices
	{
        #region Context Connection
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal TerritoryServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #endregion

        #region Queries

        //query by a string
        public List<Territory> GetByPartialDescription(string partialDescription)
		{
            return _context.Territories
                                    .Where(territory => territory.TerritoryDescription.Contains(partialDescription))
                                    .OrderBy(territory => territory.TerritoryDescription).ToList();
		}

        #endregion
    }
}
