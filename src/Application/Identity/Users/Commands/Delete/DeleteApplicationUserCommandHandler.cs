using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Commands.Delete;
public class DeleteApplicationUserCommandHandler(IApplicationUsersRepository repo)
	: IRequestHandler<DeleteApplicationUserCommand, ErrorOr<bool>>
{
	public async Task<ErrorOr<bool>> Handle(DeleteApplicationUserCommand command, CancellationToken cancellationToken)
	{
		var user = await repo.GetByIdAsync(command.Id.ToString(), cancellationToken);

		if (user is null)
		{
			return Error.NotFound("ApplicationUser.NotFound", "No ApplicationUser found on given ID");
		}

		await repo.DeleteAsync(user, cancellationToken);

		return true;
	}
}
