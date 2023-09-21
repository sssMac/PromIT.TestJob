using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        
        public string UserName { get; set; }
        public Guid ReviewId { get; set; }
        public string Text { get; set; }
        public Review Review { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
