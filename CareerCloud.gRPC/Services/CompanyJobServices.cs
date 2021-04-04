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
using static CareerCloud.gRPC.Protos.CompanyJobService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobServices : CompanyJobServiceBase
    {
        private readonly CompanyJobLogic _logic;
        public CompanyJobServices()
        {
            _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
        }

        public override Task<CompanyJob> GetCompanyJob(CompanyJobIdrequest request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));

            if(poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Task.FromResult(new CompanyJob
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                IsCompanyHidden = poco.IsCompanyHidden,
                IsInactive = poco.IsInactive,
                ProfileCreated = Timestamp.FromDateTime(poco.ProfileCreated)
            
            });
        }

        public override Task<Empty> CreateCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();

            foreach (var item in request.Cj)
            {
                CompanyJobPoco poco = new CompanyJobPoco()
                {
                    Id = Guid.Parse(item.Id),
                    Company = Guid.Parse(item.Company),
                    IsCompanyHidden = item.IsCompanyHidden,
                    IsInactive = item.IsInactive,
                    ProfileCreated = item.ProfileCreated.ToDateTime()


                };
                pocos.Add(poco);
            }

            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> UpdateCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            List<CompanyJobPoco> poco = new List<CompanyJobPoco>();

            foreach(var item in request.Cj)
            {
                var pocoToUpdate = _logic.Get(Guid.Parse(item.Id));
                pocoToUpdate.Company = Guid.Parse(item.Company);
                pocoToUpdate.IsCompanyHidden = item.IsCompanyHidden;
                pocoToUpdate.IsInactive = item.IsInactive;
                pocoToUpdate.ProfileCreated = item.ProfileCreated.ToDateTime();
           
                poco.Add(pocoToUpdate);
            }

            _logic.Update(poco.ToArray());

            return Task.FromResult(new Empty());        }

        public override Task<Empty> DeleteCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            List<CompanyJobPoco> poco = new List<CompanyJobPoco>();
            foreach (var item in request.Cj)
            {
                var pocoDelete = _logic.Get(Guid.Parse(item.Id));

                poco.Add(pocoDelete);
            }
            _logic.Delete(poco.ToArray());

            return Task.FromResult(new Empty());
        }
    }
}
