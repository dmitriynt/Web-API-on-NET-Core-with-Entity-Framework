using Microsoft.EntityFrameworkCore;
using WebApiApricode.Managers.Implementation;
using WebApiApricode.Managers.Contracts;
using WebApiApricode.Data.Implementation;
using WebApiApricode.Data.Contracts;
using WebApiApricode.Data.Ef;
using WebApiApricode.Data.Contracts.Models.DTO;
using WebApiApricode.Services.Validators;
using FluentValidation;
using Microsoft.OpenApi.Models;
using System.Reflection;
using AutoMapper;

namespace WebApiApricode.Services.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<WebApiApricodeDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("WebApiApricode"));
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddScoped<IGameManager, GameManager>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
        }

        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<GameAddRequest>, GameAddRequestValidator>();
            services.AddTransient<IValidator<GameUpdateRequest>, GameUpdateRequestValidator>();
            services.AddTransient<IValidator<SearchByGenreRequest>, SearchByGenreRequestValidator>();
        }

        public static void ConfigureBackendSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API для сбора данных об играх",
                    Description = "Страница для тестирования работы API",
                    Contact = new OpenApiContact
                    {
                        Name = "Dmitriy Kiverin",
                        Email = "dmitriynt@gmail.com",
                        Url = new Uri("https://coderda.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Free license",
                        Url = new Uri("https://swagger.io/specification/")
                    }
                });
                var xmlFile =
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}