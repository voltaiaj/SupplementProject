using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Services.Identity
{
    public class RoleStore : IRoleStore<IdentityRole, Guid>, IQueryableRoleStore<IdentityRole, Guid>, IDisposable
    {

    }
}
