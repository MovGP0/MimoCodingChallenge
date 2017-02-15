using System.Threading;
using System.Threading.Tasks;

namespace Mimo.Business.Users
{
    public interface IUsersRepository
    {
        Task<User> GetAsync(string userName, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
    }
}