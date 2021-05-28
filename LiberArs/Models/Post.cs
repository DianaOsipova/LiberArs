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
        [Display(Name = "Тема")]
        [Required(ErrorMessage = "Введите тему")]
        public string Theme { get; set; }
      
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Название картинки")]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Добавьте описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [NotMapped]
        [Display(Name = "Загрузить")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime DateTime { get; set; }

     

        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [ScaffoldColumn(false)]
        public User User { get; set; }


    }
}
