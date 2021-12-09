using Microsoft.Extensions.DependencyInjection;
using ViewSpotFinder.Business;

public class StartUp
    {
        public static IServiceCollection Container => ConfigureServices();


        private static IServiceCollection ConfigureServices()
        {

            var services = new ServiceCollection();

            services.AddTransient<IViewSpotFinder, ViewSpotFinder.Business.ViewSpotFinder>();

            return services;
        }
    }
