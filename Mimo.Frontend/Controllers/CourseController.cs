using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mimo.Frontend.Controllers
{
    [Authorize]
    [Route(@"v1/course")]
    public sealed class CourseController : Controller
    {
    }
}