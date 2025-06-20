using QuitSmoking.Repository.NamHH;
using QuitSmoking.Repository.NamHH.Models;
using QuitSmoking.Repository.NamHH.Pangination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Service.NamHH
{
    public interface IConsultationSessionNamHhService
    {
        Task<List<ConsultationSessionNamHh>> GetAllAsync();
        Task<ConsultationSessionNamHh> GetByIdAsync(int id);
        Task<PaginatedList<ConsultationSessionNamHh>> SearchAsync(
    string memberId, string coachId, int rating, string searchTerm, int pageNumber, int pageSize);
        Task<int> CreateAsync(ConsultationSessionNamHh ConsultationSessionNamHh);
        Task<int> UpdateAsync(ConsultationSessionNamHh ConsultationSessionNamHh);
        Task<bool> RemoveAsync(int id);

        Task<int> SaveChangesAsync();
    }
    public class ConsultationSessionNamHhService : IConsultationSessionNamHhService
    {
        //private readonly ConsultationSessionNamHhRepository _ConsultationSessionNamHhRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ConsultationSessionNamHhService() => _unitOfWork ??= new UnitOfWork();

        public async Task<int> CreateAsync(ConsultationSessionNamHh ConsultationSessionNamHh)
        {
            return await _unitOfWork.ConsultationSessionNamHhRepository.CreateAsync(ConsultationSessionNamHh); // Create a new record
        }

        public async Task<List<ConsultationSessionNamHh>> GetAllAsync()
        {
            return await _unitOfWork.ConsultationSessionNamHhRepository.GetAllAsync(); // Get all records
        }

        public async Task<ConsultationSessionNamHh> GetByIdAsync(int id)
        {
            return await _unitOfWork.ConsultationSessionNamHhRepository.GetByIdAsync(id); // Get a record by ID
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var removedProfile = await _unitOfWork.ConsultationSessionNamHhRepository.GetByIdAsync(id);
            return await _unitOfWork.ConsultationSessionNamHhRepository.RemoveAsync(removedProfile);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.ConsultationSessionNamHhRepository.SaveAsync();
        }

        public async Task<PaginatedList<ConsultationSessionNamHh>> SearchAsync(
    string memberId, string coachId, int rating, string searchTerm, int pageNumber, int pageSize)
        {
            return await _unitOfWork.ConsultationSessionNamHhRepository.SearchAsync(
                memberId, coachId, rating, searchTerm, pageNumber, pageSize
            );
        }

        public async Task<int> UpdateAsync(ConsultationSessionNamHh ConsultationSessionNamHh)
        {
            var updatedProfile = _unitOfWork.ConsultationSessionNamHhRepository.GetByIdAsync(ConsultationSessionNamHh.ConsultationSessionNamHhid);
            return await _unitOfWork.ConsultationSessionNamHhRepository.UpdateAsync(ConsultationSessionNamHh);
        }
    }
}
