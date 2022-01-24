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

    public class CategoryController : ControllerBase
    {
        public static List<CategoryItem> Categories = new List<CategoryItem> {
            new CategoryItem (1, "Comedia"),
            new CategoryItem (2, "Drama"),
            new CategoryItem (3, "Ciencia ficción"),
            new CategoryItem (4, "Acción"),
            new CategoryItem (5, "Romance"),
            new CategoryItem (6, "Acción"),
            new CategoryItem (7, "Fantasía"),
            new CategoryItem (8, "Documental"),
            new CategoryItem (9, "Aventuras"),
            new CategoryItem (10, "Suspense"),
            new CategoryItem (11, "Terror"),
        };

        public static List<CategoryItem> Subcategories = new List<CategoryItem> {
            new CategoryItem (1, "Comedia"),
            new CategoryItem (2, "Drama"),
            new CategoryItem (3, "Ciencia ficción"),
            new CategoryItem (4, "Acción"),
            new CategoryItem (5, "Romance"),
            new CategoryItem (6, "Acción"),
            new CategoryItem (7, "Fantasía"),
            new CategoryItem (8, "Documental"),
            new CategoryItem (9, "Aventuras"),
            new CategoryItem (10, "Suspense"),
            new CategoryItem (11, "Terror"),
        };

        [HttpGet]
        public ActionResult<List<CategoryItem>> Get() {
            if (Categories == null) {
                return NotFound("No se han encontrado categorías.");
            } else {
                return Ok(Categories);
            }
        }

        [HttpPost]
        public ActionResult Post(CategoryItem categoryItem) {
            var existingCategoryItem = Categories.Find(x => x.Id == categoryItem.Id);
            if (existingCategoryItem != null) {
                return Conflict("Ya existe una categoría con esa ID.");
            } else {
                Categories.Add(categoryItem);
                var resourceUrl = Request.Path.ToString() + "/" + categoryItem.Id;
                return Created(resourceUrl, categoryItem);
            }
        }

        [HttpPut]
        public ActionResult Put(CategoryItem categoryItem) {
            var existingCategoryItem = Categories.Find(x => x.Id == categoryItem.Id);
            if (existingCategoryItem == null) {
                return Conflict("No existe una categoría con esa ID.");
            } else {
                existingCategoryItem.Name = categoryItem.Name;
                var resourceUrl = Request.Path.ToString() + "/" + categoryItem.Id;
                return Ok();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int Id) {
            var categoryItem = Categories.Find(x => x.Id == Id);
            if (categoryItem == null) {
                return NotFound("No existe una categoría con esa ID.");
            } else {
                Categories.Remove(categoryItem);
                return NoContent();
            }
        }
    }
}