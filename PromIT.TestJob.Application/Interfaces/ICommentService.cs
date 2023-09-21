using PromIT.TestJob.Application.Common;
using PromIT.TestJob.Application.ViewModels;

namespace PromIT.TestJob.Application.Interfaces
{
    public interface ICommentService
    {
        Task<BaseResponse> AddComment(AddCommentViewModel model);
        Task<List<CommentViewModel>> GetAllComments();
        Task<CommentViewModel> GetComment(Guid id);
    }
}