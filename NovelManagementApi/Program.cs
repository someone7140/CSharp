using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using NovelManagementApi.src.graphqlSchema;
using NovelManagementApi.src.model.db;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;
using NovelManagementApi.src.service;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Env.GetString("DB_CONNECT")))
    .AddScoped<IUserAccountService, UserAccountService>()
    .AddScoped<IUserAccountRepository, UserAccountRepository>()
    .AddGraphQLServer()
    .AddType<ErrorCode>()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<UserAccountQuery>()
    .AddTypeExtension<NovelQuery>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<UserAccountMutation>();

var app = builder.Build();
app.MapGraphQL();

app.Run();
