using System.ComponentModel.DataAnnotations;

namespace AquaZooAPI.Models
{
    public class AquaZooEntity
    {
        [Key]
        public int AquaZooId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PropertyType { get; set; }

        [Required]
        public string State { get; set; }


        public DateTime Created { get; set; }

        [Required]
        public DateTime Started { get; set; }

    }
}
