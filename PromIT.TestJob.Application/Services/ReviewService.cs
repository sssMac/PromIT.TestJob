using AutoMapper;
using PromIT.TestJob.Application.Common;
using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Application.ViewModels;
using PromIT.TestJob.Domain;
using PromIT.TestJob.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.Services
{
    public class ReviewService : BaseService, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public async Task<List<ReviewViewModel>> GetAllReviews()
        {
            var list = await _unitOfWork.ReviewRepository.Get(orderBy: x => x.OrderByDescending(x => x.CreatedAt));
            return _mapper.Map<List<ReviewViewModel>>(list);
        }

        public async Task<List<ReviewViewModel>> GetLazyReviews(int pageNumber, int pageSize)
        {
            var list = await _unitOfWork.ReviewRepository.Get(pageNumber: pageNumber, pageSize: pageSize);
            return _mapper.Map<List<ReviewViewModel>>(list);
        }

        public async Task<ReviewViewModel> GetReview(Guid id)
            => _mapper.Map<ReviewViewModel>(await _unitOfWork.ReviewRepository.GetByID(id, "Comments"));

        public async Task<BaseResponse> AddReview(AddReviewViewModel model)
        {
            try
            {
                var entity = _mapper.Map<Review>(model);

                entity.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.ReviewRepository.Insert(entity);
                await _unitOfWork.Save();

                return BaseResponse.Succeed();
            }
            catch (Exception ex)
            {
                return BaseResponse.Failed(ex.Message);
            }
        }

        public async Task<BaseResponse> RemoveReview(Guid id)
        {
            try
            {
                await _unitOfWork.ReviewRepository.Delete(id);
                await _unitOfWork.Save();

                return BaseResponse.Succeed();
            }
            catch (Exception ex)
            {
                return BaseResponse.Failed(ex.Message);
            }
        }

    }
}
