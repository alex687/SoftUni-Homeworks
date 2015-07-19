namespace MountainsCodeFirst.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Country
    {
        private ICollection<Mountain> mountains;

        public Country()
        {
            this.mountains = new HashSet<Mountain>();
        }

        [Key]
        [StringLength(2)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Mountain> Mountains
        {
            get
            {
                return this.mountains;
            }

            set
            {
                this.mountains = value;
            }
        }
    }
}