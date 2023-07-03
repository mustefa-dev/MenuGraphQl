using MenuGraph.Data;
using MenuGraph.GraphQL;
using MenuGraph.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddGraphQLServer()
    .AddQueryType<CategoryQueryType>()
    .AddMutationType<CategoryMutationType>()
    .AddType<CategoryType>()
    .AddErrorFilter<GraphQLErrorFilter>(); // Register the custom error filter

var app = builder.Build();

// Configure the app
app.UseRouting();

app.MapGraphQL("/graphql"); // Use top-level route registration

app.Run();

