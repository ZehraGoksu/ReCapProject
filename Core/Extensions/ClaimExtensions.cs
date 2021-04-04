using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {    //varolan bir classa kendi metotlarımızı eklemiş olabiliriz
         //extendion metot yazabilmek için hem metot hem class static olmalı
        public static void AddEmail(this ICollection<Claim> claims, string email)//this kısmı-> ben bunu extend ediyorum bu metotu thisli yapının içine ekle demek claims bize ait değil çünkü
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role))); //rolleri listeye çevir her birini tek tek dolaş her bir rolü git claime ekle 
        }
    }
}
