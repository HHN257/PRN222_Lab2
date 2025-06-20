using QuitSmoking.Repository.NamHH;
using QuitSmoking.Repository.NamHH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Service.NamHH
{
    public interface ISessionFeedbackNamHHService
    {
        Task<List<SessionFeedbackNamHh>> GetAllAsync();
    }
    public class SessionFeedbackNamHHService : ISessionFeedbackNamHHService
    {
        private readonly SessionFeedbackNamHHRepository _sessionFeedbackNamHHRepository;
        public async Task<List<SessionFeedbackNamHh>> GetAllAsync()
        {
            return await _sessionFeedbackNamHHRepository.GetAllAsync();
        }
    }
}
