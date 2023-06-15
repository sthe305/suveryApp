using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class FavouriteFood
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(250)]
        [Required]
        [Display(Name = "Name")]
        public string FoodName { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
