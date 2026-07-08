using ClientFlow.API.Entities;
using ClientFlow.API.Contracts;
using ClientFlow.Shared.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClientFlow.API.Services;

public class AuthService : IAuthService
{
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;
    private readonly IConfiguration configuration;

    public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.configuration = configuration;
    }


    public async Task<ResponseDTO> Register(CredentialsDTO credentialsDTO)
    {
        var user = new User { Email = credentialsDTO.Email, UserName = credentialsDTO.NickName };
        var result = await userManager.CreateAsync(user, credentialsDTO.Password!);

        if (!result.Succeeded)
        {
            return null!;
        }

        return await BuildToken(credentialsDTO.Email!);
    }

    public async Task<ResponseDTO> Login(CredentialsDTO credentialsDTO)
    {
        var user = await userManager.FindByEmailAsync(credentialsDTO.Email!);

        if (user is null)
        {
            return null!;
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, credentialsDTO.Password!, false);

        if (!result.Succeeded)
        {
            return null!;
        }

        return await BuildToken(credentialsDTO.Email!);

    }



    private async Task<ResponseDTO> BuildToken(string email)
    {
        var claims = new List<Claim> { new Claim("email", email) };
        var user = await userManager.FindByEmailAsync(email);
        var claimsDB = await userManager.GetClaimsAsync(user!);

        claims.AddRange(claimsDB);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddHours(1);

        var securityToken = new JwtSecurityToken(
            issuer: null, audience: null, expires: expires, claims: claims, signingCredentials: credentials
            );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return new ResponseDTO
        {
            Token = token,
            Expires = expires
        };

    }
}
