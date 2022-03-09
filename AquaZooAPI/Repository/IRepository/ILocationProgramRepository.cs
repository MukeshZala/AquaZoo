using AquaZooAPI.Models;

namespace AquaZooAPI.Repository.IRepository
{
    public interface ILocationProgramRepository
    {
        ICollection<LocationProgramEntity> GetAllLocationProgramEntities();

        ICollection<LocationProgramEntity> GetLocationsInPrograms(int aquazooProgramId); 

        LocationProgramEntity GetLocationProgramEntity(int Id);

        bool CreateOrUpdateLocationProgramEntity(LocationProgramEntity entity);
        bool DeleteLocationProgramEnttity(int id); 


    }
}
