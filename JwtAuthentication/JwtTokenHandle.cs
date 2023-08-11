

using JwtAuthentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthentication
{
    public class JwtTokenHandle
    {
        public const string JWT_TOKEN_KEY = "P3282635827!@@%#&^#&*^Phtrubfk";
        public const int JWT_TOKEN_VALIDITY_MINT = 20;
        public readonly List<UserAccount> _UserAccounts;
        public JwtTokenHandle()
        {
            _UserAccounts = new List<UserAccount>()
            {
                new UserAccount() {Username = "admin",Password = "admin", role="admin"},
                new UserAccount() {Username = "user",Password="user",role = "user"}
            };
        }
        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request)
        {
            if ( string.IsNullOrWhiteSpace(request.Username)||  string.IsNullOrWhiteSpace(request.Password) ) { return null; }
            /* handle progess */
            var userAccount = _UserAccounts.Where(x => x.Username == request.Username && x.Password == request.Password).FirstOrDefault();
            if (userAccount == null) return null;
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINT);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_TOKEN_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,request.Username),
                new Claim("Role", userAccount.role)
            }) ;
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                Username = userAccount.Username,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };
        }
    }
}
