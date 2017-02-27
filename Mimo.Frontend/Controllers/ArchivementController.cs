using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Business.UoW;

namespace Mimo.Frontend.Controllers
{
    [Authorize]
    [Route("v1/archivement")]
    public class ArchivementController : Controller
    {
        public ArchivementController(GetArchivementsForUserUnitOfWork getArchivementsForUserUnitOfWork)
        {
            GetArchivementsForUserUnitOfWork = getArchivementsForUserUnitOfWork;
        }

        private GetArchivementsForUserUnitOfWork GetArchivementsForUserUnitOfWork { get; }

        [HttpGet]
        public async Task Get(CancellationToken cancellationToken)
        {
            var userNameClaim = User.Claims.First(c => c.Type == ClaimTypes.Name);
            var userName = userNameClaim.Value;
            await GetArchivementsForUserUnitOfWork.ExecuteAsync(userName, cancellationToken);
        }
    }
}