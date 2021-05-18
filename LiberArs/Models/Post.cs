using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiberArs.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Theme { get; set; }
      

       

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Upload")]
        public IFormFile ImageFile { get; set; }

        public DateTime DateTime { get; set; }

     

        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [ScaffoldColumn(false)]
        public User User { get; set; }


    }
}
