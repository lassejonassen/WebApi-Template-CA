using Application.Common.Interfaces;
using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Queries.QueryById;
public class ApplicationUserQueryByIdHandler(IApplicationUsersRepository repo)
	: IRequestHandler<ApplicationUserQueryById, ErrorOr<ApplicationUserResponse>>
{
	public async Task<ErrorOr<ApplicationUserResponse>> Handle(ApplicationUserQueryById query, CancellationToken cancellationToken)
	{
		var user = await repo.GetByIdAsync(query.Id.ToString(), cancellationToken);

		if (user is null)
		{
			return Error.NotFound("ApplicationUser.NotFound", "No User was found on given ID");
		}

		return new ApplicationUserResponse()
		{
			Id = Guid.Parse(user.Id),
			FirstName = user.FirstName,
			LastName = user.LastName,
			Email = user.Email,
			UserName = user.UserName,
			PhoneNumber = user.PhoneNumber,
			CreateTime = user.CreateTime,
			UpdateTime = user.UpdateTime,
		};
	}
}
