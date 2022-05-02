using ETITC_EquipmentControlAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ETITC_EquipmentControlAPI.Repositories
{
    public class DevicesColletion : IDevicesColletion
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Devices> Collection;

        public DevicesColletion()
        {
            Collection = _repository.db.GetCollection<Devices>("Devices");
        }

        public async Task CreateDevices(Devices device)
        {
            await Collection.InsertOneAsync(device);
        }

        public async Task<Devices> ReadDevices(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<List<Devices>> ReadDevicesByUser(string identificationNumber)
        {
            var result = await Collection.FindAsync(e => e.UserIdentificationNumber == identificationNumber).Result.ToListAsync();
            return result;
        }

        public async Task<List<Devices>> GetAllDevices()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task UpdateDevices(Devices device)
        {
            var filter = Builders<Devices>
                .Filter
                .Eq(s => s.Id, device.Id);
            await Collection.ReplaceOneAsync(filter, device);
        }
      
        public async Task DeleteDevice(string Id)
        {
            var filter = Builders<Devices>.Filter.Eq(s => s.Id, new ObjectId(Id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task InactiveDevice(string Id)
        {
            var filter = Builders<Devices>
            .Filter.Eq(s => s.Id, new ObjectId(Id));

            var result = await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
            result.IsActive = false;

            await Collection.ReplaceOneAsync(filter, result);
        }

        public async Task ActiveDevice(string Id)
        {
            var filter = Builders<Devices>
            .Filter.Eq(s => s.Id, new ObjectId(Id));

            var result = await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
            result.IsActive = true;

            await Collection.ReplaceOneAsync(filter, result);
        }
    }
}
   