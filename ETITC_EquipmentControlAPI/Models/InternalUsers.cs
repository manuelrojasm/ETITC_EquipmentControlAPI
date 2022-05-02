using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ETITC_EquipmentControlAPI.Models
{
    public class InternalUsers
    {

        public string IdentificationNumber { get; set; }
        public string Password { get; set; } = String.Empty;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
