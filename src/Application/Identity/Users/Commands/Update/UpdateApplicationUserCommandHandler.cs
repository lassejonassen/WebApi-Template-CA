using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Commands.Update;
public class UpdateApplicationUserCommandHandler(IApplicationUsersRepository repo)
	: IRequestHandler<UpdateApplicationUserCommand, ErrorOr<bool>>
{
	public async Task<ErrorOr<bool>> Handle(UpdateApplicationUserCommand command, CancellationToken cancellationToken)
	{
		var user = await repo.GetByIdAsync(command.Request.Id.ToString(), cancellationToken);

		if (user is null)
		{
			return Error.NotFound("ApplicationUser.NotFound", "No ApplicationUser found on given ID");
		}

		user.FirstName = command.Request.FirstName;
		user.LastName = command.Request.LastName;
		user.Email = command.Request.Email;
		user.PhoneNumber = command.Request.PhoneNumber;
		user.UserName = command.Request.UserName;
		user.UpdateTime = DateTimeOffset.Now;

		await repo.UpdateAsync(user, cancellationToken);

		return true;
	}
}
