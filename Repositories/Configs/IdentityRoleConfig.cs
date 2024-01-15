using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole(){Name = "User", NormalizedName = "USER"},
            new IdentityRole(){Name = "Editor", NormalizedName = "EDITOR"},
            new IdentityRole(){Name = "Admin", NormalizedName = "ADMIN"});
        
    }
}
