using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mimo.Business.Users;

namespace Mimo.Business.UoW
{
    public sealed class GetArchivementsForUserUnitOfWork
    {
        public GetArchivementsForUserUnitOfWork(IUsersRepository usersRepository)
        {
            UsersRepository = usersRepository;
        }

        private IUsersRepository UsersRepository { get; }

        public async Task<IEnumerable<string>> ExecuteAsync(string userName, CancellationToken cancellationToken)
        {
            var user = await UsersRepository.GetAsync(userName, cancellationToken);
            if(user == null) throw new ArgumentException("Username '{userName}' not found.", nameof(userName));

            var archivements = Archivements.ArchivementFactory.Create();
            var archived = archivements.Where(a => a.IsApplyableToUser(user));
            return archived.Select(a => a.Name);
        }
    }
}