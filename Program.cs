using MenuGraph.Data;
using MenuGraph.GraphQL;
using MenuGraph.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Singleton);


// Register repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddGraphQLServer()
    .AddQueryType<RootQueryType>()
    .AddMutationType<RootMutationType>()
    .AddType<CategoryType>()
    .AddType<SectionType>()
    .AddType<ItemType>()
    .AddErrorFilter<GraphQLErrorFilter>(); // Register the custom error filter

var app = builder.Build();

// Configure the app
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
