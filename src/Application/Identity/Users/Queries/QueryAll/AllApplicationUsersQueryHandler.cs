using Application.Common.Interfaces;
using Contracts.Identity;
using ErrorOr;
using MediatR;

namespace Application.Identity.Users.Queries.QueryAll;
public class AllApplicationUsersQueryHandler(IApplicationUsersRepository repo)
	: IRequestHandler<AllApplicationUsersQuery, ErrorOr<List<ApplicationUserResponse>>>
{
	public async Task<ErrorOr<List<ApplicationUserResponse>>> Handle(AllApplicationUsersQuery query, CancellationToken cancellationToken)
	{
		var applicationUsers = await repo.GetAllAsync(cancellationToken);

		List<ApplicationUserResponse> applicationUserResponses 
			= applicationUsers
			.Select(user => new ApplicationUserResponse
			{
				Id = Guid.Parse(user.Id),
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Email = user.Email,
				CreateTime = user.CreateTime,
				UpdateTime = user.UpdateTime,
				PhoneNumber = user.PhoneNumber,
			})
			.ToList();

		return applicationUserResponses;
	}
}
