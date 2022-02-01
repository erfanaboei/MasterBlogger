using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Query.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();
        ArticleQueryView Get(long id);
    }
}
