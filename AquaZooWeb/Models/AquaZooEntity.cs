using System.ComponentModel.DataAnnotations;

namespace AquaZooWeb.Models
{
    public class AquaZooEntity
    {

        public int AquaZooId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PropertyType { get; set; }

        [Required]
        public string State { get; set; }

        public DateTime Created { get; set; }

        public DateTime Started { get; set; }
    }
}
