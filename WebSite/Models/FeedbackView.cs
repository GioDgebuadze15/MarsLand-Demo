using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;

namespace WebSite.Models
{
    public class FeedbackView
    {
        public PageAverageStarLevel PageAverageStarLevel { get; set; }
        public List<Feedback> Feedback { get; set; }
    }
}
