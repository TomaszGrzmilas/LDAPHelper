using System.Collections.Generic;

namespace LDAPHelper
{
    public static class Attributes
    {
        public static string MDBUseDefaults => "mdbusedefaults";
        public static string DistinguishedName => "distinguishedname";
        public static string WhenCreated => "whencreated";
        public static string Title => "title";
        public static string InstanceType => "instancetype";
        public static string CodePage => "codepage";
        public static string ADsPath => "adspath";
        public static string MsExchMailboxSecurityDescriptor => "msexchmailboxsecuritydescriptor";
        public static string MsExchDumpsterQuota => "msexchdumpsterquota";
        public static string UserAccountControl => "useraccountcontrol";
        public static string PwdLastSet => "pwdlastset";
        public static string ThumbnailPhoto => "thumbnailphoto";
        public static string SAMAccountType => "samaccounttype";
        public static string MsExchCalendarLoggingQuota => "msexchcalendarloggingquota";
        public static string MsExchDumpsterWarningQuota => "msexchdumpsterwarningquota";
        public static string MsExchHideFromAddressLists => "msexchhidefromaddresslists";
        public static string UserPrincipalName => "userprincipalname";
        public static string LastLogon => "lastlogon";
        public static string L => "l";
        public static string MsTsExpireDate => "mstsexpiredate";
        public static string MsdsRevealeddSas => "msds-revealeddsas";
        public static string BadPasswordTime => "badpasswordtime";
        public static string MsExchMailboxGuid => "msexchmailboxguid";
        public static string PhysicalDeliveryOfficeName => "physicaldeliveryofficename";
        public static string MsDSAuthenticatedAtDc => "msds-authenticatedatdc";
        public static string MstsLicenseVersion2 => "mstslicenseversion2";
        public static string MailNickname => "mailnickname";
        public static string BadPwdCount => "badpwdcount";
        public static string AccountExpires => "accountexpires";
        public static string ObjectGuid => "objectguid";
        public static string Company => "company";
        public static string StreetAddress => "streetaddress";
        public static string MstsLicenSeversion3 => "mstslicenseversion3";
        public static string MsExchTextMessagingState => "msexchtextmessagingstate";
        public static string Sn => "sn";
        public static string MsDsConsistencyGuid => "ms-ds-consistencyguid";
        public static string Department => "department";
        public static string MsExchMobileMailboxFlags => "msexchmobilemailboxflags";
        public static string Mail => "mail";
        public static string LogonCount => "logoncount";
        public static string Manager => "manager";
        public static string Mobile => "mobile";
        public static string MsExchArchiveWarnQuota => "msexcharchivewarnquota";
        public static string MsExchHomeServerName => "msexchhomeservername";
        public static string MsExchSafeSendersHash => "msexchsafesendershash";
        public static string Usnchanged => "usnchanged";
        public static string MsExchArchiveQuota => "msexcharchivequota";
        public static string HomeMDB => "homemdb";
        public static string DsCorePropagationData => "dscorepropagationdata";
        public static string MsExchPoliciesIncluded => "msexchpoliciesincluded";
        public static string MsTsManagingLS => "mstsmanagingls";
        public static string MsExchUserAccountControl => "msexchuseraccountcontrol";
        public static string WhenChanged => "whenchanged";
        public static string TelephoneNumber => "telephonenumber";
        public static string DisplayName => "displayname";
        public static string Cn => "cn";
        public static string C => "c";
        public static string MsExchWhenMailboxCreated => "msexchwhenmailboxcreated";
        public static string MsExchVersion => "msexchversion";
        public static string MsExchUMDtmfMap => "msexchumdtmfmap";
        public static string MsExchUserCulture => "msexchuserculture";
        public static string HomeDirectory => "homedirectory";
        public static string PrimaryGroupId => "primarygroupid";
        public static string ObjectCategory => "objectcategory";
        public static string Co => "co";
        public static string UsnCreated => "usncreated";
        public static string LastLogonTimestamp => "lastlogontimestamp";
        public static string CountryCode => "countrycode";
        public static string ProxyAddresses => "proxyaddresses";
        public static string LegacyExchangeDN => "legacyexchangedn";
        public static string MsExchRecipientTypeDetails => "msexchrecipienttypedetails";
        public static string MsExchRbacPolicyLink => "msexchrbacpolicylink";
        public static string MsExchRecipientDisplayType => "msexchrecipientdisplaytype";
        public static string Name => "name";
        public static string ObjectSid => "objectsid";
        public static string MsTsLicenseVersion => "mstslicenseversion";
        public static string GivenName => "givenname";
        public static string MemberOf => "memberof";
        public static string HomeDrive => "homedrive";
        public static string PostalCode => "postalcode";
        public static string SamAccountName => "samaccountname";
        public static string LastLogoff => "lastlogoff";
        public static string St => "st";
        public static string ObjectClass => "objectclass";

        public static List<string> GetAll()
        {
            List<string> ret = new List<string>();
            foreach (var prop in typeof(Attributes).GetProperties())
            {
                ret.Add(prop.GetValue(typeof(Attributes)).ToString());
            }
            return ret;
        }

        public static List<string> GetUserAttributes()
        {
            List<string> ret = new List<string>();

            ret.Add(Title);
            ret.Add(UserPrincipalName);
            ret.Add(L);
            ret.Add(MailNickname);
            ret.Add(Company);
            ret.Add(PhysicalDeliveryOfficeName);
            ret.Add(StreetAddress);
            ret.Add(PostalCode);
            ret.Add(Department);
            ret.Add(Mail);
            ret.Add(Manager);
            ret.Add(Mobile);
            ret.Add(DisplayName);
            ret.Add(Cn);
            ret.Add(C);
            ret.Add(MsExchUserCulture);
            ret.Add(HomeDirectory);
            ret.Add(Co);
            ret.Add(Name);
            ret.Add(MemberOf);
            ret.Add(SamAccountName);
            ret.Add(St);
            ret.Add(DistinguishedName);
            ret.Add(ADsPath);
            ret.Add(TelephoneNumber);
            ret.Add(WhenCreated);

            return ret;
        }
    }
}
