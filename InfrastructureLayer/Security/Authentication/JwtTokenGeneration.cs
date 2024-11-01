using ApplicationLayer.Interfaces.InfrastructureLayer;
using ApplicationLayer.Models;
using DomainLayer.Configurations;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Security.Authentication
{
    public class JwtTokenGeneration : IJwtTokenGeneration
    {
        private readonly IAppSettingsConfig _appSettingsConfig;

        public JwtTokenGeneration(IAppSettingsConfig appSettingsConfig)
        {
            _appSettingsConfig = appSettingsConfig ?? throw new ArgumentNullException(nameof(appSettingsConfig));
        }

        public TokenModel GenerateJwtToken( IDictionary<string, string>? additionalClaims = null)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Add additional claims if provided
            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims.Select(claim => new Claim(claim.Key, claim.Value)));
            }

            if (string.IsNullOrEmpty(_appSettingsConfig.CustomAuthenticate.Password) || _appSettingsConfig.CustomAuthenticate.Password.Length < 32)
            {
                throw new InvalidOperationException("Invalid JWT signing key.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettingsConfig.CustomAuthenticate.Password));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTimeOffset expiresIn = DateTimeOffset.UtcNow.AddHours(_appSettingsConfig.CustomAuthenticate.JwtBearer.JwtTimeOutInHours);

            var token = new JwtSecurityToken(
                issuer: _appSettingsConfig.CustomAuthenticate.JwtBearer.ValidIssuer,
                audience: _appSettingsConfig.CustomAuthenticate.JwtBearer.ValidAudience,
                claims: claims,
                expires: expiresIn.UtcDateTime,
                signingCredentials: creds);

            return new TokenModel(new JwtSecurityTokenHandler().WriteToken(token), expiresIn.UtcDateTime);
        }
        public TokenModel GenerateJwtToken(Guid UserId, IDictionary<string, string>? additionalClaims = null)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Add additional claims if provided
            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims.Select(claim => new Claim(claim.Key, claim.Value)));
            }

            if (string.IsNullOrEmpty(_appSettingsConfig.CustomAuthenticate.Password) || _appSettingsConfig.CustomAuthenticate.Password.Length < 32)
            {
                throw new InvalidOperationException("Invalid JWT signing key.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettingsConfig.CustomAuthenticate.Password));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTimeOffset expiresIn = DateTimeOffset.UtcNow.AddHours(_appSettingsConfig.CustomAuthenticate.JwtBearer.JwtTimeOutInHours);

            var token = new JwtSecurityToken(
                issuer: _appSettingsConfig.CustomAuthenticate.JwtBearer.ValidIssuer,
                audience: _appSettingsConfig.CustomAuthenticate.JwtBearer.ValidAudience,
                claims: claims,
                expires: expiresIn.UtcDateTime,
                signingCredentials: creds);

            return new TokenModel(new JwtSecurityTokenHandler().WriteToken(token), expiresIn.UtcDateTime);
        }
    }
}
