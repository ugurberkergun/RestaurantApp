using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.Core.Entities.Dtos;
using RestaurantApp.Core.Entities.Models;
using RestaurantApp.Core.Utilities.Security.Encription;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.Utilities.Security.Jwt
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly CustomTokenOptions _tokenOptions;

        public TokenService(IOptions<CustomTokenOptions> options, UserManager<User> userManager)
        {
            _tokenOptions = options.Value;
            _userManager = userManager;
        }
        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
        private async Task<IEnumerable<Claim>> GetClaims(User user, List<string> audiences)
        {
            var userRoles =await _userManager.GetRolesAsync(user);
            var userList = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            userList.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));
            return userList;
        }

        public TokenDto CreateToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);

            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptions.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaims(user, _tokenOptions.Audience).Result,
                signingCredentials: signingCredentials
                );
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokebExpiration = refreshTokenExpiration
            };
            return tokenDto;
        }
    }
}
