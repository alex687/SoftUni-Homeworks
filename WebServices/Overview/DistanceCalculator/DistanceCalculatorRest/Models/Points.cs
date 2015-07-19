namespace DistanceCalculatorRest.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Points
    {
        [Required]
        public Point Start { get; set; }

        [Required]
        public Point End { get; set; }
    }
}