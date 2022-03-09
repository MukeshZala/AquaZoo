using AquaZooAPI.Models;

namespace AquaZooAPI.Repository.IRepository
{
    public interface IAquaZooRepository
    {
        ICollection<AquaZooEntity> GetAquaZooEntities();
        AquaZooEntity GetAquaZooEntity(int Id);

        bool CreateOrUpdateAquaZooEntity(AquaZooEntity entity);
        bool DeleteAquaZooEnttity(int id); 
    }
}
