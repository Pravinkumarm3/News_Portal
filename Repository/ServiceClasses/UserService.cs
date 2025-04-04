using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using News_Portal.DbConnection;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace News_Portal.Repository.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUsers> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<string> LoginUser(LoginsDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.EmailOrUsername) ??
                  await _userManager.FindByNameAsync(loginDto.EmailOrUsername);

            if (user == null)
                return "Invalid username or email";

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return "Invalid password";

            var token = GenerateJwtToken(user);
            return token;
        }

        public async Task<string> RegisterUser(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
                return "Email already exists";

            if (registerDto.Password != registerDto.ConfirmPassword)
                return "Passwords do not match";

            var user = new ApplicationUsers
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return "Registration failed";

            if (!await _roleManager.RoleExistsAsync(registerDto.Role))
                await _roleManager.CreateAsync(new IdentityRole(registerDto.Role));

            await _userManager.AddToRoleAsync(user, registerDto.Role);
            return "Registration successful";
        }
        private string GenerateJwtToken(ApplicationUsers user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

            var userRoles = _userManager.GetRolesAsync(user).Result;
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
