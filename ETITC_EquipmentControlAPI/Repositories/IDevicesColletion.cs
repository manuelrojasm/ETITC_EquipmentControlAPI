using ETITC_EquipmentControlAPI.Models;

namespace ETITC_EquipmentControlAPI.Repositories
{
    public interface IDevicesColletion
    {
        Task CreateDevices(Devices device);
        Task <Devices> ReadDevices(string Id);
        Task <List<Devices>> GetAllDevices();
        Task UpdateDevices(Devices device);
        Task DeleteDevice(string Id);
    }
}
