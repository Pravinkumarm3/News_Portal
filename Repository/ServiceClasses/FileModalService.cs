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
    public class FileModalService : IFileModalService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public FileModalService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }
        public async Task AddImage(IFormFile file)
        {


            if (file == null || file.Length == 0)
            {
                FileModalsDtos images = new FileModalsDtos();
            }

           
            
                // Generate a unique filename
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine("files", uniqueFileName);

                // Ensure the directory exists
                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                { 
                    Directory.CreateDirectory(directoryPath);
                }

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Create a DTO to hold the filename
                var imageDto = new FileModalsDtos
                {
                    FileName = filePath
                };

                // Map to your entity if needed and save to the database
                var data = _mapper.Map<FileModals>(imageDto);
                await _appDbContext.fileModals.AddAsync(data);
                await _appDbContext.SaveChangesAsync();

              
        











            //if (files == null || files.Length == 0)
            //{
            //     FileModalsDtos images = new FileModalsDtos();
            //}

            // Generate a unique filename
            //var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
            //var filePath = Path.Combine("/files", uniqueFileName);

            // Ensure the directory exists
            //Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Save the file
            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    await files.CopyToAsync(stream);
            //}

            // Store only the filename in DTO
            //var imageDto = new FileModalsDtos
            //{
            //    FileName = uniqueFileName  // Storing only filename instead of full path
            //};

            // Map to entity and save to database
            //var data = _mapper.Map<FileModals>(imageDto);
            //await _appDbContext.fileModals.AddAsync(data);
            //await _appDbContext.SaveChangesAsync();


        }

        public async Task DeleteImage(int id)
        {
            var result = await _appDbContext.fileModals.FirstOrDefaultAsync(x => x.id == id);
            if (result != null)
            {
                _appDbContext.fileModals.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<FileModalsDtos>> GetImageList()
        {
            var result = await _appDbContext.fileModals.ToListAsync();
            var data = _mapper.Map<List<FileModalsDtos>>(result);
            return data;
        }

       

    }
}
