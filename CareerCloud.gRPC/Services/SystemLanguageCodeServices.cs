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
using static CareerCloud.gRPC.Protos.SystemLanguageCodeService;

namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCodeServices: SystemLanguageCodeServiceBase
    {
        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeServices()
        {
            _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
        }

        public override Task<SystemLanguageCode> GetSystemLanguageCode(SystemLanguageCodeIdrequest request, ServerCallContext context)
        {
            var poco = _logic.Get(request.LanguageID);

            if(poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Task.FromResult(new SystemLanguageCode()
            {
                LanguageID = poco.LanguageID,
                Name = poco.Name,
                NativeName = poco.NativeName
            });
        }

        public override Task<Empty> CreateSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            List<SystemLanguageCodePoco> poco = new List<SystemLanguageCodePoco>();
            foreach(var item in request.SLC)
            {
                SystemLanguageCodePoco pocoo = new SystemLanguageCodePoco()
                {
                    LanguageID = item.LanguageID,
                    NativeName = item.NativeName,
                    Name = item.Name
                };

                poco.Add(pocoo);
            }

            _logic.Add(poco.ToArray());
            return Task.FromResult( new Empty());
            
        }

        public override Task<Empty> UpdateSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            List<SystemLanguageCodePoco> poco = new List<SystemLanguageCodePoco>();
            foreach(var item in request.SLC)
            {
                var updatePoco = _logic.Get(item.LanguageID);
                updatePoco.LanguageID = item.LanguageID;
                updatePoco.NativeName = item.NativeName;
                updatePoco.Name = item.Name;
            
                
                poco.Add(updatePoco);
            }

            _logic.Update(poco.ToArray());
            return Task.FromResult(new Empty());
         }

        

        public override Task<Empty> DeleteSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();
            foreach(var item in request.SLC)
            {
               var deletePoco = _logic.Get(item.LanguageID);
                pocos.Add(deletePoco);
            }

            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
    }
}
