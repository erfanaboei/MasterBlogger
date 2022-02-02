using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFcore.Repositories
{
    public class ArticleCategoryRepository:BaseRepository<long , ArticleCategory> , IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context):base(context)
        {
            _context = context;
        }
    }
}
