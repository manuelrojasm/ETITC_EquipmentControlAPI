using ETITC_EquipmentControlAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ETITC_EquipmentControlAPI.Repositories
{
    public class UsersColletion : IUsersColletion
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Users> Collection;

        public UsersColletion()
        {
            Collection = _repository.db.GetCollection<Users>("Users");
        }

        public async Task CreateUser(Users user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task<Users> ReadUser(string id)
        {
            Users result = await Collection.FindAsync(e => e.IdentificationNumber == id).Result.FirstOrDefaultAsync();
 
            return result;
        }

        public async Task <List<Users>> GetAllUsers()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task UpdateUser(Users user)
        {
            var filter = Builders<Users>
                .Filter
                .Eq(s => s.IdentificationNumber, user.IdentificationNumber);
            await Collection.ReplaceOneAsync(filter, user);
        }

        public async Task DeleteUser(string IdentificationNumber)
        {

            var filter = Builders<Users>
                .Filter
                .Eq(s => s.IdentificationNumber, IdentificationNumber);

            var result = await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
            result.Status = false;

            await Collection.ReplaceOneAsync(filter, result);
        }

    }
}
