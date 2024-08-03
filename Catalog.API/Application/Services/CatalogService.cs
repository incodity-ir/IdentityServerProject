using Catalog.API.Infrastructure;

namespace Catalog.API.Application.Services
{
    public class CatalogService
    {
        public IApplicationDbContext dbContext { get; set; }

        public CatalogService(IApplicationDbContext DbContext)
        {
            dbContext = DbContext;
        }
    }
}
