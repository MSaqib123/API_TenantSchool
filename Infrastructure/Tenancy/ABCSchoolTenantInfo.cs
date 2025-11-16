using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tenancy
{
    public class ABCSchoolTenantInfo : ITenantInfo
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        //====== database of own tenant =====
        public string ConnectionString { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //validity of tenant and active status
        public DateTime ValidUpTo { get; set; }
        public bool IsActive { get; set; }
    }
}
