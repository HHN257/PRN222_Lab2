using QuitSmoking.Repository.NamHH;
using QuitSmoking.Repository.NamHH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Service.NamHH
{
    public interface ISystemUserAccountService
    {
        Task<SystemUserAccount?> GetUserByUsernameOrPassword(string username, string password);
        Task<IEnumerable<SystemUserAccount>> GetAllUserAccountsAsync();
    }

    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly SystemUserAccountRepository _systemUserAccountRepository;
        public SystemUserAccountService() => _systemUserAccountRepository ??= new SystemUserAccountRepository();

        public async Task<SystemUserAccount?> GetUserByUsernameOrPassword(string username, string password)
        {
            var user = await _systemUserAccountRepository.GetUserByUsernameOrPassword(username, password);
            return user;
        }

        public async Task<IEnumerable<SystemUserAccount>> GetAllUserAccountsAsync()
        {
            return await _systemUserAccountRepository.GetAllAsync();
        }
    }
}
