using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.ViewModels
{
    public class AddCommentViewModel
    {
        public string UserName { get; set; }
        public Guid ReviewId { get; set; }

        [MaxLength(1000, ErrorMessage ="Максимальная длинна 1000 символов")]
        public string Text { get; set; }
    }
}
