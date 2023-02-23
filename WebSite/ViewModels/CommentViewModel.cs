using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Models;
using WebSite.Models.Comments;

namespace WebSite.ViewModels
{
    public class CommentViewModel
    {
        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }

        public int? MainCommentId { get; set; }
        public MainComment MainComment{ get; set; }
        public List<MainComment> MainComments { get; set; }

        [Required]
        public string CommentText { get; set; }

        public int? SubCommentId { get; set; }
        public SubComment SubComment { get; set; }
        public List<SubComment> SubComments { get; set; }

        public int? NumOfComments { get; set; }

        public int? NumOfLikes { get; set; }
        
        public bool? HasAlreadyLiked { get; set; }
    }
}
