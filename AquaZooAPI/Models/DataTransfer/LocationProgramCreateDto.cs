using System.ComponentModel.DataAnnotations;

namespace AquaZooAPI.Models.DataTransfer
{
    public class LocationProgramCreateDto
    {
         

        [Required]
        public string Name { get; set; }

        [Required]
        public string AgeGroup { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int AquaZooId { get; set; }

       
    }
}
