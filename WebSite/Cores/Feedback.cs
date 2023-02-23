using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Cores
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int StarLevel { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

    }
}
