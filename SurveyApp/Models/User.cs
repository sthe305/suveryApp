using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(250)]
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [StringLength(250)]
        [Display(Name = "First Names")]
        [Required]
        public string FirstNames { get; set; }

        [Display(Name = "Contact Number")]
        [StringLength(10)]
        [Required]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(5, 120, ErrorMessage = "Age must be between 5 and 120")]
        public int Age { get; set; }

        public ICollection<FavouriteFood> FavouriteFoods { get; set; }
        public ICollection<Question> SurveyQuestions { get; set; }
    }
}
