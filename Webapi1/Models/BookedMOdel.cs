namespace Webapi1.Models
{
    public class BookedMOdel
    {
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public string? HallName { get; set; }
        public int? Noofticket { get; set; }
        public int? PricePerEach { get; set; }
        public int? Total { get; set; }
        public DateTime? Showdate { get; set; }

        public DateTime? bookeddate { get; set; }
    }
}
