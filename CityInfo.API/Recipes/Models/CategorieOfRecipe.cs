using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class CategorieOfRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfRecipes
        {
            get
            {
                return Recipes.Count;
            }
        }

        public ICollection<Recipe> Recipes { get; set; }
            = new List<Recipe>();
    }
}
