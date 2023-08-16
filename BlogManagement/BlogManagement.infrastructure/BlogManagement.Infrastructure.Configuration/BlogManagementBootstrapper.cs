

using _0_Framework.Infrastructure;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.BlogManagement.infrastructure.BlogManagement.Infrastructure.EFCore;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EFCore.Repository;
using BlogManagement.Infrastructure.MongoDb;
using BlogManagement.Infrastructure.MongoDb.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ParkBee.MongoDb.DependencyInjection;

namespace BlogManagement.Infrastructure.Configuration
{
    public class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            // services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryRepository, MongoArticleCategoryRepository>();
            
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            // services.AddTransient<IArticleQuery, ArticleQuery>();
            // services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

            services.AddDbContext<BlogEfCoreContext>(x => x.UseSqlServer(connectionString));



            services.AddSingleton<IMongoClient> (context =>
            {
                return new MongoClient ("mongodb://admin:pass123@localhost:27017/?authSource=admin");
            });

            services.AddScoped<IMongoDatabase> (context =>
            {
                var client = context.GetService<IMongoClient> ();
                return client.GetDatabase ("ExampleDatabase");

            }); 

            services.AddScoped<IMongoDbContext , MongoDbContext>();

        }

    }
}
