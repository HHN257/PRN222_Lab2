using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repository.NamHH.Basic;
using QuitSmoking.Repository.NamHH.DBContext;
using QuitSmoking.Repository.NamHH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Repository.NamHH
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() { }

        public SystemUserAccountRepository(SU25_SE18_PRN222_SE1809_G6_QuitSmokingDBContext context) => _context = context;
        
        public async Task<SystemUserAccount?> GetUserByUsernameOrPassword(string username, string password)
        {
            var user = await _context.SystemUserAccounts
         .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.IsActive);
            return user ?? null;
        }
    }
}
