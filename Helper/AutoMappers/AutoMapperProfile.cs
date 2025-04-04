using AutoMapper;
using News_Portal.DbConnection;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;

namespace News_Portal.Helper.AutoMappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Trending_News, Trending_NewsDto>().ReverseMap();
            CreateMap<Latest_News,Latest_NewsDtos>().ReverseMap();
            CreateMap<Politics_News,Politics_NewsDto>().ReverseMap();
            CreateMap<Sports_News,Sports_NewsDto>().ReverseMap();
            CreateMap<Business_News,Business_NewsDto>().ReverseMap();
            CreateMap<Bollywood_News,Bollywood_NewsDto>().ReverseMap();
            CreateMap<FileModals, FileModalsDtos>().ReverseMap();

            //CreateMap<MultiplePhotoUpload,MultiplePhotoUploaddto>().ReverseMap();
            //CreateMap<UserDtos, ApplicationUsers>().ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}
