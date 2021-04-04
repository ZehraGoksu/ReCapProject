using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); //bir kişinin tokenlarını jwt dan gelen claimlerini okumak için claimsPrincipal classını genişletiriz
                                                                                             //bir kişinin """"""" .net deki classı bu
                                                                                             //hangi claimtype bulucaz mesela rolleri mi istiyeceğiz ona göre bu kodları yazdık
                                                                                             //? null olabilir demek
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)//bana çoğunlukla roller lazımsa direk roller döndürülüyor
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
