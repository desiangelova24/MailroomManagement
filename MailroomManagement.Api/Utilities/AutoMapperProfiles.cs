using AutoMapper;
using MailroomManagement.Api.Models.DTOs;
using MailroomManagement.Api.Models.Requests.Auth;
using MailroomManagement.Api.Models.Requests.Departments;
using MailroomManagement.Api.Models.Requests.Letters;
using MailroomManagement.Api.Models.Requests.Organizations;
using MailroomManagement.Api.Models.Requests.Setup;
using MailroomManagement.Api.Models.Requests.User;
using MailroomManagement.Core.Entities;

namespace MailroomManagement.Api.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // User mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<RegisterRequest, User>();

            // Letter mappings
            CreateMap<Letter, LetterDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.User.Organization.Name));

            CreateMap<CreateLetterRequest, Letter>();

            // Organization mappings
            CreateMap<Organization, OrganizationDto>();
            CreateMap<Organization, OrganizationWithDepartmentsDto>();
            CreateMap<CreateOrganizationRequest, Organization>();

            // Department mappings
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name));

            CreateMap<DepartmentRequest, Department>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            // UserRequest mappings
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Ignore since it's set 
        }
    }
}
