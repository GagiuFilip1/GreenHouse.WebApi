using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using GreenHouse.Core.GraphQl.enums;
using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.schemas;
using GreenHouse.GraphQL.schemas.models;
using GreenHouse.GraphQL.schemas.schemaGroups;
using GreenHouse.GraphQL.schemas.schemaGroups.requests;
using GreenHouse.Repositories.implementation;
using GreenHouse.Repositories.model;
using GreenHouse.Services.implementations;
using GreenHouse.Services.models;
using Microsoft.Extensions.DependencyInjection;

namespace GreenHouse.IoC
{
    public static class ServicesRegistry
    {
        public static void ResolveRepositories(IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserFriendRepository, UserFriendRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
        }

        public static void ResolveServices(IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
        }
        
        public static void ResolveGraphQl(IServiceCollection services)
        {
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            // Add Here GraphQl Enums
            services.AddSingleton<OrderDirectionEnum>();
            services.AddSingleton<AccountTypeEnum>();
            services.AddSingleton<ForestStateTypeEnum>();

            // Add Here New Schemas
            services.AddScoped<ISchemaGroup, AccountSchema>();
            services.AddScoped<ISchemaGroup, UserFriendSchema>();
            services.AddScoped<ISchemaGroup, ReportSchema>();
            services.AddScoped<ISchemaGroup, ScheduleSchema>();
            services.AddScoped<ISchemaGroup, LoginSchema>();

            services.AddScoped<RootSchema>();
            services.AddScoped<RootMutation>();
            services.AddScoped<ISchema, RootSchema>();

            services.AddGraphQL(opt => { opt.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
        }
    }
}