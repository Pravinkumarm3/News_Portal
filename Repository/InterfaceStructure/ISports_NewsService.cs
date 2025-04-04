using News_Portal.ModelsDto;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface ISports_NewsService
    {
        Task<List<Sports_NewsDto>> GetAllNews();
        Task PostData(Sports_NewsDto news);
        Task UpdateNews(Sports_NewsDto sports_NewsDto);
        Task DeleteData(int id);
    }
}
