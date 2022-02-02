using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Infrastructure.Query;

namespace MB.Presentation.MVCCore.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> Articles { get; set; }
        private readonly IArticleQuery _articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet()
        {
            Articles = _articleQuery.GetArticles();
        }
    }
}
