using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularForDotnetCore.Components
{
    public class ApplicationUserComponent
    {
        private ApplicationUserContext _ctx;

        public ApplicationUserComponent(ApplicationUserContext cxt)
        {
            this._ctx = cxt;
        }

        public async Task<ApplicationUserModel> CreateAsync(ApplicationUserModel userModel)
        {
            await this._ctx.ApplicationUserModels.AddAsync(userModel);
            await this._ctx.SaveChangesAsync();

            return userModel;
        }

        public async Task<ApplicationUserModel> FindApplicationByUserNameAsync(ApplicationUserModel model)
        {
            var dbApplicationUser = await this._ctx.ApplicationUserModels.FirstOrDefaultAsync(p => p.UserName == model.UserName);
            if(dbApplicationUser != null)
            {
                // encrypto password and compare with db data.
                if(model.Password == dbApplicationUser.Password)
                {
                    return dbApplicationUser;
                }
            }
            return null;
        }

        public async Task<ApplicationUserModel> FindApplicatioByIdAsync(int id)
        {
            return await this._ctx.ApplicationUserModels.FindAsync(id);
        }
    }
}
