using AquaZooAPI.Data;
using AquaZooAPI.Models;
using AquaZooAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AquaZooAPI.Repository
{
    public class LocationProgramRepository : ILocationProgramRepository
    {
        private readonly ApplicationDbContext _db;

        public LocationProgramRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        public bool CreateOrUpdateLocationProgramEntity(LocationProgramEntity entity)
        {

            bool result = true; 
            if ( entity.Id >0)
            {
                _db.LocationProgramEntities.Update(entity);
            }else
            {
                _db.LocationProgramEntities.Add(entity);
            }

           int recordsEffected= _db.SaveChanges(); 
            if (recordsEffected == 0 )
                 result = false;

            return result;
        }

        public bool DeleteLocationProgramEnttity(int id)
        {
            bool result = true;
            if (id > 0)
            {
                LocationProgramEntity record = _db.LocationProgramEntities.FirstOrDefault(e => e.Id.Equals(id));
                if ( record != null)
                {
                    _db.LocationProgramEntities.Remove(record);
                    int recordsEffected = _db.SaveChanges();
                    if (recordsEffected == 0)
                        result = false;
                }
                else
                {
                    result = false; 
                }

            }
            

         

            return result;
        }

        public ICollection<LocationProgramEntity> GetLocationsInPrograms(int aquazooProgramId)
        {
            var query =
            _db.LocationProgramEntities.Include(l => l.AquaZooEntity).Where(a => a.AquaZooId.Equals(aquazooProgramId));
            Console.WriteLine(query.ToQueryString()); 
            return query.ToList();

        }

        public ICollection<LocationProgramEntity> GetAllLocationProgramEntities()
        {
            List<LocationProgramEntity> list = null;

            list = _db.LocationProgramEntities.Include(l => l.AquaZooEntity).ToList<LocationProgramEntity>();

            return list; 

        }

        public LocationProgramEntity GetLocationProgramEntity(int id)
        {
            LocationProgramEntity LocationProgramEntity = null; 
            if (id > 0)
            {
                LocationProgramEntity = _db.LocationProgramEntities.Include(l => l.AquaZooEntity).FirstOrDefault(e => e.Id.Equals(id));
                 

            }
            return LocationProgramEntity; 

        }
    }
}
