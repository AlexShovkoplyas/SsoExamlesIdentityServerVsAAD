using Microsoft.AspNetCore.Authentication;

namespace MvcTest
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }
    }

    public static class BasicAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Basic";
    }
}