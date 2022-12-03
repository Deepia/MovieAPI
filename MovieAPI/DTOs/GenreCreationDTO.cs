using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class GenreCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required.")]
        [StringLength(50)]
        [FirstLetterUpperCase]
        public string Name { get; set; }
    }
}
