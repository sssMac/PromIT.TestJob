using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.ViewModels
{
    public class AddReviewViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        [StringLength(50, ErrorMessage = "Максимальная длинна 50 символов")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Название организации")]
        [StringLength(50, ErrorMessage = "Максимальная длинна 50 символов")]
        public string OrgName { get; set; }

        [Display(Name = "Адресс организации")]
        [StringLength(50, ErrorMessage = "Максимальная длинна 50 символов")]
        public string? OrgAddress { get; set; }

        [Required]
        [Display(Name = "Что понравилось?")]
        [MaxLength(500, ErrorMessage = "Максимальная длинна 500 символов")]
        [MinLength(100, ErrorMessage = "Минимальная длинна 100 символов")]
        public string WhatLike { get; set; }

        [Display(Name = "Что не понравилось?")]
        [MaxLength(500, ErrorMessage = "Максимальная длинна 500 символов")]
        [MinLength(100, ErrorMessage = "Минимальная длинна 100 символов")]
        public string? WhatDislike { get; set; }

        [Required]
        [Display(Name = "Рейтинг")]
        [Range(1,5, ErrorMessage = "Выберите оценку")]
        public int Rating { get; set; }
    }
}
