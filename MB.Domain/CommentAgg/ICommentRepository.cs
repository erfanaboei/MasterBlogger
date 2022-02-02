﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        Comment Get(long id);
        void CreateAndSave(Comment entity);
        void Save();
        List<CommentViewModel> GetList();
   
    }
}
