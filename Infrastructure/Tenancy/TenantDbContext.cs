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

}
