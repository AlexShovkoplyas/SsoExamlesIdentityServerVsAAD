using System.Threading.Tasks;

namespace MvcTest
{
    public interface IBasicAuthenticationService
    {
        Task<bool> IsValidUserAsync(string user, string password);
    }

    public class BasicAuthenticationService
    {
        Task<bool> IsValidUserAsync(string user, string password)
        {
            return Task.FromResult<bool>(true);
        }
    }
}