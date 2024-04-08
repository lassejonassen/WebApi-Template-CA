using Contracts.Auth;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;

namespace Application.Auth.Commands.Login;

public record LoginRequestCommand(LoginRequest Request)
	: IRequest<ErrorOr<LoginResponse>>
{ }
