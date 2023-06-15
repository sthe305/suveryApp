using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models
{
    public class SurveyViewModel
    {
        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstNames { get; set; }

        [Required]
        public string ContactNumber { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Range(5, 120, ErrorMessage = "Age must be between 5 and 120")]
        public int Age { get; set; }

        [Required]
        public string FavouriteFoods { get; set; }

        [Required]
        public int EatOutRating { get; set; }

        [Required]
        public int WatchMoviesRating { get; set; }

        [Required]
        public int WatchTVRating { get; set; }

        [Required]
        public int ListenToRadioRating { get; set; }
    }
}
