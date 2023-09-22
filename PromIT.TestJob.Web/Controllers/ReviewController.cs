using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Application.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace PromIT.TestJob.Web.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: Review
        [HttpGet]
        public async Task<IActionResult> Index()
            => View();

        // GET: Review/GetReviews
        [HttpGet]
        public async Task<IActionResult> GetReviews(int pageNumber, int pageSize)
        {
            var list = await _reviewService.GetLazyReviews(pageNumber, pageSize);
            return Json(list);
        }
        // GET: Review/Details/[id]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
            => View(await _reviewService.GetReview(id));

        // GET: Review/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new AddReviewViewModel { UserName = User.Identity.Name });
        }

        // POST: Review/Create
        [HttpPost]
        public async Task<IActionResult> Create(AddReviewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _reviewService.AddReview(viewModel);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Error);
                }
            }
            return View(viewModel);

        }

    }
}
