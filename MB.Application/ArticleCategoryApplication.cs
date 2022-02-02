using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using MB.Application.Contracts;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationTime = articleCategory.CreationTime.ToString(CultureInfo.InvariantCulture)
                });
            }
            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title , _articleCategoryValidatorService);
            _articleCategoryRepository.CreateAndSave(articleCategory);
        }

        public void Edit(EditArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Edit(command.Title);
            _articleCategoryRepository.Save();
        }

        public EditArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new EditArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };
        }

        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove(id);
            _articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate(id);
            _articleCategoryRepository.Save();
        }
    }
}
