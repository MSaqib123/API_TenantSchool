using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constants
{



    // School Permissions Constants
    // this is for a multi-tenant school management system
    // defining actions, features, and permissions for various roles
    public static class SchoolAction
    {
        public const string Read = nameof(Read);
        public const string Create = nameof(Create);
        public const string Update = nameof(Update);
        public const string Delete = nameof(Delete);
        public const string RefreshToken = nameof(RefreshToken);
        public const string UpgradeSubscription = nameof(UpgradeSubscription);
    }

    // Features in the school management system
    // each feature can have multiple actions associated with it
    public static class SchoolFeature
    {
        public const string Tenants = nameof(Tenants);
        public const string Users = nameof(Users);
        public const string Roles = nameof(Roles);
        public const string UserRoles = nameof(UserRoles);
        public const string RoleClaims = nameof(RoleClaims);
        public const string Schools = nameof(Schools);
        public const string Tokens = nameof(Tokens);
    }

    // Definition of a permission in the school management system
    // record is C# 9.0 feature for immutable data objects
    // imutable means once created, the properties cannot be changed , and they have value-based equality
    // this is useful for defining permissions that should not change at runtime
    // this method generates a unique name for each permission based on its action and feature
    public record SchoolPermission(string Action, string Feature, string Description, string Group, bool IsBasic = false, bool IsRoot = false)
    {
        public string Name => NameFor(Action, Feature);

        public static string NameFor(string action, string feature) => $"Permission.{feature}.{action}";
    }
    // Collection of all permissions in the school management system
    // different views of the permissions are provided based on roles: All, Root, Admin, Basic
    public static class SchoolPermissions
    {
        private static readonly SchoolPermission[] _allPermissions =
        [
            new SchoolPermission(SchoolAction.Create, SchoolFeature.Tenants, "Create Tenants", "Tenancy", IsRoot: true),
            new SchoolPermission(SchoolAction.Read, SchoolFeature.Tenants, "Read Tenants", "Tenancy", IsRoot: true),
            new SchoolPermission(SchoolAction.Update, SchoolFeature.Tenants, "Update Tenants", "Tenancy", IsRoot: true),
            new SchoolPermission(SchoolAction.UpgradeSubscription, SchoolFeature.Tenants, "Upgrade Tenant's Subscription", "Tenancy", IsRoot: true),

            new SchoolPermission(SchoolAction.Create, SchoolFeature.Users, "Create Users", "SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeature.Users, "Update Users", "SystemAccess"),
            new SchoolPermission(SchoolAction.Delete, SchoolFeature.Users, "Delete Users", "SystemAccess"),
            new SchoolPermission(SchoolAction.Read, SchoolFeature.Users, "Read Users", "SystemAccess"),

            new SchoolPermission(SchoolAction.Read, SchoolFeature.UserRoles, "Read User Roles", "SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeature.UserRoles, "Update User Roles", "SystemAccess"),

            new SchoolPermission(SchoolAction.Read, SchoolFeature.Roles, "Read Roles", "SystemAccess"),
            new SchoolPermission(SchoolAction.Create, SchoolFeature.Roles, "Create Roles", "SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeature.Roles, "Update Roles", "SystemAccess"),
            new SchoolPermission(SchoolAction.Delete, SchoolFeature.Roles, "Delete Roles", "SystemAccess"),

            new SchoolPermission(SchoolAction.Read, SchoolFeature.RoleClaims, "Read Role Claims/Permissions", "SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeature.RoleClaims, "Update Role Claims/Permissions", "SystemAccess"),

            new SchoolPermission(SchoolAction.Read, SchoolFeature.Schools, "Read Schools", "Academics", IsBasic: true),
            new SchoolPermission(SchoolAction.Create, SchoolFeature.Schools, "Create Schools", "Academics"),
            new SchoolPermission(SchoolAction.Update, SchoolFeature.Schools, "Update Schools", "Academics"),
            new SchoolPermission(SchoolAction.Delete, SchoolFeature.Schools, "Delete Schools", "Academics"),

            new SchoolPermission(SchoolAction.RefreshToken, SchoolFeature.Tokens, "Generate Refresh Token", "SystemAccess", IsBasic: true)
        ];


        // Different views of the permissions based on roles
        public static IReadOnlyList<SchoolPermission> All { get; }
            = new ReadOnlyCollection<SchoolPermission>(_allPermissions);
        // Root permissions are those that are marked as IsRoot
        public static IReadOnlyList<SchoolPermission> Root { get; }
            = new ReadOnlyCollection<SchoolPermission>(_allPermissions.Where(p => p.IsRoot).ToArray());
        // Admin permissions are all except those marked as IsRoot
        public static IReadOnlyList<SchoolPermission> Admin { get; }
            = new ReadOnlyCollection<SchoolPermission>(_allPermissions.Where(p => !p.IsRoot).ToArray());
        // Basic permissions are those that are marked as IsBasic
        public static IReadOnlyList<SchoolPermission> Basic { get; }
            = new ReadOnlyCollection<SchoolPermission>(_allPermissions.Where(p => p.IsBasic).ToArray());
    }
}
