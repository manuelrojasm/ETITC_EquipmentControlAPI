using ETITC_EquipmentControlAPI.Models;

namespace ETITC_EquipmentControlAPI.Repositories
{
    public interface IUsersColletion
    {
        Task CreateUser(Users user);
        Task <Users> ReadUser(string Id);
        Task <List<Users>> GetAllUsers();
        Task UpdateUser(Users user);
        Task DeleteUser(string IdentificationNumber);
    }
}
