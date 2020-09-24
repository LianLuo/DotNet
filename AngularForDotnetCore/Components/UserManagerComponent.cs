using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using Microsoft.EntityFrameworkCore;

namespace AngularForDotnetCore.Components
{
    public class UserManagerComponent
    {
        private ApplicationUserContext _cxt;
        public UserManagerComponent(ApplicationUserContext ctx)
        {
            this._cxt = ctx;
        }

        public async Task<IEnumerable<string>> GetRolesAsync(ApplicationUserModel userModel)
        {
            var result = await this._cxt.ApplicationUserModels.ToListAsync();
            return result.FindAll(p=>p.ID == userModel.ID).Select(p=>p.FullName);
        }
    }
}