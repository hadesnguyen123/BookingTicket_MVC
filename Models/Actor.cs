using System.ComponentModel.DataAnnotations;

namespace BookingTicket.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Profile Picture")]  //giúp hiện thị tên thuộc tính trong view
        [Required(ErrorMessage ="Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Fullname is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Fullname must be beetween 3 and 50")]
        public string FullName { get; set; }

        [Display(Name = "BioGraphy")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relatuionships
        public List<Actor_Movie> Actors_Movies { get; set; }
    
    }
}
