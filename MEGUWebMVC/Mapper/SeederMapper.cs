using AutoMapper;
using MEGUWebMVC.Data.Entities;
using MEGUWebMVC.Models.Seeder;

namespace MEGUWebMVC.Mapper
{
    public class SeederMapper : Profile
    {
        public SeederMapper()
        {
            CreateMap<SeederCategoryModel, CategoryEntity>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.Image));
        }
    }
}
