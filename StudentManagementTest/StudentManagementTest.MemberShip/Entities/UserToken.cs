using System;

using Microsoft.AspNetCore.Identity;

namespace StudentManagementTest.MemberShip.Entities
{
    public class UserToken
        : IdentityUserToken<Guid>
    {
        public UserToken()
            : base()
        {

        }
    }
}
