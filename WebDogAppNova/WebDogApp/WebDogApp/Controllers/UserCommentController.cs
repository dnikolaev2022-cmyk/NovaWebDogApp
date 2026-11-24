using Microsoft.AspNetCore.Mvc;

using WebDogApp.Core.Contracts;
using WebDogApp.Models.UserComment;

namespace WebDogApp.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly IUserCommentService _commentService;

        public UserCommentController(
            IUserCommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            List<IndexVM> comments = _commentService
                .GetComments()
                .Select(item => new IndexVM
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Comment = item.Comment
                })
                .ToList();

            return View(comments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateVM model)
        {
            if (ModelState.IsValid)
            {
                bool created = _commentService.Create(
                    model.UserName,
                    model.Email,
                    model.Comment);

                if (created)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }
    }
}
