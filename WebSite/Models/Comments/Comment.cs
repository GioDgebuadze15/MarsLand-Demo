using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Edited { get; set; }

        public string GetTimeDuration()
        {

            TimeSpan diff = DateTime.Now - Created;
            string result="";

            if(diff.Days != 0)
            {
                result = $"{diff.Days}d {diff.Hours}h {diff.Minutes}m ago";
                    return result;
            }
            if (diff.Hours != 0)
            {
                result = $"{diff.Hours}h {diff.Minutes}m ago";
                return result;
            }
            if (diff.Minutes != 0)
            {
                result = $"{diff.Minutes}m ago";
                return result;
            }
            return result;
        }
    }
}
