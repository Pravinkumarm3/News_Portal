using News_Portal.ModelsDto;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface IBollywood_NewsService
    {
        Task<List<Bollywood_NewsDto>> GetBollywoodNews();
        Task post(Bollywood_NewsDto _bollywoodnews);
        Task Update(Bollywood_NewsDto _NewsDto);
        Task Delete(int id );

    }
}
