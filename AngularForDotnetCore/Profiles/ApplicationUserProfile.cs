using AngularForDotnetCore.Dtos;
using AngularForDotnetCore.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularForDotnetCore.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUserModel, RegisterDto>();
            CreateMap<RegisterDto, ApplicationUserModel>();

            CreateMap<LoginDto, ApplicationUserModel>();
            CreateMap<ApplicationUserModel, LoginDto>();

            CreateMap<ApplicationUserModel, UserProfileDto>();
        }
    }
}
