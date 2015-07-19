namespace DistanceCalculatorRest.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Point
    {
        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }
    }
}