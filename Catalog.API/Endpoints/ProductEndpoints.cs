using Catalog.API.Application.Contracts;
using Catalog.API.Application.Services;
using Catalog.API.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Endpoints
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/GetAll", GetAll);
            app.MapPost("/AddProduct", AddProduct);
            return app;
        }

        /// <summary>
        /// get all products
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<PrdocutResponse>> GetAll([AsParameters] CatalogService service)
        {
            var products = await service.dbContext.Products.Select(p => new PrdocutResponse(p.Id, p.Name, p.Price)).ToListAsync();
            return products;
        }

        /// <summary>
        /// add product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        public static async Task<Results<Ok<PrdocutResponse>, BadRequest<string>>> AddProduct([AsParameters] CatalogService service ,[FromBody] AddProductRequest request )
        {
            if (string.IsNullOrEmpty(request.Name.Trim())) return TypedResults.BadRequest("Invalid request");

            Product product = new() { Name = request.Name, Price = request.Price };
            await service.dbContext.Products.AddAsync(product);
            await service.dbContext.SaveChangesAsync();
            var productResponse = new PrdocutResponse(product.Id, product.Name, product.Price);
            return TypedResults.Ok(productResponse);
        }
    }
}
