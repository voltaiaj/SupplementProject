using SuppTrackerProject.Domain.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace SuppTrackerProject.Domain.Repositories
{
    public interface IExternalLoginRepository
    {
        ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey);
    }
}
