using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/identity/users")]
[ApiController]
public class UsersController(IMediator _mediator) : ControllerBase
{
}
