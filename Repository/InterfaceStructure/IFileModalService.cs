using Microsoft.AspNetCore.Mvc;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface IFileModalService
    {
        Task AddImage( IFormFile files);
      //  Task AddImage( IFormFile files);
        Task<List<FileModalsDtos>> GetImageList();
        Task DeleteImage(int id);

    }
  
}

