using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(1000)]
        [Required]
        [Display(Name = "Question")]
        public string SurveyQuestion { get; set; }
        public int Rating { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
