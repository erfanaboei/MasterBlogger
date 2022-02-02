using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository:IBaseRepository<long,Comment>
    {
        List<CommentViewModel> GetList();
    }
}
