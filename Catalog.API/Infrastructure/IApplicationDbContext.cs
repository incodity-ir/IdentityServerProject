using Catalog.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
