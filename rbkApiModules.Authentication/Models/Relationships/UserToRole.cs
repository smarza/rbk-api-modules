﻿using System;

namespace rbkApiModules.Authentication
{
    /// <summary>
    /// Classe necessária para modelar o relacionamento n-n do EntityFrameworkCore
    /// </summary>
    public class UserToRole
    {
        protected UserToRole()
        {

        }

        public UserToRole(User user, Role role)
        {
            User = user;
            Role = role; 
        }

        public virtual Guid UserId { get; private set; }
        public virtual User User { get; private set; }

        public virtual Guid RoleId { get; private set; }
        public virtual Role Role { get; private set; } 
    }
}
