﻿using System;
using System.Collections.Generic;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationTime { get; private set; }
        public ICollection<Article> Articles { get; set; }
        public ArticleCategory(string title , IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle();
            validatorService.CheckThatThisRecordAlreadyExists(title);
            Title = title;
            IsDeleted = false;
            CreationTime = DateTime.Now;
            Articles = new List<Article>();
        }

        protected ArticleCategory()
        {
            
        }
        public void GuardAgainstEmptyTitle()
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new ArgumentNullException();
        }
        public void Edit(string title)
        {
            GuardAgainstEmptyTitle();
            Title = title;
        }
        public void Remove(long id)
        {
            IsDeleted = true;
        }

        public void Activate(long id)
        {
            IsDeleted = false;
        }
    }

}
