using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.MongoDb.Repository
{
    public class MongoArticleCategoryRepository : MongoRepositoryBase<string , ArticleCategory> , IArticleCategoryRepository
    {
        private readonly MongoDbContext _context;

        public MongoArticleCategoryRepository(IMongoDbContext context) : base(context)
        {
            
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            throw new NotImplementedException();
        }

        public EditArticleCategory GetDetails(string id)
        {
            throw new NotImplementedException();
        }

        public string GetSlugBy(string id)
        {
            throw new NotImplementedException();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}