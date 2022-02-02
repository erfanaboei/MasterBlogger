using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using _01_Framework.Infrastructure;
using MB.Application.Contracts;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            return articleCategories
                .Select(articleCategory => new ArticleCategoryViewModel {Id = articleCategory.Id, Title = articleCategory.Title, IsDeleted = articleCategory.IsDeleted, CreationTime = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)}).OrderByDescending(x=>x.Id).ToList();
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = new ArticleCategory(command.Title , _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Edit(command.Title);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove(id);
            _unitOfWork.CommitTran();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate(id);
            _unitOfWork.CommitTran();
        }
    }
}
