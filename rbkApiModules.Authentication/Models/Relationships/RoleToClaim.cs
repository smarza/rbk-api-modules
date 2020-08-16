﻿using System;

namespace rbkApiModules.Authentication
{
    /// <summary>
    /// Classe necessária para modelar o relacionamento n-n do EntityFrameworkCore
    /// </summary>
    public class RoleToClaim
    {
        protected RoleToClaim()
        {

        }

        public RoleToClaim(Role role, Claim claim)
        {
            Role = role;
            Claim = claim;
        }

        public virtual Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual Guid ClaimId { get; set; }
        public virtual Claim Claim { get; set; } 
    }
}
