using ETITC_EquipmentControlAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ETITC_EquipmentControlAPI.Repositories
{
    public class RegisterDevicesColletion : IRegisterDevicesColletion
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<RegisterDevices> Collection;

        public RegisterDevicesColletion()
        {
            Collection = _repository.db.GetCollection<RegisterDevices>("RegisterDevices");
        }

        public async Task CreateRegisterDevices(RegisterDevices registerDevices)
        {
            await Collection.InsertOneAsync(registerDevices);
        }

        public async Task<RegisterDevices> ReadRegisterDevices(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<List<RegisterDevices>> GetAllRegisterDevices()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task UpdateRegisterDevices(RegisterDevices registerDevices)
        {
            var filter = Builders<RegisterDevices>
                .Filter
                .Eq(s => s.Id, registerDevices.Id);
            await Collection.ReplaceOneAsync(filter, registerDevices);
        }
      
        public async Task DeleteRegisterDevices(string Id)
        {
            var filter = Builders<RegisterDevices>.Filter.Eq(s => s.Id, new ObjectId(Id));
            await Collection.DeleteOneAsync(filter);
        }
    }
}
   