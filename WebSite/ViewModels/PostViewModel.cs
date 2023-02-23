using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebSite.Cores;
using WebSite.Enums;

namespace WebSite.ViewModels
{
    public class PostViewModel
    {
        
        public int PostId { get; set; }

        [Required]
        public string Text { get; set; }

        public string ImageName { get; set; }

        public IFormFile ImageFile { get; set; }

        public DateTime Created { get; set; }

        public DateTime Edited { get; set; }

        public PostPrivacyEnum Privacy { get; set; }

        public List<Post> Posts { get; set; }

    }
}
