namespace Infrastructure
{
    public class Class1
    {
        //=============== Pacakge Installing ============

        //==== 1. Finbuckle =========
        // this is used for multi-tenancy support in ASP.NET Core applications.
        // with multi-tenancy database per tenant strategy. means every tenant has its own database.    
        //1. Finbuckle.MultiTenant
        //1. Finbuckle.MultiTenant.AspNetCore
        //2. Finbuckle.MultiTenant.EntityFrameworkCore


        //==== 2. Identity =========
        // identity framword used for authentication and authorization in ASP.NET Core applications.
        // its very comparitive with finbuckle because it also support multi-tenancy.
        //1. Microsoft.AspNetCore.Identity.EntityFrameworkCore

        //==== 3. SQLserver =========
        // this is used for SQL server database provider for Entity Framework Core.
        // 1. Microsoft.EntityFrameworkCore.SqlServer

        //==== 4. tools =========
        // this is used for Entity Framework Core command-line tools.
        // 1. Microsoft.EntityFrameworkCore.Tools

    }
}
