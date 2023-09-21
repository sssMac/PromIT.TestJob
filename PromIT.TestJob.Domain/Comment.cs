using PromIT.TestJob.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Domain
{
    public class Comment : BaseDomainEntity
    {
        public string UserName { get; set; }
        public Guid ReviewId { get; set; }
        public string Text { get; set;}
    }
}
