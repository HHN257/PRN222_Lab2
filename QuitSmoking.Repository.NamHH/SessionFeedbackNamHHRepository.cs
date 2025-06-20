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
    public class SessionFeedbackNamHHRepository : GenericRepository<SessionFeedbackNamHh>
    {
        public SessionFeedbackNamHHRepository() { }

        public SessionFeedbackNamHHRepository(SU25_SE18_PRN222_SE1809_G6_QuitSmokingDBContext context) => _context = context;

        public async Task<List<SessionFeedbackNamHh>> GetAllAsync()
        {
            return await _context.SessionFeedbackNamHhs.ToListAsync() ?? new List<SessionFeedbackNamHh>();
        }
    }
}
