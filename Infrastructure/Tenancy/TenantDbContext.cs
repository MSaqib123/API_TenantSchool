using Domain.Entities;
using Finbuckle.MultiTenant.EntityFrameworkCore.Stores.EFCoreStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tenancy
{
    //======== 1) TenantDbContext ===========
    //(Master / Main Tenant Management DbContext)
    //Ye DbContext sirf tenant ki basic info store karta hai:
    //Kaun kaun sa tenant exist karta hai(schools)
    //Unki configuration
    //Unki connection string
    //Unka database ka naam

    //Easy Explanation:
    //Ye aik master table jaisa hai jahan sari "Tenant List" rakhi hoti hai.
    //👉 Ye system-level hota hai
    //👉 Ye per-tenant data load nahi karta
    //👉 Iska kaam sirf tenant ko identify karna + connection string dena


    public class TenantDbContext(DbContextOptions<TenantDbContext> options)
      : EFCoreStoreDbContext<ABCSchoolTenantInfo>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ABCSchoolTenantInfo>()
                .ToTable("Tenants", "Multitenancy");
        }
    }


    //================== Basic of OOP undestand the Basic of  DbContext ==================
    /*
     ➤ 1. DbContextOptions<TenantDbContext> options kya hai?

        => Ye options ek configuration object hai jisme:

        Database ka connection string
        Provider (SQL Server, PostgreSQL, etc)
        Logging
        Lazy loading settings
        Migrations settings


        => OOP point of view:
            Ye dependency injection se automatically milta hai
            Ye class ko batata hai ke database se kaise connect karna hai

        📌 Short Jugaar Example:
            options = config jo batati hai DbContext ko kya settings use karni hain.
    */

    /*
     ➤ 2. Base Class Constructor Call

        : EFCoreStoreDbContext<ABCSchoolTenantInfo>(options)

        EFCoreStoreDbContext ek generic class hai jo Finbuckle.MultiTenant library ka part hai.
        Isaa TenantInfo kaa data chiyaa hota ha jo hum generic <T> parameter mein dete hain.

        TenantDbContext keh raha hai:
        “Jo options mujhe mile hain, wo base class (EFCoreStoreDbContext) ko forward kar do.”
        Base class ko pata chal jata hai:
        Kahan se DB connect karna hai
        Kon si table/entity tenant store karegi
        Kaun si tenant entity use honi hai (yahan: ABCSchoolTenantInfo)
     */

}
