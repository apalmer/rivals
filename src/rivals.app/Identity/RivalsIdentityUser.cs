using AspNetCore.Identity.DocumentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.app.Identity
{
    public class RivalsIdentityUser : DocumentDbIdentityUser<RivalsIdentityRole>
    {
    }
}
