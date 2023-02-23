using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Models;

namespace WebSite.AppServices.Reviews
{
    public class Review: IReview
    {
        private readonly AppDbContext _regRepository;

        public Review(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }
        public async Task<Feedback> SubmitFeedback(string feedbackName, string feedbackText, int starLevel)
        {
            var feedback = new Feedback
            {
                Name = feedbackName,
                Text=feedbackText,
                StarLevel=starLevel,
                Timestamp = DateTime.Now

            };

            

            
            _regRepository.Feedbacks.Add(feedback);
            await _regRepository.SaveChangesAsync();

            

            
            return feedback;
        }

        public PageAverageStarLevel CalculateAverageStarLevel()
        {
            double sumStarLevels = _regRepository.Feedbacks
                                            .Select(x => x.StarLevel)
                                            .Sum();
            double numberOfReviewers = _regRepository.Feedbacks
                                             .Count();

            if(numberOfReviewers != 0)
            {
                double averageStarLevel = (sumStarLevels / numberOfReviewers);

                averageStarLevel = Math.Round(averageStarLevel, 2);
                int starLevelToDisplay = (int)Math.Round(averageStarLevel, MidpointRounding.AwayFromZero);

                var pageAverageStarLevel = new PageAverageStarLevel
                {
                    AverageStarLevel = averageStarLevel,
                    StarLevelToDisplay = starLevelToDisplay
                };
                return pageAverageStarLevel;
            }

            return new PageAverageStarLevel();
           
        }

        public async Task<ContactAdministrator> SubmitSupportMessage(string name, string email, string message)
        {
            var supportMessage = new ContactAdministrator
            {
                Name=name,
                Email= email,
                Text = message,
                Timestamp = DateTime.Now
            };

            _regRepository.SupportMessages.Add(supportMessage);
            await _regRepository.SaveChangesAsync();

            return supportMessage;
        }
    }
}
