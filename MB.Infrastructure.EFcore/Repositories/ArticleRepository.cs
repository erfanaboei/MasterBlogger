using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFcore.Repositories
{
    public class ArticleRepository:BaseRepository<long , Article> ,IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context):base(context)
        {
            _context = context;
        }
        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x =>
                new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
                }).ToList();
        }
    }
}
