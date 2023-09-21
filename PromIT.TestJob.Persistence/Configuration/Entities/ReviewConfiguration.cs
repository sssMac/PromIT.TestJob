using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Persistence.Configuration.Entities
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "JohnDoe",
                    OrgName = "ABC Inc.",
                    OrgAddress = null,
                    WhatLike = "Friendly colleagues",
                    WhatDislike = "Long commute",
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "JaneSmith",
                    OrgName = "XYZ Corp.",
                    OrgAddress = "456 Elm St",
                    WhatLike = "Flexible hours",
                    WhatDislike = null,
                    Rating = 5,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "BobJohnson",
                    OrgName = "LMN Ltd.",
                    OrgAddress = "789 Oak St",
                    WhatLike = "Great benefits",
                    WhatDislike = "No remote work",
                    Rating = 3,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "AliceJohnson",
                    OrgName = "PQR Co.",
                    OrgAddress = null,
                    WhatLike = "Work-life balance",
                    WhatDislike = null,
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "EveAdams",
                    OrgName = "RST Group",
                    OrgAddress = "202 Pine St",
                    WhatLike = "Opportunities for growth",
                    WhatDislike = "High workload",
                    Rating = 3,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "DavidLee",
                    OrgName = "UVW Inc.",
                    OrgAddress = "303 Cedar St",
                    WhatLike = "Diverse team",
                    WhatDislike = "Lack of training",
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "GraceWang",
                    OrgName = "HIJ Corporation",
                    OrgAddress = "404 Birch St",
                    WhatLike = "Innovative projects",
                    WhatDislike = "Micromanagement",
                    Rating = 5,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "JohnDoe",
                    OrgName = "ABC Inc.",
                    OrgAddress = null,
                    WhatLike = "Friendly colleagues",
                    WhatDislike = "Long commute",
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "JaneSmith",
                    OrgName = "XYZ Corp.",
                    OrgAddress = "456 Elm St",
                    WhatLike = "Flexible hours",
                    WhatDislike = null,
                    Rating = 5,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "BobJohnson",
                    OrgName = "LMN Ltd.",
                    OrgAddress = "789 Oak St",
                    WhatLike = "Great benefits",
                    WhatDislike = "No remote work",
                    Rating = 3,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "AliceJohnson",
                    OrgName = "PQR Co.",
                    OrgAddress = null,
                    WhatLike = "Work-life balance",
                    WhatDislike = null,
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "EveAdams",
                    OrgName = "RST Group",
                    OrgAddress = "202 Pine St",
                    WhatLike = "Opportunities for growth",
                    WhatDislike = "High workload",
                    Rating = 3,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "DavidLee",
                    OrgName = "UVW Inc.",
                    OrgAddress = "303 Cedar St",
                    WhatLike = "Diverse team",
                    WhatDislike = "Lack of training",
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "GraceWang",
                    OrgName = "HIJ Corporation",
                    OrgAddress = null,
                    WhatLike = "Innovative projects",
                    WhatDislike = "Micromanagement",
                    Rating = 5,
                    CreatedAt = GenerateRandomDate()
                }
            );
        }

        private DateTime GenerateRandomDate()
        {
            Random random = new Random();
            DateTime startDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int range = (DateTime.UtcNow - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
    }
}
