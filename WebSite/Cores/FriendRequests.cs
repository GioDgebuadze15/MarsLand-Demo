using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.Enums;
using WebSite.Models;

namespace WebSite.Cores
{
    public class FriendRequests  
    {
        public FriendRequests()
        {
            FriendUsers = new List<FriendUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public FriendRequestEnum FriendStatus { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }

        public DateTime? ResponseTime { get; set; }

        public ICollection<FriendUser> FriendUsers { get; set; }


    }
}
