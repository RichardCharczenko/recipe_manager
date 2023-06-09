using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using recipeAPI.Models;


public class RecipeContext : DbContext
{
    public RecipeContext( DbContextOptions<RecipeContext> options) : base(options) {}

    public DbSet<recipeAPI.Models.Recipe> Recipes {get; set; } = default!;
}