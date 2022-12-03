using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Entities
{
    public class Genre//: IValidatableObject
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="The field with name {0} is required.")]
        [StringLength(50)]
        [FirstLetterUpperCase]
        public string Name { get; set; }
        

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(Name))
        //    {
        //        var firstLetter = Name[0].ToString();
        //        if(firstLetter != firstLetter.ToUpper())
        //        {
        //            yield  return new ValidationResult("First letter should be upper case",new string[] {nameof(Name)});
        //        }
        //    }
        //}
    }
}
