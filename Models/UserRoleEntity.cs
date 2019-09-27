using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UserRoleEntity : IdentityRole<Guid>
    {
        public UserRoleEntity(Task<UserRoleEntity> role)
            : base()
        { }

        public UserRoleEntity(string role)
            : base(role)
        { }
        public UserRoleEntity() { }


    }
}
