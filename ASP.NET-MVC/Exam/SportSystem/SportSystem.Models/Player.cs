namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Player : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public double Height { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
