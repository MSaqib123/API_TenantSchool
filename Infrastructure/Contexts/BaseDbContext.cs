using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Infrastructure.Identity.Models;
using Infrastructure.Tenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Contexts
{

    //✔️ 2) BaseDbContext(Tenant Specific Database Context)
    /*
        Yahan se asli game start hoti hai.
        BaseDbContext ka kaam
        Finbuckle se tenant pick karna
        Tenant ki connection string read karna
        Us connection se database select karna
        Saaare Identity tables bhi tenant-wise segregate karna
        Jo actual ERP / school ka data hai wo yahan hoga

       
     */
    public abstract class BaseDbContext :
        MultiTenantIdentityDbContext<
            ApplicationUser,
            ApplicationRole,
            string,
            IdentityUserClaim<string>,
            IdentityUserRole<string>,
            IdentityUserLogin<string>,
            ApplicationRoleClaim,
            IdentityUserToken<string>>
    {
        


        private new ABCSchoolTenantInfo TenantInfo { get; set; }

        protected BaseDbContext(IMultiTenantContextAccessor<ABCSchoolTenantInfo> tenantInfoContextAccessor, DbContextOptions options)
            : base(tenantInfoContextAccessor, options)
        {
            TenantInfo = tenantInfoContextAccessor.MultiTenantContext.TenantInfo;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!string.IsNullOrEmpty(TenantInfo?.ConnectionString))
            {
                optionsBuilder.UseSqlServer(TenantInfo.ConnectionString, options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            }

            //================================
            //Ye line tenant database ka switch on-the-fly karti hai.
            //Jis tenant ka request aaye → uska db load hoga.

            //Easy Example:
            //KarachiSchool ka connection string → DB switch to KarachiSchoolDB
            //LarkanaSchool ka connection string → DB switch to LarkanaSchoolDB
            //Each school → separate DB.
        }




        /*
            🔥 Final Jugaar Summary (Easy Version)
            Bhai BaseDbContext basically ye kaam karta hai:

            ✔️ 1. Har request se tenant identify karta hai
            (tenantInfoContextAccessor se)

            ✔️ 2. Tenant ka connection string pick karta hai
            (every tenant → separate database)

            ✔️ 3. Identity tables per tenant create karta hai
            (users, roles, claims, tokens)

            ✔️ 4. Har entity ka configuration apply karta hai
            (ApplyConfigurationsFromAssembly)

            ✔️ 5. Yeh class abstract hai →
            is se inheriting class hi real DBContext banegi
            (misal: ApplicationDbContext)
         
         */

    }
}
