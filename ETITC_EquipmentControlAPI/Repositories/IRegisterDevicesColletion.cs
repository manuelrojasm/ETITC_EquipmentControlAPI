using ETITC_EquipmentControlAPI.Models;

namespace ETITC_EquipmentControlAPI.Repositories
{
    public interface IRegisterDevicesColletion
    {
        Task CreateRegisterDevices(RegisterDevices registerDevices);
        Task <RegisterDevices> ReadRegisterDevices(string Id);
        Task <List<RegisterDevices>> GetAllRegisterDevices();
        Task UpdateRegisterDevices(RegisterDevices registerDevices);
    }
}
