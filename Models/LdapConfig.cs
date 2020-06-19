namespace LDAPHelper.Models
{
    public class LdapConfig
    {
        public string Path { get; private set; }
        public string Url { get; private set; }

        public LdapConfig(string[] domainComponents)
        {
            Path = @"LDAP://";
            foreach (var item in domainComponents)
            {
                Path += $"DC={item},";
                Url += $"{item}.";
            }
            Path = Path.TrimEnd(',');
            Url = Url.TrimEnd('.');
        }
    }
}
