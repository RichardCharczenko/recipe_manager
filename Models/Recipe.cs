namespace recipeAPI.Models;

public class Recipe{
    public int Id {get; set;}
    public string? RecipeName {get; set;}
    public long Calories {get; set;}
    public int Rating {get; set;}
}