using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //web apide appsetting dekileri okumaya yarıyor
        private TokenOptions _tokenOptions; //appsetting de okuduğum değerleri tokensoptionsa atayacağız
        private DateTime _accessTokenExpiration; //accesstoken ne zaman geçersizleşicek
        public JwtHelper(IConfiguration configuration) //constructora da bunu enjekte ederek o bilgiye erişebiliyoruz
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //configurationdaki alanı bul Tokenoptionsu appsettingden al ve maple, eşleştir ordakilerle
                                                                                          //configuration görürsek o appSetting demek

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //ne zaman bitecek, şu andan itibaren üzerine dakika olarak ekle
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //anahtar değerini de appsetting içinden al ve securitykey oluştur
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); //hangi algoritme ve anahtarı kullanacak
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //jwt de olması gerekenler tokenoption(appsetting) ,hangi kullanıcı için ve claimleri neleri bu metotla ortaya çıkarıcaz
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, //aslında bu metot zaten hazırda var ama biz buna yeni metotlar ekleyebiliriz buna extension(genişetme) deniyor.
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims) //verilen tüm parametleri vererek bir jwt oluştururuz
        {
            var jwt = new JwtSecurityToken( //jwt oluşturudk ilgili bilgileri girdik
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now, //şu andan önceki bir değer verilemez
                claims: SetClaims(user, operationClaims), //claimler oluşturulurken yardımcı metot oluşrutulmuş
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims) //bu yardımcı metot claim listesini oluşturuyo kullanıcının
        {
            var claims = new List<Claim>(); //sadece claimler olmak zorunda değil kullanıcıya ait birçok bilgi olabilir
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");//başa dolar ekleyince içine kod yazabiliriz iki string birleştirilmiş
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); //namelerini çekip arraya basıp rolleri ekliyor

            return claims;
        }



    }
}
