using News_Portal.ModelsDto;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface IPolitics_NewsService
    {
      Task  <List<Politics_NewsDto>> GetPoliticsNews();
        Task Post(Politics_NewsDto politics_NewsDto);
        Task UpdateNews(Politics_NewsDto politics_NewsDto);
        Task Delete(int id);
    }
}
