using _0_Framework.Domain;
//using BlogManagement.Application.Contracts.ArticleCategory;
using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<string, ArticleCategory>
    {
        string GetSlugBy(string id);
        EditArticleCategory GetDetails(string id);
        List<ArticleCategoryViewModel> GetArticleCategories();
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
