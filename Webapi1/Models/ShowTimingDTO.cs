using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Models
{
    public class ShowTimingDTO
    {
        public int MovieId { get; set; }
       
        public int HallId { get; set; }
        public DateTime show_datetime { get; set; }

        public int? available_seats { get; set; }
    }
}
