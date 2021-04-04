using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //enjection altyapısını aynen okuyabilmek için araç
        //web apideki gibi enjections oluşturabilmemizi sağlıyor
        //istediğimiz herhangi bir interface in servicedeki karşılığını bu tool vasıtasıyla alabiliriz
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) //.net servislerini kullanarak onları build et
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
