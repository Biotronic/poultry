using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Biotronic.Poultry.Controllers
{
    [EnableCors]
    public abstract class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        protected ILogger<T> Logger { get; }

        protected BaseController(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
