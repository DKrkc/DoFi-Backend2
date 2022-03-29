using Core6.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core6.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //Extension methodu uyazabimke icin o sinifin static olmasi gerekiyor
        //IServiceCollection->apimizin service bagimliliklarini ekledigimiz ya da araya girmesini
        //istedigimiz servisleri ekledigimiz koleksiyonun kendisi

        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
