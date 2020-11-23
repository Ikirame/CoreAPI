using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    /// <summary>
    /// API controller base class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Instance of the ILogger interface shared
        /// </summary>
        protected readonly ILogger Logger;

        #endregion

        #region Constructors

        /// <summary>
        /// API controller constructor
        /// </summary>
        /// <param name="logger"></param>
        protected ApiController(ILogger logger)
        {
            Logger = logger;
        }

        #endregion
    }
}