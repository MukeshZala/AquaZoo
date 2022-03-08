using AquaZooAPI.Data;
using AquaZooAPI.Models;

namespace AquaZooAPI.Repository
{
    public class AquaZooRepository : IAquaZooRepository
    {
        private readonly ApplicationDbContext _db;

        public AquaZooRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        public bool CreateOrUpdateAquaZooEntity(AquaZooEntity entity)
        {

            bool result = true; 
            if ( entity.Id >0)
            {
                _db.AquaZooEntities.Update(entity);
            }else
            {
                _db.AquaZooEntities.Add(entity);
            }

           int recordsEffected= _db.SaveChanges(); 
            if (recordsEffected == 0 )
                 result = false;

            return result;
        }

        public bool DeleteAquaZooEnttity(int id)
        {
            bool result = true;
            if (id > 0)
            {
                AquaZooEntity record = _db.AquaZooEntities.FirstOrDefault(e => e.Id.Equals(id));
                if ( record != null)
                {
                    _db.AquaZooEntities.Remove(record);
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

        public ICollection<AquaZooEntity> GetAquaZooEntities()
        {
            List<AquaZooEntity> list = null;

            list = _db.AquaZooEntities.ToList<AquaZooEntity>();

            return list; 

        }

        public AquaZooEntity GetAquaZooEntity(int id)
        {
            AquaZooEntity aquaZooEntity = null; 
            if (id > 0)
            {
                aquaZooEntity = _db.AquaZooEntities.FirstOrDefault(e => e.Id.Equals(id));
                 

            }
            return aquaZooEntity; 

        }
    }
}
