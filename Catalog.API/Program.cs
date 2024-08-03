using Catalog.API.Application.Common;
using Catalog.API.Endpoints;
using Catalog.API.Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationContext(builder.Configuration);
builder.Services.ConfigureApplicationStartup();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGroup("/api/v1/products").WithTags("products").MapProductEndpoints();

app.Run();
