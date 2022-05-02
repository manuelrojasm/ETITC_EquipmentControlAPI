using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ETITC_EquipmentControlAPI.Models
{
    public class Users
    {

        [BsonId]
        public ObjectId Id { get; set; }
        public string IdentificationNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime EntryDate { get; set; }
        public bool status{ get; set; }

    }
}
