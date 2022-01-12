﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Models
{
    public class User : IdentityUser<string>
    {
        public virtual List<Project> OwnedProjects { get; set; }
    }
}
