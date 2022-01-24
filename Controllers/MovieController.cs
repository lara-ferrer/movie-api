using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        public static List<MovieItem> Movies = new List<MovieItem> {
            new MovieItem(1, "Don't Look Up", "Adam McKay", 2021, 138, 4, "Narra la historia de dos astrónomos mediocres que deben emprender una gira mediática descomunal para avisar a la humanidad de la llegada de un cometa que va a destruir la Tierra.", "Adam McKay", "Leonardo DiCaprio, Jennifer Lawrence, Meryl Streep", 10, 3, 1),
            new MovieItem(2, "Spider-Man: No Way Home", "Chris McKenna", 2021, 148, 5, "Con la identidad de Spider-Man ahora revelada, Peter le pide ayuda al Doctor Strange. Cuando un hechizo sale mal, comienzan a aparecer peligrosos enemigos de otros mundos, lo que obliga a Peter a descubrir lo que realmente significa ser Spider-Man.", "Jon Watts", "Tom Holland, Zendaya", 20, 4, 9),
        };

        [HttpGet]
        public ActionResult<List<MovieItem>> Get() {
            if (Movies == null) {
                return NotFound("No se han encontrado películas.");
            } else {
                return Ok(Movies);
            }
        }

        [HttpGet]
        [Route("GetByCategoryID/{CategoryId}")]
        public ActionResult<List<MovieItem>> GetByCategoryId(int CategoryId) {
            var movieItem = Movies.FindAll(x => x.CategoryId == CategoryId);
            return movieItem == null ? NotFound() : Ok(movieItem);
        }

        [HttpGet]
        [Route("GetByMovieID/{MovieId}")]
        public ActionResult GetByMovieID(int MovieId) {
            var movieItem = Movies.FindAll(x => x.Id == MovieId);
            return movieItem == null ? NotFound() : Ok(movieItem);
        }

        [HttpPost]
        public ActionResult Post(string Title, string Writers, int Year, int Duration, int Rating, string Sinopsis, string Director, string Actors, int Likes, int CategoryId, int SubcategoryId) {
            var LastId = Movies.Count;
            var Id = LastId + 1;
            var newMovieItem = new MovieItem(Id, Title, Writers, Year, Duration, Rating, Sinopsis, Director, Actors, Likes, CategoryId, SubcategoryId);

            Movies.Add(newMovieItem);
            var resourceUrl = Request.Path.ToString() + "/" + newMovieItem.Id;
            return Created(resourceUrl, newMovieItem);
        }

        [HttpPut]
        public ActionResult Put(MovieItem movieItem) {
            var existingMovieItem = Movies.Find(x => x.Id == movieItem.Id);
            if (existingMovieItem == null) {
                return Conflict("No existe una película con esa ID.");
            } else {
                existingMovieItem.Title = movieItem.Title;
                var resourceUrl = Request.Path.ToString() + "/" + movieItem.Id;
                return Ok();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int Id) {
            var movieItem = Movies.Find(x => x.Id == Id);
            if (movieItem == null) {
                return NotFound("No existe una película con esa ID.");
            } else {
                Movies.Remove(movieItem);
                return NoContent();
            }
        }
    }
}
