using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.ApplicantJobApplicationService;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantJobApplicationServices : ApplicantJobApplicationServiceBase
    {
        private readonly ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationServices()
        {
            _logic = new ApplicantJobApplicationLogic( new EFGenericRepository<ApplicantJobApplicationPoco>());
        }


        public override Task<ApplicantJobApplication> GetApplicantJobApplication(AppJobApplicationIdRequest request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            if(poco is null)
            {
                throw  new ArgumentOutOfRangeException();
            }
            return Task.FromResult(new ApplicantJobApplication
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Job = poco.Job.ToString(),
                ApplicationDate = Timestamp.FromDateTime(poco.ApplicationDate)
            });
        }
        public override Task<Empty> CreateApplicantJobApplication(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();

            foreach(var item in request.AppJob)

            {
                ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco()
                {

                    Id = Guid.Parse(item.Id),
                    Applicant = Guid.Parse(item.Applicant),
                    Job = Guid.Parse(item.Job),
                    ApplicationDate = item.ApplicationDate.ToDateTime()
                };

                pocos.Add(poco);

            }

            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateApplicantJobApplication(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();
            
            foreach (var item in request.AppJob)
            {
                   var pocoUpdated = _logic.Get(Guid.Parse(item.Id));
                   pocoUpdated.Applicant = Guid.Parse(item.Applicant);
                   pocoUpdated.Job = Guid.Parse(item.Job);
                   pocoUpdated.ApplicationDate = item.ApplicationDate.ToDateTime();
                
                pocos.Add(pocoUpdated);

            }

            _logic.Update(pocos.ToArray());
            return  Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteApplicantJobApplication(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();

            foreach(var item in request.AppJob)
            {
                var pocoToDelete = _logic.Get(Guid.Parse(item.Id));
                pocos.Add(pocoToDelete);
            }

            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
            //ApplicantJobApplicationPoco poco = _logic.Get(Guid.Parse(request.Id));
            //_logic.Delete(new ApplicantJobApplicationPoco[] { poco });
            //return new Task<Empty>(() => new Empty());
        }
    }
}
