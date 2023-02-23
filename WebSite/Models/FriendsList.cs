using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.Cores;

namespace WebSite.Models
{
    public class FriendsList
    {
        
        public virtual AppUser User { get; set; }

        public virtual UserInfo UserInfo { get; set; }

        public virtual ProfileImageModel ProfileImageModel { get; set; }

        public virtual CoverImageModel CoverImageModel { get; set; }

    }
}
