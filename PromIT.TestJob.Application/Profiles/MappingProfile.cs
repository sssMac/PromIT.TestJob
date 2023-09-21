using AutoMapper;
using PromIT.TestJob.Application.ViewModels;
using PromIT.TestJob.Domain;

namespace PromIT.TestJob.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Review, ReviewViewModel>().ReverseMap();
            CreateMap<Review, AddReviewViewModel>().ReverseMap();
            CreateMap<ReviewViewModel, AddReviewViewModel>().ReverseMap();

            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Comment, AddCommentViewModel>().ReverseMap();
            CreateMap<CommentViewModel, AddCommentViewModel>().ReverseMap();


        }
    }
}
