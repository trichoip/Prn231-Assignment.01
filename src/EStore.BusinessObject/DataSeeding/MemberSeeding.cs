using EStore.BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.BusinessObject.DataSeeding
{
    public class MemberSeeding : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasData(
                new Member
                {
                    MemberId = 1,
                    Email = "member1@fstore.com",
                    CompanyName = "KMS",
                    City = "HCM",
                    Country = "Viet nam",
                    Password = "1"

                },
                new Member
                {
                    MemberId = 2,
                    Email = "member2@fstore.com",
                    CompanyName = "CyberSoft",
                    City = "HCM",
                    Country = "Viet nam",
                    Password = "1"
                },
                new Member
                {
                    MemberId = 3,
                    Email = "1",
                    CompanyName = "CyberSoft",
                    City = "HCM",
                    Country = "Viet nam",
                    Password = "1"
                }
            );
        }
    }
}
