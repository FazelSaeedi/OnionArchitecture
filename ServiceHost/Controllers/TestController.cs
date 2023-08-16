using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application.ZarinPal;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using MH.DDD.Core.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace ServiceHost.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class TestController: BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestController> _logger;
        private  IArticleApplication articleApplication;
        private  IArticleCategoryApplication articleCategoryApplication;

        public TestController(ILogger<TestController> logger, IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication) : base(logger)
        {
            this.articleApplication = articleApplication;
            this.articleCategoryApplication = articleCategoryApplication;
        }

        [HttpGet("create")]
        public async Task<ServiceResult<string>> GetAvengers()
        {
            
            articleCategoryApplication.Create(new CreateArticleCategory());
            
            // BsonClassMap.RegisterClassMap<Article>(cm =>
            //     {
            //     cm.AutoMap();
            //     cm.UnmapMember(m => m.Category);
            // });
            // MongoClient client = new MongoClient("mongodb://admin:pass123@localhost:27017/?authSource=admin");
            // IMongoDatabase database = client.GetDatabase("ExampleDatabase");
            // var _playlistCollection = database.GetCollection<Article>("Article");

            // _playlistCollection.InsertOne(new Article("ok" , "ok" , "ok" , "ok" , "aa" , "ss" , DateTime.Now , "ss" , "qweqwe" , "asdsa" , "asdasd" , Guid.NewGuid().ToString()));
            // // var users = await _context.Articles.ToListAsync();
            // // _context.Articles.InsertOneAsync(new Article("ok" , "ok" , "ok" , "ok" , "aa" , "ss" , DateTime.Now , "ss" , "qweqwe" , "asdsa" , "asdasd" , 22));
            // var T = articleApplication.Create(new CreateArticle(){  });
            return ServiceResult.Create<string>("OK");
            // return ServiceResult.Empty.SetError("ok" , 400 ).To<string>();
        }

        [HttpGet("create2")]
        public ServiceResult<string> GetAvengers2()
        {

            // throw new Exception("Wrong");
            // var T = articleApplication.Create(new CreateArticle(){  });
            throw ServiceResult.Create<string>("OK").ToException();
            // return ServiceResult.Empty.SetError("ok" , 400 ).To<string>();

        }

    }
}