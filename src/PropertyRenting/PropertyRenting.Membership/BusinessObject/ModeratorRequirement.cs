﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.BusinessObject
{
    public class ModeratorRequirement : IAuthorizationRequirement
    {
        public ModeratorRequirement() { }
    }
}