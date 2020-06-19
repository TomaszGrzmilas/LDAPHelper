using LDAPHelper.Models;
using System.Collections.Generic;
using System.DirectoryServices;

namespace LDAPHelper
{
    public class Service
    {
        private readonly LdapConfig Config;
        private readonly DirectoryEntry Entry;
        private readonly string UserName;
        private readonly string Password;

        public Service(string[] domainName, string userName, string password)
        {
            UserName = userName;
            Password = password;
            Config = new LdapConfig(domainName);
            Entry = new DirectoryEntry(Config.Path, Config.Url + "\\" + UserName, Password);
            Login();
        }

        public Dictionary<string, IEnumerable<string>> GetUserProperiesByUsername(string UserName, IEnumerable<string> properties)
        {
            return GetObjectProperies(
                $"(&(objectCategory=person)(objectClass=User)({Attributes.SamAccountName}={UserName}))",
                properties
            );
        }

        public Dictionary<string, IEnumerable<string>> GetUserProperiesByDistinguishedName(string distinguishedName, IEnumerable<string> properties)
        {
            return GetObjectProperies(
                $"(&({Attributes.DistinguishedName}={distinguishedName}))",
                properties
            );
        }

        public List<Dictionary<string, IEnumerable<string>>> GetAllUsersProperies(IEnumerable<string> properties)
        {
            return GetObjectsProperies(
                $"(&(objectCategory=person)(objectClass=User))",
                properties
            );
        }

        private void Login()
        {
            GetUserProperiesByUsername(UserName, new[] { Attributes.Name });
        }

        private Dictionary<string, IEnumerable<string>> GetObjectProperies(string filter, IEnumerable<string> properties)
        {
            var result = GetSearcher(filter, properties).FindOne();
            return HandleSearchResult(result, properties);
        }

        private List<Dictionary<string, IEnumerable<string>>> GetObjectsProperies(string filter, IEnumerable<string> properties)
        {
            var result = GetSearcher(filter, properties).FindAll();
            return HandleSearchResultCollection(result, properties);
        }

        private DirectorySearcher GetSearcher(string filter, IEnumerable<string> searchedProperties)
        {
            using DirectorySearcher searcher = new DirectorySearcher(Entry);

            foreach (var propertie in searchedProperties)
            {
                searcher.PropertiesToLoad.Add(propertie);
            }

            searcher.Filter = filter;
            return searcher;
        }

        private Dictionary<string, IEnumerable<string>> HandleSearchResult(SearchResult result, IEnumerable<string> searchedProperties)
        {
            Dictionary<string, IEnumerable<string>> RetDictionary = new Dictionary<string, IEnumerable<string>>();
            if (result != null)
            {
                foreach (var propertie in searchedProperties)
                {
                    var value = result.Properties[propertie];
                    if ((value?.Count ?? 0) > 0)
                    {
                        List<string> entry = new List<string>();
                        foreach (var v in value)
                        {
                            entry.Add(v.ToString());

                        }
                        RetDictionary.Add(propertie, entry);
                    }
                }
            }
            return RetDictionary;
        }

        private List<Dictionary<string, IEnumerable<string>>> HandleSearchResultCollection(SearchResultCollection resultCollection, IEnumerable<string> searchedProperties)
        {
            List<Dictionary<string, IEnumerable<string>>> RetList = new List<Dictionary<string, IEnumerable<string>>>();
            if ((resultCollection?.Count ?? 0) > 0)
            {
                foreach (var result in resultCollection)
                {
                    RetList.Add(HandleSearchResult(result as SearchResult, searchedProperties));
                }
            }
            return RetList;
        }
    }
}

