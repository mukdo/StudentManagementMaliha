using System;

using Microsoft.AspNetCore.Identity;

namespace StudentManagementTest.MemberShip.Entities
{
    public class RoleClaim
        : IdentityRoleClaim<Guid>
    {
        public RoleClaim()
            : base()
        {

        }
    }
}
