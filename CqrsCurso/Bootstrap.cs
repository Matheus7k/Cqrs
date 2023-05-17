using CqrsCurso.Domain.Commands.CreatePerson;
using CqrsCurso.Domain.Contracts;
using CqrsCurso.Domain.Queries.GetPerson;
using CqrsCurso.Domain.Queries.ListPerson;
using CqrsCurso.Repository;
using CqrsCurso.Repository.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MongoDB.Driver;

namespace CqrsCurso.Api
{
    public static class Bootstrap
    {
        public static void AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services, configuration);
            services.AddCommands();
            services.AddQueries();
            services.AddMappers();
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<CreatePersonCommandHandler>();
        }

        private static void AddQueries(this IServiceCollection services)
        {
            services.AddTransient<ListPersonQueryHandler>();
        }

        private static void AddMappers(this IServiceCollection services) => 
            services.AddAutoMapper(
                typeof(ListPersonQueryProfile),
                typeof(CreatePersonCommand),
                typeof(GetPersonQueryProfile));

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSetting = configuration.GetSection(nameof(MongoRepositorySetting));
            var clientSettings = MongoClientSettings.FromConnectionString(mongoSetting.Get<MongoRepositorySetting>().ConnectionString);

            //Configure abre acesso ao IOptions
            services.Configure<MongoRepositorySetting>(mongoSetting);
            services.AddSingleton<IMongoClient>(new MongoClient(clientSettings));
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
