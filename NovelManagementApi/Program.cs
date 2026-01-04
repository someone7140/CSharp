using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NovelManagementApi.src.graphqlSchema;
using NovelManagementApi.src.model.db;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;
using NovelManagementApi.src.service;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Env.GetString("DB_CONNECT")))
    .AddScoped<INovelService, NovelService>()
    .AddScoped<INovelRepository, NovelRepository>()
    .AddScoped<IUserAccountService, UserAccountService>()
    .AddScoped<IUserAccountRepository, UserAccountRepository>()
    .AddGraphQLServer()
    .AddAuthorization()
    .AddType<ErrorCode>()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<UserAccountQuery>()
    .AddTypeExtension<NovelQuery>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<UserAccountMutation>()
    .AddTypeExtension<NovelMutation>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        var jwtSecret = Env.GetString("JWT_SECRET");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL();

app.Run();
