using QuitSmoking.Repository.NamHH.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Repository.NamHH
{
    public interface  IUnitOfWork : IDisposable
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        ConsultationSessionNamHhRepository ConsultationSessionNamHhRepository { get; }
        SessionFeedbackNamHHRepository SessionFeedbackNamHHRepository { get; }

        int SaveChangeWithTransaction();

        Task<int> SaveChangeWithTransactionAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SU25_SE18_PRN222_SE1809_G6_QuitSmokingDBContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private ConsultationSessionNamHhRepository _consultationSessionNamHhRepository;
        private SessionFeedbackNamHHRepository _sessionFeedbackNamHHRepository;

        public UnitOfWork() => _context ??= new SU25_SE18_PRN222_SE1809_G6_QuitSmokingDBContext();

        public SystemUserAccountRepository SystemUserAccountRepository 
        {
            get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
        }

        public ConsultationSessionNamHhRepository ConsultationSessionNamHhRepository
        { 
            get { return _consultationSessionNamHhRepository ??= new ConsultationSessionNamHhRepository(_context); }
        }

        public SessionFeedbackNamHHRepository SessionFeedbackNamHHRepository
        { 
            get { return _sessionFeedbackNamHHRepository ??= new SessionFeedbackNamHHRepository(_context); }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChangeWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangeWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
