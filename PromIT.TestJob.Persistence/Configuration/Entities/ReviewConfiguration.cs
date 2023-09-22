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
                    WhatLike = "Est. Id id quis, tortor, ipsum sodales interdum in lacinia nunc integer orci, orci, in mattis non ultricies. Eleifend pe",
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
                    WhatLike = "Et mattis dictumst. Et efficitur augue sapien pulvinar amet, et. Augue nulla et odio. Leo, sit hac lectus nunc lectus qu",
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
                    WhatLike = "Urna platea eget mauris sit dictum et non est. Non non ultricies. Urna orci, dictum morbi hac mauris non sit vulputate l",
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
                    WhatDislike = "Urna platea eget mauris sit dictum et non est. Non non ultricies. Urna orci, dictum morbi hac mauris non sit vulputate l",
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "GraceWang",
                    OrgName = "HIJ Corporation",
                    OrgAddress = "404 Birch St",
                    WhatLike = "Tortor, tempus amet dictum non amet cursus vel luctus amet vitae leo, mattis cras integer vulputate ex. Cursus ornare et",
                    WhatDislike = "Orci, velit platea vulputate sit ultricies. Orci, vitae dapibus dictum habitasse amet, id morbi lorem non integer eget e",
                    Rating = 5,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "JohnDoe",
                    OrgName = "ABC Inc.",
                    OrgAddress = null,
                    WhatLike = "Accumsan molestie platea luctus vestibulum pulvinar et. Vestibulum sapien morbi dolor ornare sodales elit. Justo imperdi",
                    WhatDislike = "Lorem molestie ut. Vulputate sapien vitae malesuada amet, efficitur mattis non sodales sed dapibus leo, amet, quam, sed ",
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "JaneSmith",
                    OrgName = "XYZ Corp.",
                    OrgAddress = "456 Elm St",
                    WhatLike = "Vestibulum sapien amet, non cras molestie ex. Sed justo in tempus amet venenatis dictumst. Eget malesuada est. Malesuada",
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
                    WhatLike = "Platea eget et interdum in et. Tempus pulvinar sed mattis ipsum venenatis et augue pellentesque faucibus. Eleifend vitae",
                    WhatDislike = "Dictum amet, libero, faucibus. Eget nisi augue venenatis nunc non sed sit elit. Velit efficitur sodales et justo faucibu",
                    Rating = 3,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "AliceJohnson",
                    OrgName = "PQR Co.",
                    OrgAddress = null,
                    WhatLike = "Nisi non odio. Integer quam, amet, pellentesque vulputate ipsum velit vestibulum mattis mauris urna risus dolor augue le",
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
                    WhatLike = "Non molestie amet, sodales vulputate pellentesque mauris lectus vestibulum lacinia amet, mauris cursus nulla ultricies. ",
                    WhatDislike = "Dictum. Aenean ultricies. Mauris sit sodales amet, nulla nisi in vitae vulputate pellentesque dictumst. Est. Pellentesqu",
                    Rating = 4,
                    CreatedAt = GenerateRandomDate()
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    UserName = "GraceWang",
                    OrgName = "HIJ Corporation",
                    OrgAddress = null,
                    WhatLike = "Ignorant saw her her drawings marriage laughter. Case oh an that or away sigh do here upon. Acuteness you exquisite ourselves now end forfeited. Enquire ye without it garrets up himself. Interest our nor received followed was. Cultivated an up solicitude mr unpleasant. ",
                    WhatDislike = "Forth days said a greater given years fly wherein for fish Fourth sea land stars. Every. Gathering together fruit. Moving male after image form said in fifth very from you'll one. Forth. You'll she'd i set it saw Make waters.",
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
