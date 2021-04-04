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
using static CareerCloud.gRPC.Protos.CompanyDescriptionService;
using static CareerCloud.gRPC.Protos.CompanyJobEducationService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobEducationServices: CompanyJobEducationServiceBase
    {
        private readonly CompanyJobEducationLogic _logic;
        public CompanyJobEducationServices()
        {
            _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        }

        public override Task<CompanyJobEducation> GetCompanyJobEducation(CompanyJobEducationIdRequest request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));

            if(poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Task.FromResult(new CompanyJobEducation()
            {
                Id = poco.Id.ToString(),
                Job = poco.Job.ToString(),
                Importance = poco.Importance,
                Major = poco.Major
            });
        }

        public override Task<Empty> CreateCompanyJobEducation(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = new List<CompanyJobEducationPoco>();

            foreach(var item in request.ComJE)
            {
                CompanyJobEducationPoco poco = new CompanyJobEducationPoco()
                {
                    Id = Guid.Parse(item.Id),
                    Job = Guid.Parse(item.Job),
                    Importance = (short)item.Importance,
                    Major = item.Major
                };

                pocos.Add(poco);
            }
           
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCompanyJobEducation(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> poco = new List<CompanyJobEducationPoco>();

            foreach(var item in request.ComJE)
            {
                var pocoToUpdate = _logic.Get(Guid.Parse(item.Id));
                pocoToUpdate.Job = Guid.Parse(item.Job);
                pocoToUpdate.Importance = (short)item.Importance;
                pocoToUpdate.Major = item.Major;
            
                    poco.Add(pocoToUpdate);
            }

            _logic.Update(poco.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCompanyJobEducation(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> poco = new List<CompanyJobEducationPoco>();

            foreach(var item in request.ComJE)
            {
                var pocoDelete = _logic.Get(Guid.Parse(item.Id));
                poco.Add(pocoDelete);
            }

            _logic.Delete(poco.ToArray());
            return Task.FromResult(new Empty());
        }

    }
}

