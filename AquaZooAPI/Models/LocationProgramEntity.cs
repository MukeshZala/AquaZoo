using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaZooAPI.Models
{
    public class LocationProgramEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AgeGroup { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int AquaZooId { get; set; }

        [ForeignKey("AquaZooId")]
        public AquaZooEntity AquaZooEntity { get; set; }

        public DateTime CreatedDate  { get; set; }
    }
}
