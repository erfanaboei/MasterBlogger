using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query.Article
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id , 
                Title = x.Title,
                Image = x.Image , 
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture) , 
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                Content = x.Content
            }).ToList();
        }

        public ArticleQueryView Get(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                Content = x.Content
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}