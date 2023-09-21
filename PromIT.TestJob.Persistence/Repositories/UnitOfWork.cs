using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReviewsDbContext _context;

        public UnitOfWork(ReviewsDbContext context)
            => _context = context;

        private IGenericRepository<Review> _reviewRepository;
        private IGenericRepository<Comment> _commentRepository;

        public IGenericRepository<Review> ReviewRepository =>
            _reviewRepository ??= new GenericRepository<Review>(_context);

        public IGenericRepository<Comment> CommentRepository =>
            _commentRepository ??= new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
