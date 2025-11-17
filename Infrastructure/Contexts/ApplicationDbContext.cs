using Domain.Entities;
using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Contexts
{


    /*
    🔥 1) Why inherit BaseDbContext?
    public class ApplicationDbContext : BaseDbContext

    Simple words:
    👉 BaseDbContext ne sari heavy duty ki hui hai
    (Yani multi-tenant switching, identity DB setup, connection string tenant-wise change)

    👉 ApplicationDbContext ko sirf apna normal data ka kaam karna hai
    (e.g., Schools table, Students table, Teachers table, etc.)

    Ye bilkul baap–beta relationship jaisa hai:
    Baap (BaseDbContext) → heavy kaam, jugaar, setup
    Beta (ApplicationDbContext) → actual data operations 
    */
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(
            IMultiTenantContextAccessor<ABCSchoolTenantInfo> tenantInfoContextAccessor,
            DbContextOptions<ApplicationDbContext> options)
            : base(tenantInfoContextAccessor, options)
        {
        }

        /*
            🔥 2) Constructor — OOP Understanding
            public ApplicationDbContext(
                IMultiTenantContextAccessor<ABCSchoolTenantInfo> tenantInfoContextAccessor,
                DbContextOptions<ApplicationDbContext> options)
                : base(tenantInfoContextAccessor, options)
            {
            }

            What’s happening?

            ✔️ Dependency Injection se mil raha hai:
            Current tenant ka context → tenantInfoContextAccessor
            DBContext options → logs, lazy loading, tracking rules etc.

            ✔️ We pass these to BaseDbContext:
            : base(tenantInfoContextAccessor, options)

            So BaseDbContext karega:
            Tenant detect
            Connection string apply
            Identity tables configure
            Configurations apply
            ApplicationDbContext ko khud kuch nahi karna.
            Woh sirf BaseDbContext ka ready-made environment use karega.
         */

        public DbSet<School> Schools => Set<School>();
    }
}
