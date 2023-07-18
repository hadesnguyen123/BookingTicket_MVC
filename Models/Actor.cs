using System.ComponentModel.DataAnnotations;

namespace BookingTicket.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]  //giúp hiện thị tên thuộc tính trong view
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "BioGraphy")]
        public string Bio { get; set; }

        //Relatuionships
        public List<Actor_Movie> Actors_Movies { get; set; }
    
    }
}
