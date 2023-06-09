using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipeAPI.Models;
using RecipeServiceLayer;

namespace recipe_manager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipeController(RecipeContext context)
        {
            _context = context;
        }

        // GET: Recipe
        [EnableCors("_CORSAllowedOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipe()
        {
          if (_context.Recipes == null)
          {
              return NotFound();
          }
            return await _context.Recipes
            .Select(item => RecipeService.ItemToDTO(item))
            .ToListAsync();
        }

        // GET: Recipe/{id}
        [EnableCors("_CORSAllowedOrigins")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
          if (_context.Recipes == null)
          {
              return NotFound();
          }
            var recipe = await _context.Recipes.FindAsync(id);
            
            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // POST: Recipe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeDTO>> PostRecipe(Recipe recipe)
        {
          if (_context.Recipes == null)
          {
              return Problem("Entity set 'RecipeContext.Recipes'  is null.");
          }
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }
    }
}
