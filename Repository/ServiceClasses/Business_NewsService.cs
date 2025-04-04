using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News_Portal.DbConnection;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Repository.ServiceClasses
{
    public class Business_NewsService : IBusiness_NewsService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public Business_NewsService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            var rest= await _appDbContext.Business.FirstOrDefaultAsync(x=>x.BusinessId==id);
            if (rest!=null)
            {
                _appDbContext.Business.Remove(rest);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Business_NewsDto>> GetBusinessNews(string newsType)
        {
            //var result = await _appDbContext.Business.ToListAsync();
            //var data = _mapper.Map<List<Business_NewsDto>>(result);
            //return data;
            var  result =await _appDbContext.Business.Where(x => x.NewsType == newsType).ToListAsync();
            var data = _mapper.Map<List<Business_NewsDto>>(result);
            return data;

        }

        public async Task<List<Business_NewsDto>> GetBusinessNews()
        {
            var result = await _appDbContext.Business.ToListAsync();
            var data = _mapper.Map<List<Business_NewsDto>>(result);
            return data;


        }

        public async Task Post(Business_NewsDto business_news)
        {
           var result= _mapper.Map<Business_News>(business_news);
            await _appDbContext.Business.AddAsync(result);
            await _appDbContext.SaveChangesAsync();

        }

        //public async Task Update(Business_NewsDto businessnews)
        //{
        //    var result = await _appDbContext.Business.FirstOrDefaultAsync(x => businessnews.BusinessId == businessnews.BusinessId);
        //    result.NewsTitle= businessnews.NewsTitle;
        //    result.NewsDescription= businessnews.NewsDescription;
        //    result.FullNews= businessnews.FullNews;
        //    result.NewsType= businessnews.NewsType;
        //    result.Status= businessnews.Status;
        //    result.ModifiedBy = businessnews.ModifiedBy;
        //    result.ModifiedOn = businessnews.ModifiedOn;
        //    result.CreatedBy = businessnews.CreatedBy;
        //    result.CreatedOn = businessnews.CreatedOn;
        //    var data = _mapper.Map<Business_NewsDto>(result);
        //    await _appDbContext.SaveChangesAsync();

        //}
        public async Task UpdateNews(Business_NewsDto business_NewsDto )
        {
            var result = await _appDbContext.Business.FirstOrDefaultAsync(x => x.BusinessId == business_NewsDto.BusinessId);

            result.NewsTitle = business_NewsDto.NewsTitle;
            result.NewsDescription = business_NewsDto.NewsDescription;
            result.NewsType = business_NewsDto.NewsType;
            result.FullNews = business_NewsDto.FullNews;
            result.Status = business_NewsDto.Status;
            result.FullNews = business_NewsDto.FullNews;
            result.ModifiedBy = business_NewsDto.ModifiedBy;
            result.ModifiedOn = business_NewsDto.ModifiedOn;
            result.CreatedBy = business_NewsDto.CreatedBy;
            result.CreatedOn = business_NewsDto.CreatedOn;
            var data = _mapper.Map<Business_NewsDto>(result);
            await _appDbContext.SaveChangesAsync();

        }
    }
}
