using eTickets.Data.Services;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]    
        public string  Logo{ get; set; } 
        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema descrition is required")]
        public string Description { get; set; }
        //Relationships
        [Display(Name = "Movies")]
        public List<Movie> Movies { get; set; }
    }
}
