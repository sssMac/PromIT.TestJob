using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromIT.TestJob.Application.Consts;
using PromIT.TestJob.Application.Interfaces;

namespace PromIT.TestJob.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly IReviewService _reviewService;

        public AdminController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: Admin
        [HttpGet]
        public async Task<IActionResult> Index()
            => View(await _reviewService.GetAllReviews());

        // POST: Admin/RemoveReview/[id]
        [HttpPost]
        public async Task<IActionResult> RemoveReview(Guid id)
        {
            var review = await _reviewService.GetReview(id);

            if(review != null) 
            {
                await _reviewService.RemoveReview(id);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Отзыв не найден");
            }
            return View(review);
            
        }
    }
}
