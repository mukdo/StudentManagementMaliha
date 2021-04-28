using System;

using Microsoft.AspNetCore.Identity;

namespace StudentManagementTest.MemberShip.Entities
{
    public class UserClaim
        : IdentityUserClaim<Guid>
    {
        public UserClaim()
            : base()
        {

        }
    }
}
