using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = new Movie
            {
                Genre = "Terror",
                Id = 1,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror"
            };

            return View(movie);
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var listMovies = new List<Movie>();

            var movie1 = new Movie
            {
                Genre = "Terror",
                Id = 1,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror"
            };
            listMovies.Add(movie1);

            var movie2 = new Movie
            {
                Genre = "Terror",
                Id = 2,
                Price = 2,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror II"
            };
            listMovies.Add(movie2);

            return View(listMovies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseDate,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                // Aquí es donde normalmente guardarías la película en la base de datos.
                // Pero como no tienes base de datos configurada, simplemente redirigimos a Index.
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
    }
}
