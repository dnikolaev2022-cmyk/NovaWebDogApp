using Microsoft.AspNetCore.Mvc;

using WebDogApp.Core.Contracts;
using WebDogApp.Models.Breed;

namespace WebDogApp.Controllers
{
    public class BreedController : Controller
    {
        private readonly IBreedService _breedService;

        public BreedController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        // READ - всички породи
        public IActionResult Index()
        {
            List<BreedVM> breeds = _breedService.GetBreeds()
                .Select(item => new BreedVM
                {
                    Id = item.Id,
                    Name = item.Name
                })
                .ToList();

            return View(breeds);
        }

        // READ - конкретна порода
        public IActionResult Details(int id)
        {
            var item = _breedService.GetBreedById(id);

            if (item == null)
            {
                return NotFound();
            }

            BreedVM model = new BreedVM
            {
                Id = item.Id,
                Name = item.Name
            };

            return View(model);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BreedVM model)
        {
            if (ModelState.IsValid)
            {
                bool created = _breedService.Create(model.Name);

                if (created)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // UPDATE
        public IActionResult Edit(int id)
        {
            var item = _breedService.GetBreedById(id);

            if (item == null)
            {
                return NotFound();
            }

            BreedVM model = new BreedVM
            {
                Id = item.Id,
                Name = item.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BreedVM model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                bool updated = _breedService.UpdateBreed(
                    id, model.Name);

                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var item = _breedService.GetBreedById(id);

            if (item == null)
            {
                return NotFound();
            }

            BreedVM model = new BreedVM
            {
                Id = item.Id,
                Name = item.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, BreedVM model)
        {
            bool deleted = _breedService.RemoveById(id);

            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }

            var item = _breedService.GetBreedById(id);

            if (item == null)
            {
                return NotFound();
            }

            ModelState.AddModelError("",
                "Cannot delete a breed that has dogs.");

            model.Id = item.Id;
            model.Name = item.Name;

            return View(model);
        }
    }
}