using PromIT.TestJob.Application.Common;
using PromIT.TestJob.Application.ViewModels;

namespace PromIT.TestJob.Application.Interfaces
{
    public interface IReviewService
    {
        Task<BaseResponse> AddReview(AddReviewViewModel model);
        Task<List<ReviewViewModel>> GetAllReviews();
        Task<ReviewViewModel> GetReview(Guid id);
        Task<BaseResponse> RemoveReview(Guid id);
    }
}