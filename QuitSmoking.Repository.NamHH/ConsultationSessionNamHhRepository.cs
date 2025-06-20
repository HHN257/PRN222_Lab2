using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repository.NamHH.Basic;
using QuitSmoking.Repository.NamHH.DBContext;
using QuitSmoking.Repository.NamHH.Models;
using QuitSmoking.Repository.NamHH.Pangination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Repository.NamHH
{
    public class ConsultationSessionNamHhRepository : GenericRepository<ConsultationSessionNamHh>
    {
        public ConsultationSessionNamHhRepository()
        {
            _context = new SU25_SE18_PRN222_SE1809_G6_QuitSmokingDBContext(); // Initialize the context
        }

        public ConsultationSessionNamHhRepository(SU25_SE18_PRN222_SE1809_G6_QuitSmokingDBContext context) => _context = context;

        public async Task<List<ConsultationSessionNamHh>> GetAllAsync()
        {
            var coachChat = await _context.ConsultationSessionNamHhs
                .Include(c =>
            c.SessionFeedbackNamHhs)
                .Include(r => r.UserAccount)
                .Include(r => r.Coach)
                .ToListAsync(); // Include sub table

            return coachChat ?? new List<ConsultationSessionNamHh>(); //If null create new list
        }

        public async Task<ConsultationSessionNamHh> GetByIdAsync(int id)
        {
            var coachChat = await _context.ConsultationSessionNamHhs.Include(c =>
            c.SessionFeedbackNamHhs)
                .Include(r => r.UserAccount)
                .Include(r => r.Coach)
                .FirstOrDefaultAsync(d => d.ConsultationSessionNamHhid == id);

            return coachChat ?? new ConsultationSessionNamHh();
        }

        public async Task<PaginatedList<ConsultationSessionNamHh>> SearchAsync(
    string memberId, string coachId, int rating, string searchTerm, int pageNumber, int pageSize)
        {
            var query = _context.ConsultationSessionNamHhs
                .Include(c => c.SessionFeedbackNamHhs)
                .Include(r => r.UserAccount)
                .Include(r => r.Coach)
                .AsQueryable();

            if (!string.IsNullOrEmpty(memberId))
                query = query.Where(c => c.UserAccountId.ToString() == memberId);

            if (!string.IsNullOrEmpty(coachId))
                query = query.Where(c => c.CoachId.ToString() == coachId);

            if (rating > 0)
                query = query.Where(c => c.Rating == rating);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    (c.UserAccount.Email.Contains(searchTerm)) ||
                    (c.Coach.Email.Contains(searchTerm)) ||
                    (c.SessionTopic.Contains(searchTerm))
                );
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(c => c.SessionDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<ConsultationSessionNamHh>(items, totalCount);
        }


    }
}
