using System;
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
        public async Task Post(
            [FromBody]string courseName, 
            [FromBody]string chapterName, 
            [FromBody]string lessonName, 
            [FromBody]DateTime started, 
            [FromBody]DateTime completed, 
            CancellationToken cancellationToken)
        {
            var userNameClaim = User.Claims.First(c => c.Type == ClaimTypes.Name);
            var userName = userNameClaim.Value;

            var lessonInfo = new LessonInfo(lessonName, started, completed);

            await AddLessonUnitOfWork.ExecuteAsync(userName, courseName, chapterName, lessonInfo, cancellationToken);
        }
    }
}