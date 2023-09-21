using PromIT.TestJob.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Domain
{
    public class Review : BaseDomainEntity
    {
        public string UserName { get; set; }
        public string OrgName { get; set; }
        public string? OrgAddress { get; set; }
        public string WhatLike { get; set; }
        public string? WhatDislike { get; set; }
        public int Rating { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
