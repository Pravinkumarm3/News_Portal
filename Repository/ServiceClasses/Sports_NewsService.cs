using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News_Portal.DbConnection;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Repository.ServiceClasses
{
    public class Sports_NewsService : ISports_NewsService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public Sports_NewsService(AppDbContext _appDbContext, IMapper _mapper)
        {
          this._appDbContext = _appDbContext;
            this._mapper = _mapper;
        }
        public async Task DeleteData(int id)
        {
            var result = await _appDbContext.Sports.FirstOrDefaultAsync(x=>x.SportsId==id);
            if (result != null)
            {
                _appDbContext.Sports.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<List<Sports_NewsDto>> GetAllNews()
        {
             var result=await _appDbContext.Sports.ToListAsync();
            var rest=_mapper.Map<List<Sports_NewsDto>>(result);
            return rest;
        }

        public async Task PostData(Sports_NewsDto sports_News)
        {
            var result=_mapper.Map<Sports_News>(sports_News);
            await _appDbContext.Sports.AddAsync(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateNews(Sports_NewsDto sports_NewsDto)
        {
            var result = await _appDbContext.Sports.FirstOrDefaultAsync(x => x.SportsId == sports_NewsDto.SportsId);

            result.NewsTitle = sports_NewsDto.NewsTitle;
            result.NewsDescription = sports_NewsDto.NewsDescription;
            result.FullNews = sports_NewsDto.FullNews;
            result.Status = sports_NewsDto.Status;
            result.NewsType = sports_NewsDto.NewsType;
            result.ModifiedBy = sports_NewsDto.ModifiedBy;
            result.ModifiedOn = sports_NewsDto.ModifiedOn;
            result.CreatedBy = sports_NewsDto.CreatedBy;
            result.CreatedOn = sports_NewsDto.CreatedOn;
            var data = _mapper.Map<Sports_NewsDto>(result);
            await _appDbContext.SaveChangesAsync();

        }
    }
  
}
