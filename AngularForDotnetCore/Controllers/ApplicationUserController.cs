using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Dtos;
using AngularForDotnetCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AngularForDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private ApplicationUserComponent _appUC;
        private IMapper _mapper;
        private AppSettings _appSettings;

        public ApplicationUserController(ApplicationUserComponent appUC, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this._appUC = appUC;
            this._mapper = mapper;
            this._appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ApplicationUserModel>> PostApplicationUser(RegisterDto register)
        {
            var applicationModel = this._mapper.Map<ApplicationUserModel>(register);
            var app = await this._appUC.CreateAsync(applicationModel);
            return Ok(app);
        }

        [HttpPost]
        [Route("login")]
        // POST: /api/applicationuser/login
        public async Task<ActionResult<ApplicationUserModel>> LoginApplication(LoginDto loginModel)
        {
            var applicationUser = this._mapper.Map<ApplicationUserModel>(loginModel);
            var dbApplication = await this._appUC.FindApplicationByUserNameAsync(applicationUser);
            if(dbApplication == null)
            {
                return BadRequest();
            }
            var tokenDescriptor = new SecurityTokenDescriptor { 
                Subject = new ClaimsIdentity(new Claim[] { 
                    new Claim ("UserID", dbApplication.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._appSettings.JWT_Security)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return Ok(new { token});
        }
    }
}
