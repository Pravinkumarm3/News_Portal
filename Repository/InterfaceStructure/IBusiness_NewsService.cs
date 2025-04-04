using News_Portal.ModelsDto;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface IBusiness_NewsService
    {
        Task <List<Business_NewsDto>> GetBusinessNews(string newsType);
        Task<List<Business_NewsDto>> GetBusinessNews();
        Task Post(Business_NewsDto business_news);
        Task UpdateNews(Business_NewsDto business_NewsDto);
        Task Delete(int id);

    }
}
