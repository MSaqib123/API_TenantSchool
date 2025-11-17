using Domain.Entities;
using Finbuckle.MultiTenant;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class DbConfigurations
    {
        internal class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder
                    .ToTable("Users", "Identity")
                    .IsMultiTenant();
            }
        }

        internal class ApplicationRoleConfig : IEntityTypeConfiguration<ApplicationRole>
        {
            public void Configure(EntityTypeBuilder<ApplicationRole> builder)
            {
                builder
                    .ToTable("Roles", "Identity")
                    .IsMultiTenant();
            }
        }
        internal class ApplicationRoleClaimConfig : IEntityTypeConfiguration<ApplicationRoleClaim>
        {
            public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder) =>
                builder
                    .ToTable("RoleClaims", "Identity")
                    .IsMultiTenant();
        }

        internal class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder) =>
                builder
                    .ToTable("UserRoles", "Identity")
                    .IsMultiTenant();
        }

        internal class IdentityUserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder) =>
                builder
                    .ToTable("UserClaims", "Identity")
                    .IsMultiTenant();
        }

        internal class IdentityUserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder) =>
                builder
                    .ToTable("UserLogins", "Identity")
                    .IsMultiTenant();
        }

        internal class IdentityUserTokenConfig : IEntityTypeConfiguration<IdentityUserToken<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder) =>
                builder
                    .ToTable("UserTokens", "Identity")
                    .IsMultiTenant();
        }



        /*
            ApplyConfigurationsFromAssembly kya karta hai?

            Entity Framework ko manually batane ki zaroorat nahi padti:

            modelBuilder.ApplyConfiguration(new SchoolConfig());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());


            Iski jagah aap simply likhte ho:

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            Yeh EF Core ko bolne jaisa hai:
            👉 "Bhai, is poori assembly (project) mein jitni bhi IEntityTypeConfiguration wali classes hain, sab apply kar do."

            Iska matlab:

            EF automatically SchoolConfig,
            ApplicationUserConfig,
            ApplicationRoleConfig,
            IdentityUserRoleConfig,
            waqaira... sab pick karke apply kar deta hai.

            Tumhe har config manually apply nahi karni padti.
            Bas ek line — sab kaam ho gaya. 
        */


        internal class SchoolConfig : IEntityTypeConfiguration<School>
        {
            public void Configure(EntityTypeBuilder<School> builder)
            {
                builder
                    .ToTable("Schools", "Academics")
                    .IsMultiTenant();

                builder
                    .Property(school => school.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            }
        }
    }
}
