using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.Get(id);
        }

        public RedirectToPageResult OnPost(CreateComment command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails" , new {id = command.ArticleId});
        }
    }
}
