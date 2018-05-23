using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipes.Models;

namespace Recipes
{
    public class RecipesDataStore
    {
        public static RecipesDataStore Current { get; } = new RecipesDataStore();
        public List<CategorieOfRecipe> Categories { get; set; }

        public RecipesDataStore()
        {
            Categories = new List<CategorieOfRecipe>()
            {
                new CategorieOfRecipe()
                {
                    Id = 1,
                    Name = "Sriubos",
                    Description = "Įvairios sriubos - šiltos ir šaltos",
                    Recipes = new List<Recipe>()
                    {
                        new Recipe()
                        {
                            Id = 1,
                            Name = "Ukrainietiški barščiai",
                            Description = "Viena populiariausių sriubų su burkėliais",
                            Ingedients = "Burokėliai, mėsa, bulvės, vanduo, prieskoniai",
                            Preparation = "Supjaustyti, išvirti :)"
                        },
                        new Recipe()
                        {
                            Id = 2,
                            Name = "Vištienos sultinys",
                            Description = "Lengva sriuba, labai populairi",
                            Ingedients = "Vištiena, makaronai, morkos, prieskoniai, vanduo",
                            Preparation = "Supjaustyti, išvirti :)"
                        }
                    }
                },
                new CategorieOfRecipe()
                {
                    Id = 2,
                    Name = "Karštieji patiekalai",
                    Description = "Pagrindiniai patiekalai",
                    Recipes = new List<Recipe>()
                    {
                        new Recipe()
                        {
                            Id = 3,
                            Name = "Vištienos kepsnys",
                            Description = "Vištienos kepsnys su garnyru - salotos ir karštos daržovės",
                            Ingedients = "vištiena, šviežios daržovės, šaldytos daržovės",
                            Preparation = "Vištieną iškelpti, paruošti daroves."
                        }
                    }
                }

            };
        }
    }
}
