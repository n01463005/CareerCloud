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
using static CareerCloud.gRPC.Protos.ApplicantEducationService;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantEducationServices : ApplicantEducationServiceBase
    {
        private readonly ApplicantEducationLogic _logic;
        public ApplicantEducationServices()
        {
            _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>());
        }
        public override Task<ApplicantEducation> GetApplicantEducation(IdRequest request, ServerCallContext context)
        {
          var poco = _logic.Get(Guid.Parse(request.Id));

            if (poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Task.FromResult(new ApplicantEducation
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Major = poco.Major.ToString(),
                CertificateDiploma = poco.CertificateDiploma.ToString(),
                StartDate = poco.StartDate is null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind(poco.StartDate.GetValueOrDefault(), DateTimeKind.Utc)),
                CompletionDate = poco.CompletionDate is null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind(poco.CompletionDate.GetValueOrDefault(), DateTimeKind.Utc)),
                CompletionPercent = (int)poco.CompletionPercent
            });
        }

        public override Task<Empty> CreateApplicantEducation(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();

            foreach (var item in request.AppEdu)
            {
                ApplicantEducationPoco poco = new ApplicantEducationPoco()
                {
                    Id = Guid.Parse(item.Id),
                    Applicant = Guid.Parse(item.Applicant),
                    Major = item.Major,
                    CertificateDiploma = item.CertificateDiploma,
                    StartDate = item.StartDate.ToDateTime(),
                    CompletionDate = item.CompletionDate.ToDateTime(),
                    CompletionPercent = (byte?)item.CompletionPercent
                };

                pocos.Add(poco);
            }

            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
         

        public override Task<Empty>UpdateApplicantEducation(ApplicantEducations request , ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();
            foreach (var item in request.AppEdu)
            {
                var pocoSaved = _logic.Get(Guid.Parse(item.Id));
                    pocoSaved.Id = Guid.Parse(item.Id);
                    pocoSaved.Major = item.Major;
                    pocoSaved.CertificateDiploma = item.CertificateDiploma;
                    pocoSaved.StartDate = item.StartDate.ToDateTime();
                    pocoSaved.CompletionDate = item.CompletionDate.ToDateTime();
                    pocoSaved.CompletionPercent = (byte?)item.CompletionPercent;

                pocos.Add(pocoSaved);
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteApplicantEducation(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();
            foreach (var item in request.AppEdu)
            {
                var pocoSaved = _logic.Get(Guid.Parse(item.Id));
                pocos.Add(pocoSaved);
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
       
    } 
}

