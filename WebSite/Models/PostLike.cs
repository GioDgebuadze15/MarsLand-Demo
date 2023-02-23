using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;

namespace WebSite.Models
{
    public class PostLike
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string LikerId { get; set; }
        public AppUser User { get; set; }

        public DateTime Create { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
