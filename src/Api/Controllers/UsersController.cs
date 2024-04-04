using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/users")]
[ApiController]
public class UsersController(IMediator _mediator) : ControllerBase
{
}
