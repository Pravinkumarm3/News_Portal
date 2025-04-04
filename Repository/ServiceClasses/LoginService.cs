using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using News_Portal.DbConnection;
using News_Portal.Models;
using News_Portal.ModelsDto;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Repository.ServiceClasses
{
    //public class LoginService : ILoginService
    //{
        //private readonly UserManager<ApplicationUsers> _userManager;
        //private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;

        //public LoginService(UserManager<ApplicationUsers> userManager, IConfiguration configuration, IMapper mapper)
        //{
        //    _userManager = userManager;
        //    _configuration = configuration;
        //    _mapper = mapper;
        //}



        //public async Task<ResponseDtos> Login(LoginDtos loginDto)
        //{
            //var user = await _userManager.FindByNameAsync(loginDto.UsernameOrEmail) ??
            //      await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail);

            //if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            //{
            //    return new ResponseDtos { Message = "Invalid username or password." };
            //}

            //var token = GenerateJwtToken(user);
            //return new ResponseDtos { Token = token, Message = "Login successful." };
        }


        //public async Task<ResponseDtos> Register(UserDtos userDto)
        ///**/
            //var existingUser = await _userManager.FindByNameAsync(userDto.Username) ??
            //              await _userManager.FindByEmailAsync(userDto.Email);

            //if (existingUser != null)
            //{
            //    return new ResponseDtos { Message = "Username or Email already exists." };
            //}

            //var user = new ApplicationUsers
            //{
            //    UserName = userDto.Username,
            //    Email = userDto.Email,
            //    Role = "User " // Default role
            //};

            //var result = await _userManager.CreateAsync(user, userDto.Password);
            //if (!result.Succeeded)
            //{
            //    return new ResponseDtos { Message = string.Join(", ", result.Errors.Select(e => e.Description)) };
            //}

            //return new ResponseDtos { Message = "User  registered successfully." };
        



        //private string GenerateJwtToken(ApplicationUsers user)
        //{
        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(ClaimTypes.Role, user.Role) // Add role claim
        //};

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["Jwt:Issuer"],
        //        audience: _configuration["Jwt:Audience"],
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        //public Task<string> ResetPassword(ResetPasswordDto resetPasswordDto)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<string> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        //{
        //    var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
        //    if (user == null) return "User  not found.";

        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var resetLink = $"{_configuration["AppUrl"]}/reset-password?token={token}&email={forgotPasswordDto.Email}";

            // Send email
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress("Your App", "your_email@example.com"));
            //message.To.Add(new MailboxAddress(user.UserName, user.Email));
            //message.Subject = "Reset Password";
            //message.Body = new TextPart("plain")
            //{
            //    Text = $"Please reset your password by clicking here: {resetLink}"
            //};

            //using (var client = new SmtpClient())
            //{
                //client.Connect("smtp.example.com", 587, false);
                //client.Authenticate("your_email@example.com", "your_email_password");
                //client.Send(message);
                //client.Disconnect(true);
            //}

            //return "Reset password link has been sent to your email.";
        //}

 
