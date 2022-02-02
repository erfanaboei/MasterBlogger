using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
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
            return _context.Articles
                .Include(x => x.Comments)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    Content = x.Content,
                    CommentsCount = x.Comments.Count(z => z.Status == Statuses.ConfirmedComment)
                }).ToList();
        }

        public ArticleQueryView Get(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    Content = x.Content,
                    CommentsCount = x.Comments.Count(z => z.Status == Statuses.ConfirmedComment),
                    Comments = MapComments(x.Comments.Where(z=>z.Status == Statuses.ConfirmedComment))
                }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentQueryView {Name = comment.Name, Message = comment.Message, CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture)}).ToList();
        }
    }
}