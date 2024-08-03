using Catalog.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Common
{
    public static class CommonStartup
    {
        public static void ConfigureApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.Get<AppSettings>();
            services.Configure<AppSettings>(configuration);


            services.AddDbContextPool<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(settings.ConnectionStrings.CatalogApiConnection);
            }, poolSize: 16);

        }
    }
}
