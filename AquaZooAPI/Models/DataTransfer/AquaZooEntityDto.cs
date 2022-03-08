namespace AquaZooAPI.Models.DataTransfer
{
    public class AquaZooEntityDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string PropertyType { get; set; }

        public string State { get; set; }

        public DateTime Created { get; set; }

        public DateTime Started { get; set; }
    }
}
