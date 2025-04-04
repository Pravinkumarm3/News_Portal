using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News_Portal.DbConnection;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Repository.ServiceClasses
{
    
    public class Politics_NewsService : IPolitics_NewsService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public Politics_NewsService(AppDbContext _appDbContext, IMapper _mapper)
        {
            this._appDbContext = _appDbContext;
            this._mapper = _mapper;
        }
        public async Task Delete(int id)
        {
            var rest=await _appDbContext.Politics.FirstOrDefaultAsync(x=>x.PoliticsId ==id);
            if (rest != null)
            {
                 _appDbContext.Politics.Remove(rest);
               await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task <List<Politics_NewsDto>> GetPoliticsNews()
        {
            var rest= await _appDbContext.Politics.ToListAsync();
            var data= _mapper.Map<List<Politics_NewsDto>>(rest);
            return data;
        }

        public async Task Post(Politics_NewsDto politics_NewsDto)
        {
            
            var result= _mapper.Map<Politics_News>(politics_NewsDto);
            await _appDbContext.Politics.AddAsync(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateNews(Politics_NewsDto politics_NewsDto)
        {
           var result= await _appDbContext.Politics.FirstOrDefaultAsync(x=>x.PoliticsId ==politics_NewsDto.PoliticsId);
            result.NewsTitle=politics_NewsDto.NewsTitle;
            result.FullNews=politics_NewsDto.FullNews;
            result.Status=politics_NewsDto.Status;
            result.FullNews=politics_NewsDto.FullNews;
            result.NewsType=politics_NewsDto.NewsType;
            result.ModifiedBy = politics_NewsDto.ModifiedBy;
            result.ModifiedOn = politics_NewsDto.ModifiedOn;
            result.CreatedBy = politics_NewsDto.CreatedBy;
            result.CreatedOn = politics_NewsDto.CreatedOn;
            var rest=_mapper.Map<Politics_NewsDto>(result);
            await _appDbContext.SaveChangesAsync();

        }

       
    }
}
