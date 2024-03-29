using SupplierManagement.Data.Models;

namespace SupplierManagement.API.IRepository
{
    public interface IAccount
    {
        Task<bool> CheckUser(string Email);
        Task<bool> SignupUser(UserSignup UserDto);
        Task<bool> LoginUser(UserLogin loginDto);
        Task<string> CreateToken(string Email);
    }
}
