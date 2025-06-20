using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Service.NamHH
{
    public interface IServiceProviders
    {
        ConsultationSessionNamHhService GetConsultationSessionNamHhService { get; }
        SessionFeedbackNamHHService GetSessionFeedbackNamHhService { get; }
        SystemUserAccountService GetSystemUserAccountService { get; }

        IConsultationSessionNamHhService GetConsultationSessionNamHhServiceInterface { get; }
        ISessionFeedbackNamHHService GetSessionFeedbackNamHhServiceInterface { get; }
        ISystemUserAccountService GetSystemUserAccountServiceInterface { get; }
    }
    public class ServiceProviders : IServiceProviders
    {
        private ConsultationSessionNamHhService _consultationSessionNamHhService;
        private SessionFeedbackNamHHService _sessionFeedbackNamHhService;
        private SystemUserAccountService _systemUserAccountService;

        public ConsultationSessionNamHhService GetConsultationSessionNamHhService
        {
            get { return _consultationSessionNamHhService ??= new ConsultationSessionNamHhService(); }
        }

        public SessionFeedbackNamHHService GetSessionFeedbackNamHhService
        {
            get { return _sessionFeedbackNamHhService ??= new SessionFeedbackNamHHService(); }
        }

        public SystemUserAccountService GetSystemUserAccountService
        { 
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }

        public IConsultationSessionNamHhService GetConsultationSessionNamHhServiceInterface
        { 
            get { return GetConsultationSessionNamHhService; }
        }

        public ISessionFeedbackNamHHService GetSessionFeedbackNamHhServiceInterface => throw new NotImplementedException();

        public ISystemUserAccountService GetSystemUserAccountServiceInterface => throw new NotImplementedException();
    }
}
