// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/ApplicantEducation.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class ApplicantEducationService
  {
    static readonly string __ServiceName = "CareerCloud.gRPC.ApplicantEducationService";

    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.IdRequest> __Marshaller_CareerCloud_gRPC_IdRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.IdRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.ApplicantEducation> __Marshaller_CareerCloud_gRPC_ApplicantEducation = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.ApplicantEducation.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.ApplicantEducations> __Marshaller_CareerCloud_gRPC_ApplicantEducations = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.ApplicantEducations.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.IdRequest, global::CareerCloud.gRPC.Protos.ApplicantEducation> __Method_GetApplicantEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.IdRequest, global::CareerCloud.gRPC.Protos.ApplicantEducation>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetApplicantEducation",
        __Marshaller_CareerCloud_gRPC_IdRequest,
        __Marshaller_CareerCloud_gRPC_ApplicantEducation);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty> __Method_CreateApplicantEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateApplicantEducation",
        __Marshaller_CareerCloud_gRPC_ApplicantEducations,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateApplicantEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateApplicantEducation",
        __Marshaller_CareerCloud_gRPC_ApplicantEducations,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteApplicantEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteApplicantEducation",
        __Marshaller_CareerCloud_gRPC_ApplicantEducations,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.ApplicantEducationReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ApplicantEducationService</summary>
    [grpc::BindServiceMethod(typeof(ApplicantEducationService), "BindService")]
    public abstract partial class ApplicantEducationServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.ApplicantEducation> GetApplicantEducation(global::CareerCloud.gRPC.Protos.IdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> CreateApplicantEducation(global::CareerCloud.gRPC.Protos.ApplicantEducations request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateApplicantEducation(global::CareerCloud.gRPC.Protos.ApplicantEducations request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteApplicantEducation(global::CareerCloud.gRPC.Protos.ApplicantEducations request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ApplicantEducationServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetApplicantEducation, serviceImpl.GetApplicantEducation)
          .AddMethod(__Method_CreateApplicantEducation, serviceImpl.CreateApplicantEducation)
          .AddMethod(__Method_UpdateApplicantEducation, serviceImpl.UpdateApplicantEducation)
          .AddMethod(__Method_DeleteApplicantEducation, serviceImpl.DeleteApplicantEducation).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ApplicantEducationServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetApplicantEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.IdRequest, global::CareerCloud.gRPC.Protos.ApplicantEducation>(serviceImpl.GetApplicantEducation));
      serviceBinder.AddMethod(__Method_CreateApplicantEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.CreateApplicantEducation));
      serviceBinder.AddMethod(__Method_UpdateApplicantEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateApplicantEducation));
      serviceBinder.AddMethod(__Method_DeleteApplicantEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.ApplicantEducations, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteApplicantEducation));
    }

  }
}
#endregion