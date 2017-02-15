using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mimo.Backend.Users;

namespace Mimo.Business.Users
{
    public sealed class UsersRepository : IUsersRepository
    {
        private static UsersContext GetContext()
        {
            return new UsersContext();
        }

        public async Task<User> GetAsync(string userName, CancellationToken cancellationToken)
        {
            using (var context = GetContext())
            {
                var user = await context.Users.SingleOrDefaultAsync(u => u.Name == userName, cancellationToken);
                return UserMapper.ToBusiness(user);
            }
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            using (var context = GetContext())
            {
                await context.Users.AddAsync(UserMapper.ToBackend(user), cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}