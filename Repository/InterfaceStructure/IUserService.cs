using News_Portal.ModelsDto;

namespace News_Portal.Repository.InterfaceStructure
{
    public interface IUserService
    {
        Task<string> RegisterUser(RegisterDto registerDto);
        Task<string> LoginUser(LoginsDto loginDto);
    }
}
