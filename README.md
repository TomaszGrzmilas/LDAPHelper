# LDAPHelper
Wrapper liblary for LDAP querying

#Usage
```
using LDAPHelper;

static void Main(string[] args)
{
    var ldap = new Service(new[] { "google", "com"}, "user", "password");

    if (ldap != null)
    {
        foreach (var user in ldap.GetAllUsersProperies(new[] { Attributes.Name }))
        {
                Console.WriteLine($"{ user.GetValueOrDefault(Attributes.Name).FirstOrDefault()}");
        }
    }
    Console.ReadLine();
}

static void Main(string[] args)
{
    var ldap = new Service(new[] { "google", "com"}, "user", "password");

    if (ldap != null)
    {
        foreach (var prop in ldap.GetUserProperiesByUsername("my_usre", Attributes.GetUserAttributes()))
        {
            if(prop.Key == Attributes.Manager)
            {
                foreach (var proper in ldap.GetUserProperiesByDistinguishedName(prop.Value.FirstOrDefault(), Attributes.GetUserAttributes()))
                {
                    if(proper.Value.Count() > 1)
                    {
                        foreach (var pv in proper.Value)
                        {
                            Console.WriteLine($"{ proper.Key } - {pv}");
                        }
                    }   
                    else
                    {
                        Console.WriteLine($"{ proper.Key } - {proper.Value.FirstOrDefault()}");
                    }
                }
            }
        }          
    }
    Console.ReadLine();
}

```