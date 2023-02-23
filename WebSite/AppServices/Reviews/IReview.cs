using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Models;

namespace WebSite.AppServices.Reviews
{
    public interface IReview
    {
        Task<Feedback> SubmitFeedback(string feedbackName, string feedbackText, int starLevel);
        public PageAverageStarLevel CalculateAverageStarLevel();
        Task<ContactAdministrator> SubmitSupportMessage(string name,string email,string message);
    }
}
