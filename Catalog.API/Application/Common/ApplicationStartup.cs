namespace Catalog.API.Application.Common
{
    public static class ApplicationStartup
    {
        public  static void ConfigureApplicationStartup(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
