using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal List<Recipe> Get()
    {
      return _repo.Get();
    }

    internal Recipe Get(int id)
    {
      Recipe recipe = _repo.Get(id);
      if (recipe == null)
      {
        throw new Exception("Invalid Id");
      }
      return recipe;
    }

    internal Recipe Create(Recipe newRecipe)
    {
      return _repo.Create(newRecipe);
    }

    internal void Delete(int recipeId, string userId)
    {
      Recipe recipeToDelete = Get(recipeId);
      if (recipeToDelete.CreatorId != userId)
      {
        throw new Exception("you do not have permission to Delete");
      }
      _repo.Delete(recipeId);
    }

    internal Recipe Edit(Recipe updatedRecipe)
    {
      Recipe original = Get(updatedRecipe.Id);
      updatedRecipe.Title = updatedRecipe.Title != null ? updatedRecipe.Title : original.Title;
      updatedRecipe.Description = updatedRecipe.Description != null ? updatedRecipe.Description : original.Description;
      updatedRecipe.CookTime = updatedRecipe.CookTime != 0 ? updatedRecipe.CookTime : original.CookTime;
      updatedRecipe.PrepTime = updatedRecipe.PrepTime != 0 ? updatedRecipe.PrepTime : original.PrepTime;
      return _repo.Update(updatedRecipe);
    }
  }
}