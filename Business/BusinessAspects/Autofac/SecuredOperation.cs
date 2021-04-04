using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        //şu yetkisi var bu yetkisi var diye manager da tek tek yazamayız her metodu onun yerine aspect yazıyoruz ve burada yetki kontrolü yapıcaz
        //burası jwt için 
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //her bir istek için herkese bir httpcontexti oluşur 

        public SecuredOperation(string roles) //bana rolleri ver 
        {
            _roles = roles.Split(','); //rolleri virgülle ayırıyoruz çünkü attribute olduğu için başka şans yok-- bir metni belirtilen karakteri görünce ayırarak arraya atıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();// aspectleri enjecte edemiyoruz o yüzden kendimiz yazdık onu enjekte ettik

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //claim rollerini bul
            foreach (var role in _roles) //rolleri gez 
            {
                if (roleClaims.Contains(role)) //ilgili rol varsa return et metotu çalıştırmaya devam et
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //yoksa yetkin yok hatası ver
        }
    }
}
