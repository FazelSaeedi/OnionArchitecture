using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Article;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<string, Article>
    {
        EditArticle GetDetails(string id);
        Article GetWithCategory(string id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
    }
}
