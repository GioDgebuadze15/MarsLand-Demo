using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;

namespace WebSite.Models
{
    
    public class PageAverageStarLevel
    {
        public double AverageStarLevel { get; set; }

        public int StarLevelToDisplay { get; set; }
    }
}
