using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface ITrending_NewsServices
    {
        Task<List<Trending_NewsDto>> Gettrending();
        Task<Trending_NewsDto> GetTrendingNews(int Id);
        Task Addtrending(Trending_NewsDto trending_NewsDto);
        Task UpdateTrendind(Trending_NewsDto trending);

        //  Task<Product?> FindProductByIdAsync(int id);
       // Task UploadImagesAsync(List<IFormFile> files, string uploadPath);
        Task DeleteProduct(int id);
    }
}
