using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        ArticleCategory Get(long id);
        void CreateAndSave(ArticleCategory entity);
        void Save();
        bool Exists(string title);
    }
}
