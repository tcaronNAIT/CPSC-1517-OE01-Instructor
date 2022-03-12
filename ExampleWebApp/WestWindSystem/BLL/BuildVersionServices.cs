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
    public class BuildVersionServices
    {
        //variable to hold an instance of the context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal BuildVersionServices(WestWindContext regContext)
        {
            _context = regContext;
        }

        //create a method (services) that will retrieve the BuildVersion records
        //this will be called from the web app (Pages), so it needs to be public
        //this becomes the start of our class library
        public BuildVersion GetBuildVersion()
        {
            //Go into our context instance, use the DbSet for the BuildVersion data
            //use this set to retrieve the data we want

            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;
        }
    }
}
