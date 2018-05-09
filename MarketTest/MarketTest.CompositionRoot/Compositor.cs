using MarketTest.BL.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using MarketTest.BL.Services;
using MarketTest.DAL.Infrastrusture;

namespace MarketTest.CompositionRoot
{
    public class Compositor
    {
        public void Compose(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMarketService, MarketService>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
