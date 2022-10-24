using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.Common
{
    public static class RepositoryDefaults
    {
        public const int DefaultEntityStatus = 1;
        public const string EntityStatusPropertyValueGroupName = nameof(EntityStatus);
        public const int AppSettingsPropertyValueId = 999999;

        public static class UserId
        {
            public static readonly Guid SystemAdministrator = new Guid("99999999-9999-9999-9999-999999999999");
            public static readonly Guid Administrator = new Guid("88888888-8888-8888-8888-888888888888");
            public static readonly Guid System = new Guid("11111111-1111-1111-1111-111111111111");
            public static readonly Guid Anonymous = new Guid("10000000-0000-0000-0000-000000000000");
        }

        public static class Role
        {
            public const string SystemAdministrator = nameof(SystemAdministrator);
            public const string Administrator = nameof(Administrator);
            public const string User = nameof(User);
        }

        public static class RoleId
        {
            public static readonly Guid SystemAdministrator = new Guid("99999999-9999-9999-9999-999999999999");
            public static readonly Guid Administrator = new Guid("88888888-8888-8888-8888-888888888888");
            public static readonly Guid User = new Guid("11111111-1111-1111-1111-111111111111");
        }

    }
}
