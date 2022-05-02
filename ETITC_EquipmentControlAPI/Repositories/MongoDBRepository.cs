using MongoDB.Driver;

namespace ETITC_EquipmentControlAPI.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client; 
        public IMongoDatabase db;

        public MongoDBRepository()
        {   
            client = new MongoClient(Constants.Client);
            db = client.GetDatabase(Constants.DataBase);

        }
    }
}
