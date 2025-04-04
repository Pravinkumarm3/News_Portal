using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News_Portal.DbConnection;
using News_Portal.Exceptions;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;
using KeyNotFoundException = News_Portal.Exceptions.KeyNotFoundException;

namespace News_Portal.Repository.ServiceClasses
{
    public class Latest_NewsServices : ILatest_NewsServices
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public Latest_NewsServices(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task Add(Latest_NewsDtos latestnewsdto)
        {
            var result = _mapper.Map<Latest_News>(latestnewsdto);
            await _dbContext.latest_news.AddAsync(result);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteNews(int id)
        {
            var data=await _dbContext.latest_news.FirstOrDefaultAsync(x=>x.LatestId == id);
            if(data !=null)
            {
                _dbContext.latest_news.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
   
        }

        public async Task<List<Latest_NewsDtos>> GetAllNews()
        {

            var result = await _dbContext.latest_news.ToListAsync();
            var data = _mapper.Map<List<Latest_NewsDtos>>(result);
            return data;
        }

        public async Task<Latest_NewsDtos> GetLatestNews(int Id)
        {
            var result = await _dbContext.latest_news.FirstOrDefaultAsync(x => x.LatestId == Id);
            if (result == null)
            {
                throw new KeyNotFoundException("Please Enter Valid latest id");
            }
            return  _mapper.Map<Latest_NewsDtos>(result);

        }

        public async Task UpdateNews(Latest_NewsDtos latestnews)
        {
            var result = await _dbContext.latest_news.FirstOrDefaultAsync(x => x.LatestId == latestnews.LatestId);
          
            result.NewsTitle = latestnews.NewsTitle;
            result.NewsDiscription = latestnews.NewsDiscription;
            result.Thumbnail = latestnews.Thumbnail;
            result.NewsStatus = latestnews.NewsStatus;
            result.NewsDateTime = latestnews.NewsDateTime;
            result.ModifiedBy = latestnews.ModifiedBy;
            result.ModifiedOn = latestnews.ModifiedOn;
            result.CreatedBy = latestnews.CreatedBy;
            result.CreatedOn = latestnews.CreatedOn;
            var data = _mapper.Map<Latest_NewsDtos>(result);
            await _dbContext.SaveChangesAsync();

        }
    }
   
}
