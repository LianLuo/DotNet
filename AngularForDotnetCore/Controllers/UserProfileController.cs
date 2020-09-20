using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularForDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private ApplicationUserComponent _appUC;
        private IMapper _mapper;

        public UserProfileController(ApplicationUserComponent appUC, IMapper mapper)
        {
            this._appUC = appUC;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        // GET: /api/UserProfile
        public async Task<ActionResult<UserProfileDto>> GetUserProfile()
        {
            string userId_str = User.Claims.FirstOrDefault(c => c.Type == "UserID").Value;
            if(string.IsNullOrEmpty(userId_str))
            {
                if(int.TryParse(userId_str, out int userId))
                {
                    var user = await this._appUC.FindApplicatioByIdAsync(userId);
                    return Ok(this._mapper.Map<UserProfileDto>(user));
                }
            }

            return NotFound();
        }
    }
}
