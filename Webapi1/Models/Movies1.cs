using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Webapi1.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string? Name { get; set; }
  
        public string? Cast { get; set; }

        public string? Genre { get; set; }
        public int? Price { get; set; }
      
        public DateTime ReleaseDate { get; set; }
    }
    public class  MovieHall
    {
        [Key]
        public int HallId { get; set; }
        public string? HallName { get; set; }
        public string?   HallLocation { get; set; }
        public int TotalSeat { get; set; }

     //   public ICollection<ShowTiming> Timing { get; set; }
    }
    public class ShowTiming
    {
        [Key]
        public int TimingId { get; set; }
        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        [ForeignKey("MovieHall")]
        public int HallId { get; set; }
        public DateTime show_datetime { get; set; }
      
        public int? available_seats { get; set; }
        public Movies Movies { get; set; }
        public MovieHall MovieHall { get; set; }


    }
}
