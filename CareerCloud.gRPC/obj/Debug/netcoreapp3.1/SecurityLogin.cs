// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/SecurityLogin.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CareerCloud.gRPC.Protos {

  /// <summary>Holder for reflection information generated from Protos/SecurityLogin.proto</summary>
  public static partial class SecurityLoginReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/SecurityLogin.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SecurityLoginReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChpQcm90b3MvU2VjdXJpdHlMb2dpbi5wcm90bxIQQ2FyZWVyQ2xvdWQuZ1JQ",
            "QxobZ29vZ2xlL3Byb3RvYnVmL2VtcHR5LnByb3RvGh9nb29nbGUvcHJvdG9i",
            "dWYvdGltZXN0YW1wLnByb3RvIiQKFlNlY3VyaXR5TG9naW5JZFJlcXVlc3QS",
            "CgoCSWQYASABKAki8AIKDVNlY3VyaXR5TG9naW4SCgoCSWQYASABKAkSDQoF",
            "TG9naW4YAiABKAkSEAoIUGFzc3dvcmQYAyABKAkSKwoHQ3JlYXRlZBgEIAEo",
            "CzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3RhbXASMgoOUGFzc3dvcmRVcGRh",
            "dGUYBSABKAsyGi5nb29nbGUucHJvdG9idWYuVGltZXN0YW1wEjUKEUFncmVl",
            "bWVudEFjY2VwdGVkGAYgASgLMhouZ29vZ2xlLnByb3RvYnVmLlRpbWVzdGFt",
            "cBIQCghJc0xvY2tlZBgHIAEoCBISCgpJc0luYWN0aXZlGAggASgIEhQKDEVt",
            "YWlsQWRkcmVzcxgJIAEoCRITCgtQaG9uZU51bWJlchgKIAEoCRIQCghGdWxs",
            "TmFtZRgLIAEoCRIaChJQcmVmZmVycmVkTGFuZ3VhZ2UYDCABKAkSGwoTRm9y",
            "Y2VDaGFuZ2VQYXNzd29yZBgNIAEoCCI9Cg5TZWN1cml0eUxvZ2lucxIrCgJT",
            "TBgBIAMoCzIfLkNhcmVlckNsb3VkLmdSUEMuU2VjdXJpdHlMb2dpbjLoAgoU",
            "U2VjdXJpdHlMb2dpblNlcnZpY2USXQoQR2V0U2VjdXJpdHlMb2dpbhIoLkNh",
            "cmVlckNsb3VkLmdSUEMuU2VjdXJpdHlMb2dpbklkUmVxdWVzdBofLkNhcmVl",
            "ckNsb3VkLmdSUEMuU2VjdXJpdHlMb2dpbhJPChNDcmVhdGVTZWN1cml0eUxv",
            "Z2luEiAuQ2FyZWVyQ2xvdWQuZ1JQQy5TZWN1cml0eUxvZ2lucxoWLmdvb2ds",
            "ZS5wcm90b2J1Zi5FbXB0eRJPChNVcGRhdGVTZWN1cml0eUxvZ2luEiAuQ2Fy",
            "ZWVyQ2xvdWQuZ1JQQy5TZWN1cml0eUxvZ2lucxoWLmdvb2dsZS5wcm90b2J1",
            "Zi5FbXB0eRJPChNEZWxldGVTZWN1cml0eUxvZ2luEiAuQ2FyZWVyQ2xvdWQu",
            "Z1JQQy5TZWN1cml0eUxvZ2lucxoWLmdvb2dsZS5wcm90b2J1Zi5FbXB0eUIa",
            "qgIXQ2FyZWVyQ2xvdWQuZ1JQQy5Qcm90b3NiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.SecurityLoginIdRequest), global::CareerCloud.gRPC.Protos.SecurityLoginIdRequest.Parser, new[]{ "Id" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.SecurityLogin), global::CareerCloud.gRPC.Protos.SecurityLogin.Parser, new[]{ "Id", "Login", "Password", "Created", "PasswordUpdate", "AgreementAccepted", "IsLocked", "IsInactive", "EmailAddress", "PhoneNumber", "FullName", "PrefferredLanguage", "ForceChangePassword" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.SecurityLogins), global::CareerCloud.gRPC.Protos.SecurityLogins.Parser, new[]{ "SL" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SecurityLoginIdRequest : pb::IMessage<SecurityLoginIdRequest> {
    private static readonly pb::MessageParser<SecurityLoginIdRequest> _parser = new pb::MessageParser<SecurityLoginIdRequest>(() => new SecurityLoginIdRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SecurityLoginIdRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.SecurityLoginReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLoginIdRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLoginIdRequest(SecurityLoginIdRequest other) : this() {
      id_ = other.id_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLoginIdRequest Clone() {
      return new SecurityLoginIdRequest(this);
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
      return Equals(other as SecurityLoginIdRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SecurityLoginIdRequest other) {
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
    public void MergeFrom(SecurityLoginIdRequest other) {
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

  public sealed partial class SecurityLogin : pb::IMessage<SecurityLogin> {
    private static readonly pb::MessageParser<SecurityLogin> _parser = new pb::MessageParser<SecurityLogin>(() => new SecurityLogin());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SecurityLogin> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.SecurityLoginReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLogin() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLogin(SecurityLogin other) : this() {
      id_ = other.id_;
      login_ = other.login_;
      password_ = other.password_;
      created_ = other.created_ != null ? other.created_.Clone() : null;
      passwordUpdate_ = other.passwordUpdate_ != null ? other.passwordUpdate_.Clone() : null;
      agreementAccepted_ = other.agreementAccepted_ != null ? other.agreementAccepted_.Clone() : null;
      isLocked_ = other.isLocked_;
      isInactive_ = other.isInactive_;
      emailAddress_ = other.emailAddress_;
      phoneNumber_ = other.phoneNumber_;
      fullName_ = other.fullName_;
      prefferredLanguage_ = other.prefferredLanguage_;
      forceChangePassword_ = other.forceChangePassword_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLogin Clone() {
      return new SecurityLogin(this);
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

    /// <summary>Field number for the "Login" field.</summary>
    public const int LoginFieldNumber = 2;
    private string login_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Login {
      get { return login_; }
      set {
        login_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Password" field.</summary>
    public const int PasswordFieldNumber = 3;
    private string password_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Created" field.</summary>
    public const int CreatedFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Timestamp created_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Created {
      get { return created_; }
      set {
        created_ = value;
      }
    }

    /// <summary>Field number for the "PasswordUpdate" field.</summary>
    public const int PasswordUpdateFieldNumber = 5;
    private global::Google.Protobuf.WellKnownTypes.Timestamp passwordUpdate_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp PasswordUpdate {
      get { return passwordUpdate_; }
      set {
        passwordUpdate_ = value;
      }
    }

    /// <summary>Field number for the "AgreementAccepted" field.</summary>
    public const int AgreementAcceptedFieldNumber = 6;
    private global::Google.Protobuf.WellKnownTypes.Timestamp agreementAccepted_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp AgreementAccepted {
      get { return agreementAccepted_; }
      set {
        agreementAccepted_ = value;
      }
    }

    /// <summary>Field number for the "IsLocked" field.</summary>
    public const int IsLockedFieldNumber = 7;
    private bool isLocked_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsLocked {
      get { return isLocked_; }
      set {
        isLocked_ = value;
      }
    }

    /// <summary>Field number for the "IsInactive" field.</summary>
    public const int IsInactiveFieldNumber = 8;
    private bool isInactive_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsInactive {
      get { return isInactive_; }
      set {
        isInactive_ = value;
      }
    }

    /// <summary>Field number for the "EmailAddress" field.</summary>
    public const int EmailAddressFieldNumber = 9;
    private string emailAddress_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EmailAddress {
      get { return emailAddress_; }
      set {
        emailAddress_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "PhoneNumber" field.</summary>
    public const int PhoneNumberFieldNumber = 10;
    private string phoneNumber_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PhoneNumber {
      get { return phoneNumber_; }
      set {
        phoneNumber_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "FullName" field.</summary>
    public const int FullNameFieldNumber = 11;
    private string fullName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FullName {
      get { return fullName_; }
      set {
        fullName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "PrefferredLanguage" field.</summary>
    public const int PrefferredLanguageFieldNumber = 12;
    private string prefferredLanguage_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PrefferredLanguage {
      get { return prefferredLanguage_; }
      set {
        prefferredLanguage_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ForceChangePassword" field.</summary>
    public const int ForceChangePasswordFieldNumber = 13;
    private bool forceChangePassword_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool ForceChangePassword {
      get { return forceChangePassword_; }
      set {
        forceChangePassword_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SecurityLogin);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SecurityLogin other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Login != other.Login) return false;
      if (Password != other.Password) return false;
      if (!object.Equals(Created, other.Created)) return false;
      if (!object.Equals(PasswordUpdate, other.PasswordUpdate)) return false;
      if (!object.Equals(AgreementAccepted, other.AgreementAccepted)) return false;
      if (IsLocked != other.IsLocked) return false;
      if (IsInactive != other.IsInactive) return false;
      if (EmailAddress != other.EmailAddress) return false;
      if (PhoneNumber != other.PhoneNumber) return false;
      if (FullName != other.FullName) return false;
      if (PrefferredLanguage != other.PrefferredLanguage) return false;
      if (ForceChangePassword != other.ForceChangePassword) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Login.Length != 0) hash ^= Login.GetHashCode();
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      if (created_ != null) hash ^= Created.GetHashCode();
      if (passwordUpdate_ != null) hash ^= PasswordUpdate.GetHashCode();
      if (agreementAccepted_ != null) hash ^= AgreementAccepted.GetHashCode();
      if (IsLocked != false) hash ^= IsLocked.GetHashCode();
      if (IsInactive != false) hash ^= IsInactive.GetHashCode();
      if (EmailAddress.Length != 0) hash ^= EmailAddress.GetHashCode();
      if (PhoneNumber.Length != 0) hash ^= PhoneNumber.GetHashCode();
      if (FullName.Length != 0) hash ^= FullName.GetHashCode();
      if (PrefferredLanguage.Length != 0) hash ^= PrefferredLanguage.GetHashCode();
      if (ForceChangePassword != false) hash ^= ForceChangePassword.GetHashCode();
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
      if (Login.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Login);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Password);
      }
      if (created_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Created);
      }
      if (passwordUpdate_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(PasswordUpdate);
      }
      if (agreementAccepted_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(AgreementAccepted);
      }
      if (IsLocked != false) {
        output.WriteRawTag(56);
        output.WriteBool(IsLocked);
      }
      if (IsInactive != false) {
        output.WriteRawTag(64);
        output.WriteBool(IsInactive);
      }
      if (EmailAddress.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(EmailAddress);
      }
      if (PhoneNumber.Length != 0) {
        output.WriteRawTag(82);
        output.WriteString(PhoneNumber);
      }
      if (FullName.Length != 0) {
        output.WriteRawTag(90);
        output.WriteString(FullName);
      }
      if (PrefferredLanguage.Length != 0) {
        output.WriteRawTag(98);
        output.WriteString(PrefferredLanguage);
      }
      if (ForceChangePassword != false) {
        output.WriteRawTag(104);
        output.WriteBool(ForceChangePassword);
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
      if (Login.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Login);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      if (created_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Created);
      }
      if (passwordUpdate_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(PasswordUpdate);
      }
      if (agreementAccepted_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(AgreementAccepted);
      }
      if (IsLocked != false) {
        size += 1 + 1;
      }
      if (IsInactive != false) {
        size += 1 + 1;
      }
      if (EmailAddress.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EmailAddress);
      }
      if (PhoneNumber.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PhoneNumber);
      }
      if (FullName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FullName);
      }
      if (PrefferredLanguage.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PrefferredLanguage);
      }
      if (ForceChangePassword != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SecurityLogin other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Login.Length != 0) {
        Login = other.Login;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
      }
      if (other.created_ != null) {
        if (created_ == null) {
          Created = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Created.MergeFrom(other.Created);
      }
      if (other.passwordUpdate_ != null) {
        if (passwordUpdate_ == null) {
          PasswordUpdate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        PasswordUpdate.MergeFrom(other.PasswordUpdate);
      }
      if (other.agreementAccepted_ != null) {
        if (agreementAccepted_ == null) {
          AgreementAccepted = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        AgreementAccepted.MergeFrom(other.AgreementAccepted);
      }
      if (other.IsLocked != false) {
        IsLocked = other.IsLocked;
      }
      if (other.IsInactive != false) {
        IsInactive = other.IsInactive;
      }
      if (other.EmailAddress.Length != 0) {
        EmailAddress = other.EmailAddress;
      }
      if (other.PhoneNumber.Length != 0) {
        PhoneNumber = other.PhoneNumber;
      }
      if (other.FullName.Length != 0) {
        FullName = other.FullName;
      }
      if (other.PrefferredLanguage.Length != 0) {
        PrefferredLanguage = other.PrefferredLanguage;
      }
      if (other.ForceChangePassword != false) {
        ForceChangePassword = other.ForceChangePassword;
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
            Login = input.ReadString();
            break;
          }
          case 26: {
            Password = input.ReadString();
            break;
          }
          case 34: {
            if (created_ == null) {
              Created = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Created);
            break;
          }
          case 42: {
            if (passwordUpdate_ == null) {
              PasswordUpdate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(PasswordUpdate);
            break;
          }
          case 50: {
            if (agreementAccepted_ == null) {
              AgreementAccepted = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(AgreementAccepted);
            break;
          }
          case 56: {
            IsLocked = input.ReadBool();
            break;
          }
          case 64: {
            IsInactive = input.ReadBool();
            break;
          }
          case 74: {
            EmailAddress = input.ReadString();
            break;
          }
          case 82: {
            PhoneNumber = input.ReadString();
            break;
          }
          case 90: {
            FullName = input.ReadString();
            break;
          }
          case 98: {
            PrefferredLanguage = input.ReadString();
            break;
          }
          case 104: {
            ForceChangePassword = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class SecurityLogins : pb::IMessage<SecurityLogins> {
    private static readonly pb::MessageParser<SecurityLogins> _parser = new pb::MessageParser<SecurityLogins>(() => new SecurityLogins());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SecurityLogins> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.SecurityLoginReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLogins() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLogins(SecurityLogins other) : this() {
      sL_ = other.sL_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityLogins Clone() {
      return new SecurityLogins(this);
    }

    /// <summary>Field number for the "SL" field.</summary>
    public const int SLFieldNumber = 1;
    private static readonly pb::FieldCodec<global::CareerCloud.gRPC.Protos.SecurityLogin> _repeated_sL_codec
        = pb::FieldCodec.ForMessage(10, global::CareerCloud.gRPC.Protos.SecurityLogin.Parser);
    private readonly pbc::RepeatedField<global::CareerCloud.gRPC.Protos.SecurityLogin> sL_ = new pbc::RepeatedField<global::CareerCloud.gRPC.Protos.SecurityLogin>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CareerCloud.gRPC.Protos.SecurityLogin> SL {
      get { return sL_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SecurityLogins);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SecurityLogins other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!sL_.Equals(other.sL_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= sL_.GetHashCode();
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
      sL_.WriteTo(output, _repeated_sL_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += sL_.CalculateSize(_repeated_sL_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SecurityLogins other) {
      if (other == null) {
        return;
      }
      sL_.Add(other.sL_);
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
            sL_.AddEntriesFrom(input, _repeated_sL_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
