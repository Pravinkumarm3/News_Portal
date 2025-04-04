using News_Portal.ModelsDtos;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface ILatest_NewsServices
    {
        Task<List<Latest_NewsDtos>> GetAllNews();
        Task<Latest_NewsDtos> GetLatestNews(int Id);
        Task Add(Latest_NewsDtos latestnewsdto);
        Task UpdateNews(Latest_NewsDtos latestnews);
        Task DeleteNews(int id);
    }
}
