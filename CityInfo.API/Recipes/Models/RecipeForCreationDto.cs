using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class RecipeForCreationDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should provide a description value.")]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "You should provide a ingredients.")]
        [MaxLength(2000)]
        public string Ingedients { get; set; }
        [Required(ErrorMessage = "You should provide a name preparation steps.")]
        [MaxLength(3000)]
        public string Preparation { get; set; }
    }
}