using System.ComponentModel.DataAnnotations;

namespace AquaZooAPI.Models.DataTransfer
{
    public class AquaZooEntityDto
    {

        public int Id { get; set; }

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
