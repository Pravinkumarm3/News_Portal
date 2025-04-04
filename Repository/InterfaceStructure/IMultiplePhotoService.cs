using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDtos;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface IMultiplePhotoService
    {
        Task AddImage([FromForm] IFormFile[] filess, [FromForm] int id);
        Task<List<MultiplePhotoUploaddto>> GetImageList();
        Task UpdateImage([FromForm] IFormFile[] files, [FromForm] MultiplePhotoUploaddto model);
        Task DeleteImage(int id);
    }
}
