using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;

namespace Recipes.Controllers
{
    [Route("api2/categories")]
    public class RecipesController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("{categoryId}/recipes")]
        public IActionResult GetRecipes(int categoryId)
        {
            var catetory = RecipesDataStore.Current.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (catetory == null)
            {
                return NotFound();
            }
            return Ok(catetory.Recipes);
        }

        [HttpGet("{categoryId}/recipes/{id}", Name = "GetRecipesForCategory")]
        public IActionResult Getrecipes(int categoryId, int id)
        {
            var catetory = RecipesDataStore.Current.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (catetory == null)
            {
                return NotFound();
            }

            var recipe = catetory.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost("{categoryId}/recipes/")]
        public IActionResult CreateRecipe(int categoryId,
            [FromBody] RecipeForCreationDto recipe)
        {
            if (recipe == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = RecipesDataStore.Current.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var maxrecipeId = RecipesDataStore.Current.Categories.SelectMany(
                c => c.Recipes).Max(r => r.Id);

            var finalRecipe = new Recipe()
            {
                Id = ++maxrecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Ingedients = recipe.Ingedients,
                Preparation = recipe.Preparation
            };

            category.Recipes.Add(finalRecipe);
            return CreatedAtRoute("GetRecipesForCategory", new
                {category = categoryId, id = finalRecipe.Id}, finalRecipe);
        }

        [HttpPut("{categoryId}/recipes/{id}")]
        public IActionResult UpdateRecipe(int categoryId, int id,
            [FromBody] RecipeForUpdateDto recipe)
        {
            if (recipe == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = RecipesDataStore.Current.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var recipeFromStore = category.Recipes.FirstOrDefault(r =>
                r.Id == id);

            if (recipeFromStore == null)
            {
                return NotFound();
            }

            recipeFromStore.Name = recipe.Name;
            recipeFromStore.Description = recipe.Description;
            recipeFromStore.Ingedients = recipe.Ingedients;
            recipeFromStore.Preparation = recipe.Preparation;

            return NoContent();
        }

        [HttpPatch("{categoryId}/recipes/{id}")]
        public IActionResult PartiallyUpdateRecipe(int categoryId, int id,
            [FromBody] JsonPatchDocument<RecipeForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var category = RecipesDataStore.Current.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                return NotFound();
            }

            var recipeFromStore = category.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipeFromStore == null)
            {
                return NotFound();
            }

            var recipe =
                new RecipeForUpdateDto()
                {
                    Name = recipeFromStore.Name,
                    Description = recipeFromStore.Description,
                    Ingedients = recipeFromStore.Ingedients,
                    Preparation = recipeFromStore.Preparation
                };

            patchDoc.ApplyTo(recipe, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(recipe);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            recipeFromStore.Name = recipe.Name;
            recipeFromStore.Description = recipe.Description;
            recipeFromStore.Ingedients = recipe.Ingedients;
            recipeFromStore.Preparation = recipe.Preparation;

            return NoContent();
        }

        [HttpDelete("{categoryId}/recipes/{id}")]
        public IActionResult DeleteRecipe(int categoryId, int id)
        {
            var category = RecipesDataStore.Current.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                return NotFound();
            }

            var recipeFromStore = category.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipeFromStore == null)
            {
                return NotFound();
            }

            category.Recipes.Remove(recipeFromStore);

            return NoContent();
        }
    }
}