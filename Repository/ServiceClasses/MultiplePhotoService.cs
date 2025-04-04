using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_Portal.DbConnection;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;
namespace News_Portal.Repository.ServiceClasses
{
    public class MultiplePhotoService : IMultiplePhotoService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public MultiplePhotoService(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            
        }
        public async Task AddImage([FromForm] IFormFile[] filess, [FromForm] int trendingId)
        {
          
            if (filess.Length > 0 && filess != null)
                {
                    MultiplePhotoUploaddto images = new MultiplePhotoUploaddto();
                   // Trending_News registration=new Trending_News();
                    foreach (var item in filess)
                    {
                        images.TrendingId = trendingId;
                        var UnicFileName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                        var FilePath = Path.Combine( UnicFileName);
                        using (Stream stream = new FileStream(FilePath, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                        }
                        if (images.FileName == null)
                        {
                            images.FileName = FilePath;
                        }
                        else if (images.FileName1 == null)
                        {
                            images.FileName1 = FilePath;
                        }
                        else
                        {
                            images.FileName2 = FilePath;
                        }
                    }

                
                        var data = _mapper.Map<MultiplePhotoUpload>(images);
                        await _appDbContext.multiplePhotoUploads.AddRangeAsync(data);
                        await _appDbContext.SaveChangesAsync();
                    
                  
                }
           
        }

        public async Task DeleteImage(int id)
        {
            var result = await _appDbContext.multiplePhotoUploads.FirstOrDefaultAsync(x => x.id == id);
            if (result != null)
            {
                _appDbContext.multiplePhotoUploads.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<MultiplePhotoUploaddto>> GetImageList()
        {
            var result = await _appDbContext.multiplePhotoUploads.ToListAsync();
            var data = _mapper.Map<List<MultiplePhotoUploaddto>>(result);
            return data;
        }

        public async Task UpdateImage([FromForm] IFormFile[] files, [FromForm] MultiplePhotoUploaddto model)
        {
            var result = await _appDbContext.multiplePhotoUploads.FirstOrDefaultAsync(x => x.id == model.id);
            if (result != null)
            {
                MultiplePhotoUploaddto multiplePhotoDtoModel = new MultiplePhotoUploaddto();
                foreach (var file in files)
                {
                    var unicFileName = Guid.NewGuid().ToString() + file.FileName;
                    if (multiplePhotoDtoModel.FileName == null)
                    {

                    }
                }
            }
        }
    }
}
