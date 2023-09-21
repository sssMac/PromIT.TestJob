using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.ViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        
        public string UserName { get; set; }
        public string OrgName { get; set; }
        public string? OrgAddress { get; set; }
        public string WhatLike { get; set; }
        public string? WhatDislike { get; set; }
        public int Rating { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
