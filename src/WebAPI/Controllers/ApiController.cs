using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        #region Fields

        protected readonly ILogger Logger;

        #endregion

        #region Constructors

        protected ApiController(ILogger logger)
        {
            Logger = logger;
        }

        #endregion
    }
}