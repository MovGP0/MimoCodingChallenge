using Mimo.Business.Users;

namespace Mimo.Business.Archivements
{
    public abstract class Archivement
    {
        public abstract string Name { get; }
        public abstract bool IsApplyableToUser(User user);
    }
}