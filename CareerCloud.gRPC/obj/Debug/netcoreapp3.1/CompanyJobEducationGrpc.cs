// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/CompanyJobEducation.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class CompanyJobEducationService
  {
    static readonly string __ServiceName = "CareerCloud.gRPC.CompanyJobEducationService";

    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJobEducationIdRequest> __Marshaller_CareerCloud_gRPC_CompanyJobEducationIdRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.CompanyJobEducationIdRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJobEducation> __Marshaller_CareerCloud_gRPC_CompanyJobEducation = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.CompanyJobEducation.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJobEducations> __Marshaller_CareerCloud_gRPC_CompanyJobEducations = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.CompanyJobEducations.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationIdRequest, global::CareerCloud.gRPC.Protos.CompanyJobEducation> __Method_GetCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationIdRequest, global::CareerCloud.gRPC.Protos.CompanyJobEducation>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCompanyJobEducation",
        __Marshaller_CareerCloud_gRPC_CompanyJobEducationIdRequest,
        __Marshaller_CareerCloud_gRPC_CompanyJobEducation);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty> __Method_CreateCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateCompanyJobEducation",
        __Marshaller_CareerCloud_gRPC_CompanyJobEducations,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateCompanyJobEducation",
        __Marshaller_CareerCloud_gRPC_CompanyJobEducations,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteCompanyJobEducation",
        __Marshaller_CareerCloud_gRPC_CompanyJobEducations,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.CompanyJobEducationReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CompanyJobEducationService</summary>
    [grpc::BindServiceMethod(typeof(CompanyJobEducationService), "BindService")]
    public abstract partial class CompanyJobEducationServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.CompanyJobEducation> GetCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> CreateCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducations request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducations request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducations request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CompanyJobEducationServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetCompanyJobEducation, serviceImpl.GetCompanyJobEducation)
          .AddMethod(__Method_CreateCompanyJobEducation, serviceImpl.CreateCompanyJobEducation)
          .AddMethod(__Method_UpdateCompanyJobEducation, serviceImpl.UpdateCompanyJobEducation)
          .AddMethod(__Method_DeleteCompanyJobEducation, serviceImpl.DeleteCompanyJobEducation).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CompanyJobEducationServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducationIdRequest, global::CareerCloud.gRPC.Protos.CompanyJobEducation>(serviceImpl.GetCompanyJobEducation));
      serviceBinder.AddMethod(__Method_CreateCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.CreateCompanyJobEducation));
      serviceBinder.AddMethod(__Method_UpdateCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateCompanyJobEducation));
      serviceBinder.AddMethod(__Method_DeleteCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducations, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteCompanyJobEducation));
    }

  }
}
#endregion
