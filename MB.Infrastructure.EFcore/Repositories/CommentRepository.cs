﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFcore.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public Comment Get(long id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);
        }

        public void CreateAndSave(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id ,
                Name = x.Name , 
                Email = x.Email , 
                Message = x.Message , 
                Status = x.Status ,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture) ,
                Article = x.Article.Title
            }).ToList();
        }
    }
}
