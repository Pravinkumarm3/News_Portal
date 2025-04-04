using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News_Portal.DbConnection;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Repository.ServiceClasses
{
    public class Bollywood_NewsService : IBollywood_NewsService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper mapper;
        public Bollywood_NewsService(AppDbContext _appDbContext, IMapper mapper)
        {
            this._appDbContext = _appDbContext;
            this.mapper = mapper;
            
        }
        public async Task Delete(int id)
        {
           var result=await _appDbContext.bollywoods.FirstOrDefaultAsync(x=>x.BollywoodId ==id);
            if(result !=null)
            {
                _appDbContext.bollywoods.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Bollywood_NewsDto>> GetBollywoodNews()
        {
           var result=await _appDbContext.bollywoods.ToListAsync();
            var rest =mapper.Map<List<Bollywood_NewsDto>>(result);
            return rest;
        }

        public async Task post(Bollywood_NewsDto _bollywoodnews)
        {
          var result=mapper.Map<Bollywood_News>(_bollywoodnews);
            await _appDbContext.bollywoods.AddAsync(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Bollywood_NewsDto _NewsDto)
        {
            var result = await _appDbContext.bollywoods.FirstOrDefaultAsync(x => x.BollywoodId == _NewsDto.BollywoodId);
            result.NewsTitle = _NewsDto.NewsTitle;
            result.NewsDescription = _NewsDto.NewsDescription;
            result.NewsType = _NewsDto.NewsType;
            result.FullNews = _NewsDto.FullNews;
            result.Status = _NewsDto.Status;
            result.ModifiedBy = _NewsDto.ModifiedBy;
            result.ModifiedOn = _NewsDto.ModifiedOn;
            result.CreatedBy = _NewsDto.CreatedBy;
            result.CreatedOn = _NewsDto.CreatedOn;
            var rest=mapper.Map<Bollywood_NewsDto>(result);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
