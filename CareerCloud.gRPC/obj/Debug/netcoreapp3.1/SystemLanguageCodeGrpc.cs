// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/SystemLanguageCode.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class SystemLanguageCodeService
  {
    static readonly string __ServiceName = "CareerCloud.gRPC.SystemLanguageCodeService";

    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SystemLanguageCodeIdrequest> __Marshaller_CareerCloud_gRPC_SystemLanguageCodeIdrequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.SystemLanguageCodeIdrequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SystemLanguageCode> __Marshaller_CareerCloud_gRPC_SystemLanguageCode = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.SystemLanguageCode.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SystemLanguageCodes> __Marshaller_CareerCloud_gRPC_SystemLanguageCodes = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CareerCloud.gRPC.Protos.SystemLanguageCodes.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodeIdrequest, global::CareerCloud.gRPC.Protos.SystemLanguageCode> __Method_GetSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodeIdrequest, global::CareerCloud.gRPC.Protos.SystemLanguageCode>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_SystemLanguageCodeIdrequest,
        __Marshaller_CareerCloud_gRPC_SystemLanguageCode);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty> __Method_CreateSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_SystemLanguageCodes,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_SystemLanguageCodes,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_SystemLanguageCodes,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.SystemLanguageCodeReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SystemLanguageCodeService</summary>
    [grpc::BindServiceMethod(typeof(SystemLanguageCodeService), "BindService")]
    public abstract partial class SystemLanguageCodeServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.SystemLanguageCode> GetSystemLanguageCode(global::CareerCloud.gRPC.Protos.SystemLanguageCodeIdrequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> CreateSystemLanguageCode(global::CareerCloud.gRPC.Protos.SystemLanguageCodes request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSystemLanguageCode(global::CareerCloud.gRPC.Protos.SystemLanguageCodes request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSystemLanguageCode(global::CareerCloud.gRPC.Protos.SystemLanguageCodes request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SystemLanguageCodeServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetSystemLanguageCode, serviceImpl.GetSystemLanguageCode)
          .AddMethod(__Method_CreateSystemLanguageCode, serviceImpl.CreateSystemLanguageCode)
          .AddMethod(__Method_UpdateSystemLanguageCode, serviceImpl.UpdateSystemLanguageCode)
          .AddMethod(__Method_DeleteSystemLanguageCode, serviceImpl.DeleteSystemLanguageCode).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SystemLanguageCodeServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SystemLanguageCodeIdrequest, global::CareerCloud.gRPC.Protos.SystemLanguageCode>(serviceImpl.GetSystemLanguageCode));
      serviceBinder.AddMethod(__Method_CreateSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.CreateSystemLanguageCode));
      serviceBinder.AddMethod(__Method_UpdateSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateSystemLanguageCode));
      serviceBinder.AddMethod(__Method_DeleteSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteSystemLanguageCode));
    }

  }
}
#endregion