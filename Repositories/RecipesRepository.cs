using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Recipe> Get()
    {
      string sql = @"
      SELECT 
      a.*,
      r.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id
      ";
      return _db.Query<Profile, Recipe, Recipe>(sql, (profile, recipes) =>
      {
        recipes.Creator = profile;
        return recipes;
      }, splitOn: "id").ToList();
    }
    internal Recipe Get(int id)
    {
      string sql = @"
      SELECT 
      a.*,
      r.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.id = @id
      ";
      return _db.Query<Profile, Recipe, Recipe>(sql, (profile, recipe) =>
      {
        recipe.Creator = profile;
        return recipe;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }
    internal Recipe Create(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes
      (title, description, cookTime, prepTime, creatorId)
      VALUES
      (@Title, @Description, @CookTime, @PrepTime, @CreatorId);
      SELECT LAST_INSERT_ID();      
      ";
      int id = _db.ExecuteScalar<int>(sql, newRecipe);
      return Get(id);
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    internal Recipe Update(Recipe updatedRecipe)
    {
      string sql = @"
      UPDATE recipes
      SET
      title = @Title,
      description = @Description,
      cookTime = @CookTime,
      prepTime = @PrepTime
      WHERE id = @Id;
      ";
      _db.Execute(sql, updatedRecipe);
      return Get(updatedRecipe.Id);
    }
  }
}