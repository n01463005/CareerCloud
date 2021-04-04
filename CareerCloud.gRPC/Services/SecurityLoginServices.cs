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
using static CareerCloud.gRPC.Protos.SecurityLoginService;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginServices: SecurityLoginServiceBase
    {
        private readonly SecurityLoginLogic _logic;
        public SecurityLoginServices()
        {
            _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
        }

        public override Task<SecurityLogin> GetSecurityLogin(SecurityLoginIdRequest request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            if(poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }

               return Task.FromResult(new SecurityLogin
            {
                Id = poco.Id.ToString(),
                Login = poco.Login,
                Password = poco.Password,
                Created = Timestamp.FromDateTime(poco.Created),
                PasswordUpdate = poco.PasswordUpdate is null ? null : Timestamp.FromDateTime((DateTime)poco.PasswordUpdate),
                AgreementAccepted = poco.AgreementAccepted is null ? null : Timestamp.FromDateTime((DateTime)poco.AgreementAccepted),
                IsLocked = poco.IsLocked,
                IsInactive = poco.IsInactive,
                EmailAddress = poco.EmailAddress,
                PhoneNumber = poco.PhoneNumber,
                FullName = poco.FullName,
                PrefferredLanguage = poco.PrefferredLanguage,
                ForceChangePassword = poco.ForceChangePassword

            });
        }

        public override Task<Empty> CreateSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();

            foreach(var item in request.SL)
            {
                SecurityLoginPoco poco = new SecurityLoginPoco()
                {
                    Id = Guid.Parse(item.Id),
                    Login = item.Login,
                    Password = item.Password,
                    Created = item.Created.ToDateTime(),
                    PasswordUpdate = item.PasswordUpdate.ToDateTime(),
                    AgreementAccepted = item.AgreementAccepted.ToDateTime(),
                    IsLocked = item.IsLocked,
                    IsInactive = item.IsInactive,
                    EmailAddress = item.EmailAddress,
                    PhoneNumber = item.PhoneNumber,
                    FullName = item.FullName,
                    PrefferredLanguage = item.PrefferredLanguage,
                    ForceChangePassword = item.ForceChangePassword
                };

                pocos.Add(poco);
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> poco = new List<SecurityLoginPoco>();
            foreach(var item in request.SL)
            {
                var updatedPoco = _logic.Get(Guid.Parse(item.Id));
                updatedPoco.Login = item.Login;
                updatedPoco.Password = item.Password;
                updatedPoco.Created = item.Created.ToDateTime();
                updatedPoco.PasswordUpdate = item.PasswordUpdate.ToDateTime();
                updatedPoco.AgreementAccepted = item.AgreementAccepted.ToDateTime();
                updatedPoco.IsLocked = item.IsLocked;
                updatedPoco.IsInactive = item.IsInactive;
                updatedPoco.EmailAddress = item.EmailAddress;
                updatedPoco.PhoneNumber = item.PhoneNumber;
                updatedPoco.FullName = item.FullName;
                updatedPoco.PrefferredLanguage = item.PrefferredLanguage;
                updatedPoco.ForceChangePassword = item.ForceChangePassword;


                poco.Add(updatedPoco);
            }
            _logic.Update(poco.ToArray());
            return Task.FromResult(new Empty());
        
        }

           

        public override Task<Empty> DeleteSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();
            foreach(var item in request.SL)
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
 string Id = 1;                                              
    string Login =  2;
    string Password = 3;
    google.protobuf.Timestamp Created = 4;
    google.protobuf.Timestamp PasswordUpdate = 5;
    google.protobuf.Timestamp AgreementAccepted = 6;
 bool IsLocked = 7;
    bool IsInactive = 8;
    string EmailAddress = 9;
    string PhoneNumber = 10;
    string FullName = 11;
    string PrefferredLanguage = 12;
    bool ForceChangePassword = 13;
   
 */