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
using static CareerCloud.gRPC.Protos.SecurityLoginLogService;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginsLogServices: SecurityLoginLogServiceBase
    {
        private readonly SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogServices()
        {
            _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
        }

        public override Task<SecurityLoginLog> GetSecurityLoginLog(SecurityLoginLogIdrequest request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));

            if(poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return  Task.FromResult( new SecurityLoginLog()
            {
                Id = poco.Id.ToString(),
                Login = poco.Login.ToString(),
                SourceIP = poco.SourceIP,
                LogonDate = Timestamp.FromDateTime(poco.LogonDate),
                IsSuccesful = poco.IsSuccesful
            });

            
        }

        public override Task<Empty> CreateSecurityLoginLog(SecurityLoginLogs request, ServerCallContext context)
        {

            List<SecurityLoginsLogPoco> poco = new List<SecurityLoginsLogPoco>();

            foreach (var item in request.SLL)
            {
                SecurityLoginsLogPoco pocoo = new SecurityLoginsLogPoco()
                {
                    Id = Guid.Parse(item.Id),
                    Login = Guid.Parse(item.Login),
                    SourceIP = item.SourceIP,
                    LogonDate = item.LogonDate.ToDateTime(),
                    IsSuccesful = item.IsSuccesful


                };
                poco.Add(pocoo);
            }
            _logic.Add(poco.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSecurityLoginLog(SecurityLoginLogs request, ServerCallContext context)
        {
            List<SecurityLoginsLogPoco> poco = new List<SecurityLoginsLogPoco>();
            foreach(var item in request.SLL)
            {
                var pocoUpdate = _logic.Get(Guid.Parse(item.Id));
                pocoUpdate.Id = Guid.Parse(item.Id);
                pocoUpdate.Login = Guid.Parse(item.Login);
                pocoUpdate.SourceIP = item.SourceIP;
                pocoUpdate.LogonDate = item.LogonDate.ToDateTime();
                pocoUpdate.IsSuccesful = item.IsSuccesful;

                poco.Add(pocoUpdate);

            } 

            _logic.Update(poco.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSecurityLoginLog(SecurityLoginLogs request, ServerCallContext context)
        {

            List<SecurityLoginsLogPoco> pocos = new List<SecurityLoginsLogPoco>();
            foreach(var item in request.SLL)
            {
              var deletePoco = _logic.Get(Guid.Parse(item.Id));
                pocos.Add(deletePoco);
            }

            _logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());

        }
    }
}
