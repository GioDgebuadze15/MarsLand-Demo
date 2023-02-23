using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;

namespace WebSite.Models.Comments
{
    public class MainComment: Comment
    {
        public List<SubComment> SubComments { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
