using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Review> ReviewRepository { get; }
        public IGenericRepository<Comment> CommentRepository { get; }


        public Task Save();
        public void Dispose();
    }
}
