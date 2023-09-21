using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PromIT.TestJob.Application.Common;
using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Application.ViewModels;
using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.Services
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {}

        public async Task<List<CommentViewModel>> GetAllComments()
            => _mapper.Map<List<CommentViewModel>>(await _unitOfWork.CommentRepository.Get());

        public async Task<CommentViewModel> GetComment(Guid id)
            => _mapper.Map<CommentViewModel>(await _unitOfWork.CommentRepository.GetByID(id));

        public async Task<BaseResponse> AddComment(AddCommentViewModel model)
        {
            try
            {
                var entity = _mapper.Map<Comment>(model);

                entity.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.CommentRepository.Insert(entity);
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
