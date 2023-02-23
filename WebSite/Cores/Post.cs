using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WebSite.Enums;
using WebSite.Models;
using WebSite.Models.Comments;

namespace WebSite.Cores
{
    public class Post
    {
        public int PostId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Edited { get; set; }

        public PostPrivacyEnum Privacy { get; set; }

        public PostImageModel PostImage { get; set; }

        public List<MainComment> MainComments { get; set; }

        public List<PostLike> PostLikes { get; set; }

        [NotMapped]
        public int GetTotalComments { get; set; }
    }
}
