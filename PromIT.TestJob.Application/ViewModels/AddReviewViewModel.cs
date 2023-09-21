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
        [Display(Name = "Никнейм")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Название организации")]
        public string OrgName { get; set; }

        [Display(Name = "Адресс организации")]
        public string? OrgAddress { get; set; }

        [Required]
        [Display(Name = "Что понравилось?")]
        public string WhatLike { get; set; }

        [Display(Name = "Что не понравилось?")]
        public string? WhatDislike { get; set; }

        [Required]
        [Range(0,5)]
        public int Rating { get; set; }
    }
}
