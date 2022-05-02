using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ETITC_EquipmentControlAPI.Models
{
    public class LoggedUsers
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationToken { get; set; }
        public bool status { get; set; }
    }
}
