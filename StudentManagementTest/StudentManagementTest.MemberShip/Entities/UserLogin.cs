using System;

using Microsoft.AspNetCore.Identity;

namespace StudentManagementTest.MemberShip.Entities
{
    public class UserLogin
        : IdentityUserLogin<Guid>
    {
        public UserLogin()
            : base()
        {

        }
    }
}
