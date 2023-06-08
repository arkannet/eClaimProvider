using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Application.Interfaces.Services.Storage;
using eClaimProvider.Application.Interfaces.Services.Storage.Provider;
using eClaimProvider.Application.Interfaces.Serialization.Serializers;
using eClaimProvider.Application.Serialization.JsonConverters;
using eClaimProvider.Infrastructure.Repositories;
using eClaimProvider.Infrastructure.Services.Storage;
using eClaimProvider.Application.Serialization.Options;
using eClaimProvider.Infrastructure.Services.Storage.Provider;
using eClaimProvider.Application.Serialization.Serializers;
using eClaimProvider.Domain.Entities.Catalog;

namespace eClaimProvider.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IRevenueRepository, RevenueRepository>()
                .AddTransient<IResultRepository, ResultRepository>()
                .AddTransient<ICompanyRepository, CompanyRepository>()
                .AddTransient<IBrandRepository, BrandRepository>()
                .AddTransient<IServiceRepository, ServiceRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IDocumentRepository, DocumentRepository>()
                .AddTransient<IInvoice_DetailRepository, Invoice_DetailRepository>()
                .AddTransient<IPatientRepository, PatientRepository>()
                .AddTransient<IInvoice_SubDetailRepository, Invoice_SubDetailRepository>()
                .AddTransient<IInvoiceRepository, InvoiceRepository>()
                .AddTransient<IDocumentTypeRepository, DocumentTypeRepository>()
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }

        public static IServiceCollection AddExtendedAttributesUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IExtendedAttributeUnitOfWork<,,>), typeof(ExtendedAttributeUnitOfWork<,,>));
        }

        public static IServiceCollection AddServerStorage(this IServiceCollection services)
            => AddServerStorage(services, null);

        public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions> configure)
        {
            return services
                .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
                .AddScoped<IStorageProvider, ServerStorageProvider>()
                .AddScoped<IServerStorageService, ServerStorageService>()
                .AddScoped<ISyncServerStorageService, ServerStorageService>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    configure?.Invoke(configureOptions);
                    if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                });
        }
    }
}