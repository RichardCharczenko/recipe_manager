using recipeAPI.Models;

public class RecipeDTO
{
    public int Id {get; set;}
    public string? RecipeName {get; set;}
    public long Calories {get; set;}
    public int Rating {get; set;}

    public RecipeDTO() { }
    public RecipeDTO(Recipe r) => 
    (Id, RecipeName, Calories, Rating) = (r.Id, r.RecipeName, r.Calories, r.Rating);
}