// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/CompanyDescription.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CareerCloud.gRPC.Protos {

  /// <summary>Holder for reflection information generated from Protos/CompanyDescription.proto</summary>
  public static partial class CompanyDescriptionReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/CompanyDescription.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CompanyDescriptionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch9Qcm90b3MvQ29tcGFueURlc2NyaXB0aW9uLnByb3RvEhBDYXJlZXJDbG91",
            "ZC5nUlBDGhtnb29nbGUvcHJvdG9idWYvZW1wdHkucHJvdG8iKQobQ29tcGFu",
            "eURlc2NyaWJ0aW9uSWRSZXF1ZXN0EgoKAklkGAEgASgJInYKEkNvbXBhbnlE",
            "ZXNjcmlwdGlvbhIKCgJJZBgBIAEoCRIPCgdDb21wYW55GAIgASgJEhIKCkxh",
            "bmd1YWdlSWQYAyABKAkSEwoLQ29tcGFueU5hbWUYBCABKAkSGgoSQ29tcGFu",
            "eURlc2NyaXB0aW9uGAUgASgJIksKE0NvbXBhbnlEZXNjcmlwdGlvbnMSNAoG",
            "Q29tRGVzGAEgAygLMiQuQ2FyZWVyQ2xvdWQuZ1JQQy5Db21wYW55RGVzY3Jp",
            "cHRpb24ymgMKGUNvbXBhbnlEZXNjcmlwdGlvblNlcnZpY2USbAoVR2V0Q29t",
            "cGFueURlc2NyaXB0aW9uEi0uQ2FyZWVyQ2xvdWQuZ1JQQy5Db21wYW55RGVz",
            "Y3JpYnRpb25JZFJlcXVlc3QaJC5DYXJlZXJDbG91ZC5nUlBDLkNvbXBhbnlE",
            "ZXNjcmlwdGlvbhJZChhDcmVhdGVDb21wYW55RGVzY3JpcHRpb24SJS5DYXJl",
            "ZXJDbG91ZC5nUlBDLkNvbXBhbnlEZXNjcmlwdGlvbnMaFi5nb29nbGUucHJv",
            "dG9idWYuRW1wdHkSWQoYVXBkYXRlQ29tcGFueURlc2NyaXB0aW9uEiUuQ2Fy",
            "ZWVyQ2xvdWQuZ1JQQy5Db21wYW55RGVzY3JpcHRpb25zGhYuZ29vZ2xlLnBy",
            "b3RvYnVmLkVtcHR5ElkKGERlbGV0ZUNvbXBhbnlEZXNjcmlwdGlvbhIlLkNh",
            "cmVlckNsb3VkLmdSUEMuQ29tcGFueURlc2NyaXB0aW9ucxoWLmdvb2dsZS5w",
            "cm90b2J1Zi5FbXB0eUIaqgIXQ2FyZWVyQ2xvdWQuZ1JQQy5Qcm90b3NiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.CompanyDescribtionIdRequest), global::CareerCloud.gRPC.Protos.CompanyDescribtionIdRequest.Parser, new[]{ "Id" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.CompanyDescription), global::CareerCloud.gRPC.Protos.CompanyDescription.Parser, new[]{ "Id", "Company", "LanguageId", "CompanyName", "CompanyDescription_" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.CompanyDescriptions), global::CareerCloud.gRPC.Protos.CompanyDescriptions.Parser, new[]{ "ComDes" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class CompanyDescribtionIdRequest : pb::IMessage<CompanyDescribtionIdRequest> {
    private static readonly pb::MessageParser<CompanyDescribtionIdRequest> _parser = new pb::MessageParser<CompanyDescribtionIdRequest>(() => new CompanyDescribtionIdRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CompanyDescribtionIdRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.CompanyDescriptionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescribtionIdRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescribtionIdRequest(CompanyDescribtionIdRequest other) : this() {
      id_ = other.id_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescribtionIdRequest Clone() {
      return new CompanyDescribtionIdRequest(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CompanyDescribtionIdRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CompanyDescribtionIdRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CompanyDescribtionIdRequest other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CompanyDescription : pb::IMessage<CompanyDescription> {
    private static readonly pb::MessageParser<CompanyDescription> _parser = new pb::MessageParser<CompanyDescription>(() => new CompanyDescription());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CompanyDescription> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.CompanyDescriptionReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescription() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescription(CompanyDescription other) : this() {
      id_ = other.id_;
      company_ = other.company_;
      languageId_ = other.languageId_;
      companyName_ = other.companyName_;
      companyDescription_ = other.companyDescription_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescription Clone() {
      return new CompanyDescription(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Company" field.</summary>
    public const int CompanyFieldNumber = 2;
    private string company_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Company {
      get { return company_; }
      set {
        company_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "LanguageId" field.</summary>
    public const int LanguageIdFieldNumber = 3;
    private string languageId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string LanguageId {
      get { return languageId_; }
      set {
        languageId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CompanyName" field.</summary>
    public const int CompanyNameFieldNumber = 4;
    private string companyName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CompanyName {
      get { return companyName_; }
      set {
        companyName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CompanyDescription" field.</summary>
    public const int CompanyDescription_FieldNumber = 5;
    private string companyDescription_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CompanyDescription_ {
      get { return companyDescription_; }
      set {
        companyDescription_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CompanyDescription);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CompanyDescription other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Company != other.Company) return false;
      if (LanguageId != other.LanguageId) return false;
      if (CompanyName != other.CompanyName) return false;
      if (CompanyDescription_ != other.CompanyDescription_) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Company.Length != 0) hash ^= Company.GetHashCode();
      if (LanguageId.Length != 0) hash ^= LanguageId.GetHashCode();
      if (CompanyName.Length != 0) hash ^= CompanyName.GetHashCode();
      if (CompanyDescription_.Length != 0) hash ^= CompanyDescription_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Company.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Company);
      }
      if (LanguageId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(LanguageId);
      }
      if (CompanyName.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(CompanyName);
      }
      if (CompanyDescription_.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(CompanyDescription_);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Company.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Company);
      }
      if (LanguageId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LanguageId);
      }
      if (CompanyName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CompanyName);
      }
      if (CompanyDescription_.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CompanyDescription_);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CompanyDescription other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Company.Length != 0) {
        Company = other.Company;
      }
      if (other.LanguageId.Length != 0) {
        LanguageId = other.LanguageId;
      }
      if (other.CompanyName.Length != 0) {
        CompanyName = other.CompanyName;
      }
      if (other.CompanyDescription_.Length != 0) {
        CompanyDescription_ = other.CompanyDescription_;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Company = input.ReadString();
            break;
          }
          case 26: {
            LanguageId = input.ReadString();
            break;
          }
          case 34: {
            CompanyName = input.ReadString();
            break;
          }
          case 42: {
            CompanyDescription_ = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CompanyDescriptions : pb::IMessage<CompanyDescriptions> {
    private static readonly pb::MessageParser<CompanyDescriptions> _parser = new pb::MessageParser<CompanyDescriptions>(() => new CompanyDescriptions());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CompanyDescriptions> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.CompanyDescriptionReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescriptions() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescriptions(CompanyDescriptions other) : this() {
      comDes_ = other.comDes_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CompanyDescriptions Clone() {
      return new CompanyDescriptions(this);
    }

    /// <summary>Field number for the "ComDes" field.</summary>
    public const int ComDesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::CareerCloud.gRPC.Protos.CompanyDescription> _repeated_comDes_codec
        = pb::FieldCodec.ForMessage(10, global::CareerCloud.gRPC.Protos.CompanyDescription.Parser);
    private readonly pbc::RepeatedField<global::CareerCloud.gRPC.Protos.CompanyDescription> comDes_ = new pbc::RepeatedField<global::CareerCloud.gRPC.Protos.CompanyDescription>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CareerCloud.gRPC.Protos.CompanyDescription> ComDes {
      get { return comDes_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CompanyDescriptions);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CompanyDescriptions other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!comDes_.Equals(other.comDes_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= comDes_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      comDes_.WriteTo(output, _repeated_comDes_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += comDes_.CalculateSize(_repeated_comDes_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CompanyDescriptions other) {
      if (other == null) {
        return;
      }
      comDes_.Add(other.comDes_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            comDes_.AddEntriesFrom(input, _repeated_comDes_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
