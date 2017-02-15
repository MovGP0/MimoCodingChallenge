using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Business.UoW;
using Mimo.Business.Users;

namespace Mimo.Frontend.Controllers
{
    [Authorize]
    [Route("lesson")]
    public class LessonController : Controller
    {
        public LessonController(AddLessonUnitOfWork addLessonUnitOfWork)
        {
            AddLessonUnitOfWork = addLessonUnitOfWork;
        }

        private AddLessonUnitOfWork AddLessonUnitOfWork { get; }

        [HttpPost]
        public async Task Post([FromBody]LessonInfo lessonInfo, CancellationToken cancellationToken)
        {
            var userNameClaim = User.Claims.First(c => c.Type == ClaimTypes.Name);
            var userName = userNameClaim.Value;
            await AddLessonUnitOfWork.ExecuteAsync(userName, lessonInfo, cancellationToken);
        }
    }
}