using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News_Portal.DbConnection;
using News_Portal.Exceptions;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;
using static System.Net.Mime.MediaTypeNames;
using KeyNotFoundException = News_Portal.Exceptions.KeyNotFoundException;

namespace News_Portal.Repository.ServiceClasses
{
    public class Trending_NewsServices : ITrending_NewsServices
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public Trending_NewsServices(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Addtrending(Trending_NewsDto trending_NewsDto)
        {


            var resul =  _mapper.Map<Trending_News>(trending_NewsDto);
            await _appDbContext.trending_News.AddAsync(resul);
            await _appDbContext.SaveChangesAsync();
            
            
        }

        public async Task UpdateTrendind(Trending_NewsDto trending_NewsDto)
        {
            if (trending_NewsDto == null)
            {
                throw new NotFoundException("Dto Data Not Match");
            }
            var map = _mapper.Map<Trending_News>(trending_NewsDto);
            _appDbContext.trending_News.Update(map);
            await _appDbContext.SaveChangesAsync();
        }
       
        public async Task<List<Trending_NewsDto>> Gettrending()
        {
            var employees = await _appDbContext.trending_News.Include(e => e.Images).ToListAsync();
            return _mapper.Map<List<Trending_NewsDto>>(employees);

        }

        public  async Task DeleteProduct(int id)
        {
           var data=await _appDbContext.trending_News.FirstOrDefaultAsync(x=>x.NewsId ==id);
            if(data != null)
            {
                _appDbContext.trending_News.Remove(data);
                await _appDbContext.SaveChangesAsync();
            }
          
        }

        public async Task<Trending_NewsDto> GetTrendingNews(int Id)
        {
            var result = await _appDbContext.trending_News.Include(e => e. Images).FirstOrDefaultAsync(e => e.NewsId == Id );
            if (result == null)
            {
                throw new KeyNotFoundException("Please Enter Valid latest id");
            }
            return _mapper.Map<Trending_NewsDto>(result);
        }
    }
}
