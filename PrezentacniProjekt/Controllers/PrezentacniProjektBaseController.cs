using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PrezentacniProjekt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize] // Require authentication for all actions
    public class PrezentacniProjektBaseController : ControllerBase
    {
        private readonly ILogger<PrezentacniProjektBaseController> _logger;

        public PrezentacniProjektBaseController(ILogger<PrezentacniProjektBaseController> logger)
        {
            _logger = logger;
        }
    }
}
