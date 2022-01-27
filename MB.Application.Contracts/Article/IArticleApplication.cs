using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        EditArticle Get(long id);
        void Create(CreateArticle command);
        void Edit(EditArticle command);
    }
}
