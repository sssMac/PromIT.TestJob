using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Application.ViewModels;

namespace PromIT.TestJob.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // POST: Comment/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(AddCommentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Review", new { id = viewModel.ReviewId });
            }

            var result = await _commentService.AddComment(viewModel);

            if (result.Success)
            {
                return RedirectToAction("Details", "Review", new {id = viewModel.ReviewId});
            }
            else
            {
                return RedirectToAction("Details", "Review", new { id = viewModel.ReviewId }, result.Error);
            }
        }
    }
}
