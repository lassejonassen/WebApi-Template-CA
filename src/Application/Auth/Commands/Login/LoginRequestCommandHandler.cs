using Application.Common.Interfaces;
using Contracts.Auth;
using ErrorOr;
using MediatR;

namespace Application.Auth.Commands.Login;
public class LoginRequestCommandHandler(IApplicationUsersRepository usersRepo, IJwtTokenGenerator jwtTokenGenerator)
	: IRequestHandler<LoginRequestCommand, ErrorOr<LoginResponse>>
{
	public async Task<ErrorOr<LoginResponse>> Handle(LoginRequestCommand command, CancellationToken cancellationToken)
	{
		var user = await usersRepo.GetByEmailAsync(command.Request.Email, cancellationToken);

		if (user is null)
		{
			return Error.NotFound("ApplicationUser.NotFound", "No User found with given Email");
		}

		bool authenticated = await usersRepo.CheckPassword(user, command.Request.Password);

		if (!authenticated)
		{
			return Error.Failure("ApplicationUser.NotAuthenticated", "Password is wrong");
		}

		var roles = await usersRepo.GetUsersRoles(user);

		string token = jwtTokenGenerator.GenerateToken(Guid.Parse(user.Id), user.FirstName, user.LastName, user.Email, roles);

		LoginResponse response = new()
		{ Id = Guid.Parse(user.Id), Token = token };

		return response;
	}
}
