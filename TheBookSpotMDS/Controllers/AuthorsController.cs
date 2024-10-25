using Microsoft.AspNetCore.Mvc;
using TheBookSpotMDS.Data.Services;
using TheBookSpotMDS.Models;

namespace TheBookSpotMDS.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _service;
        public AuthorsController(IAuthorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Authors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Author author)
        {
            /* if (!ModelState.IsValid)
             {
                 return View(author);
             }
             else
             {
                 //cand campurile au fost completate cum trebuie, adaugam noul autor in baza de date, prin intermediul functiei Add din clasa service
                 await _service.AddAsync(author);
                 TempData["message"] = "Author was successfully added! ";
                 return RedirectToAction("Index");
             }DE CE NU MERG VALIDARILE*/
            await _service.AddAsync(author);
            TempData["message"] = "Author was successfully added! ";
            return RedirectToAction("Index");
        }

        //Get: Authors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null)  return View("Not found");
            return View(authorDetails);
            
        }

        //Get: Authors/Create
        public async Task<IActionResult> Edit(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("Not found");

            return View(authorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,FullName,ProfilePictureURL,Bio")] Author author)
        {
            /*if (!ModelState.IsValid)
            {
               return View(author);
            }
            else
            {
                //cand campurile au fost completate cum trebuie, adaugam noul autor in baza de date, prin intermediul functiei Add din clasa service
                await _service.UpdateAsync(id, author);
                TempData["message"] = "Author was successfully added! ";
                return RedirectToAction(nameof(Index));
            }DE CE NU MERG VALIDARILE*/
            
                await _service.UpdateAsync(id, author);
                TempData["message"] = "Author was successfully added! ";
                return RedirectToAction(nameof(Index));
           
        }

        //Get: Authors/Deleet/1
        public async Task<IActionResult> Delete(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("Not found");

            return View(authorDetails);
        }
        [HttpPost, ActionName("Delete")]//nu putem folosi 2 functii cu acelasi nume si aceiasi parametri, dar stiu ca daca trimit post request cu acelasi nume, intra pe ramura aceasta
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("Not found");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }


    }
}
