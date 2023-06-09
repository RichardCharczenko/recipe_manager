using recipeAPI.Models;

namespace RecipeServiceLayer{

    public class RecipeService
    {
        public static RecipeDTO ItemToDTO(Recipe r)
        {
            return new RecipeDTO( r );
        }

        public static bool RecipeExists(int id, RecipeContext _context)
        {
            return _context.Recipes.Any(item => item.Id == id);
        }
    }
    
}