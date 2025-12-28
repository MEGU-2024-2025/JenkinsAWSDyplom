using AutoMapper;
using MEGUWebMVC.Data.Entities;
using MEGUWebMVC.Data.Entities.Identity;
using MEGUWebMVC.Models.Account;
using MEGUWebMVC.Models.Category;

namespace MEGUWebMVC.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserEntity, UserLinkViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => $"{x.LastName} {x.FirstName}"));

            CreateMap<UserEntity, ProfileViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.LastName} {x.FirstName}"));

            CreateMap<RegisterViewModel, UserEntity>()
                .ForMember(x => x.Image, opt => opt.Ignore())
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
