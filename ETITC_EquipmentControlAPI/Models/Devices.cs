using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ETITC_EquipmentControlAPI.Models
{
    public class Devices
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Mark { get; set; }
        public string Serial { get; set; }
        public string Img { get; set; }
        public string Observation { get; set; }

        // asociacion del usuario 
        public int IdUser { get; set; }

    }
}
