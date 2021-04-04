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

namespace CareerCloud.gRPC.Services
{
    public class CompanyDescriptionServices:CompanyDescriptionServiceBase
    {
        private readonly CompanyDescriptionLogic _logic;
        public CompanyDescriptionServices()
        {
            _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
        }

        public override Task<CompanyDescription> GetCompanyDescription(CompanyDescribtionIdRequest request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));

            if(poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return  Task.FromResult( new CompanyDescription()
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                CompanyName = poco.CompanyName,
                LanguageId = poco.LanguageId,
                CompanyDescription_ = poco.CompanyDescription
                
            }) ;
        }

        public override Task<Empty> CreateCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();

            foreach(var item in request.ComDes)
            {
                CompanyDescriptionPoco poco = new CompanyDescriptionPoco()
                {

                    Id = Guid.Parse(item.Id),
                    Company = Guid.Parse(item.Company),
                    LanguageId = item.LanguageId,
                    CompanyDescription = item.CompanyDescription_,
                    CompanyName = item.CompanyName
                };
            
                pocos.Add(poco);
            }

            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());       
         }

        public override Task<Empty> UpdateCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> poco = new List<CompanyDescriptionPoco>();

            foreach (var item in request.ComDes)
            {
                var pocoToUpdate = _logic.Get(Guid.Parse(item.Id));
                pocoToUpdate.Company = Guid.Parse(item.Company);
                pocoToUpdate.LanguageId = item.LanguageId;
                pocoToUpdate.CompanyDescription = item.CompanyDescription_;
                pocoToUpdate.CompanyName = item.CompanyName;
           
                poco.Add(pocoToUpdate);
            }

            _logic.Update(poco.ToArray());
            return Task.FromResult(new Empty());

         }
        

        public override Task<Empty> DeleteCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();
            foreach(var item in request.ComDes)
            {
                var Deletepoco = _logic.Get(Guid.Parse(item.Id));
                pocos.Add(Deletepoco);
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
    }
}
/*
  Id = 1;
    string Company = 2;
    string LanguageId = 3;
    string CompanyName = 4;
    string CompanyDescription = 5;
*/