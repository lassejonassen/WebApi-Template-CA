using Application.Common.Interfaces;
using Contracts.Identity;
using Domain.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Commands.Create;
public class CreateApplicationUserCommandHandler(IApplicationUsersRepository _repository)
	: IRequestHandler<CreateApplicationUserCommand, ErrorOr<ApplicationUserResponse>>
{
	public async Task<ErrorOr<ApplicationUserResponse>> Handle(CreateApplicationUserCommand command, CancellationToken cancellationToken)
	{
		var applicationUser = new ApplicationUser
		{
			Id = Guid.NewGuid().ToString(),
			FirstName = command.Request.FirstName,
			LastName = command.Request.LastName,
			Email = command.Request.Email,
			UserName = command.Request.UserName,
			CreateTime = DateTimeOffset.Now
		};

		await _repository.AddAsync(applicationUser, command.Request.Password, cancellationToken);

		applicationUser = await _repository.GetByIdAsync(applicationUser.Id, cancellationToken);

		return new ApplicationUserResponse
		{
			Id = Guid.Parse(applicationUser.Id),
			FirstName = applicationUser.FirstName,
			LastName = applicationUser.LastName,
			Email = applicationUser.Email,
			UserName = applicationUser.UserName,
			PhoneNumber = applicationUser.PhoneNumber,
			CreateTime = applicationUser.CreateTime,
			UpdateTime = applicationUser.UpdateTime,
		};
	}
}
