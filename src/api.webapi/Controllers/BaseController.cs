using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BaseController: ControllerBase;