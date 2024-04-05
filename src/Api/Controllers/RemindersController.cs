//using Application.Reminders.Commands.DeleteReminder;
//using Application.Reminders.Commands.DismissReminder;
//using Application.Reminders.Commands.SetReminder;
//using Application.Reminders.Queries.GetReminder;
//using Application.Reminders.Queries.ListReminders;
//using Contracts.Reminders;
//using Domain.Reminders;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace Api.Controllers;

//[Route("users/{userId:guid}/subscriptions/{subscriptionId:guid}/reminders")]
//public class RemindersController(ISender _mediator) : ApiController
//{
//	[HttpPost]
//	public async Task<IActionResult> CreateReminder(Guid userId, Guid subscriptionId, CreateReminderRequest request)
//	{
//		var command = new SetReminderCommand(userId, subscriptionId, request.Text, request.DateTime.UtcDateTime);

//		var result = await _mediator.Send(command);

//		return result.Match(
//			//reminder => CreatedAtAction(
//				actionName: nameof(GetReminder),
//				routeValues: new { UserId = userId, SubscriptionId = subscriptionId, ReminderId = reminder.Id },
//				value: ToDto(reminder)),
//			Problem);
//	}

//	[HttpPost("{reminderId:guid}/dismiss")]
//	public async Task<IActionResult> DismissReminder(Guid userId, Guid subscriptionId, Guid reminderId)
//	{
//		var command = new DismissReminderCommand(userId, subscriptionId, reminderId);

//		var result = await _mediator.Send(command);

//		return result.Match(
//			_ => NoContent(),
//			Problem);
//	}

//	[HttpDelete("{reminderId:guid}")]
//	public async Task<IActionResult> DeleteReminder(Guid userId, Guid subscriptionId, Guid reminderId)
//	{
//		var command = new DeleteReminderCommand(userId, subscriptionId, reminderId);

//		var result = await _mediator.Send(command);

//		return result.Match(
//			_ => NoContent(),
//			Problem);
//	}

//	[HttpGet("{reminderId:guid}")]
//	public async Task<IActionResult> GetReminder(Guid userId, Guid subscriptionId, Guid reminderId)
//	{
//		var query = new GetReminderQuery(userId, subscriptionId, reminderId);

//		var result = await _mediator.Send(query);

//		return result.Match(
//			reminder => Ok(ToDto(reminder)),
//			Problem);
//	}

//	[HttpGet]
//	public async Task<IActionResult> ListReminders(Guid userId, Guid subscriptionId)
//	{
//		var query = new ListRemindersQuery(userId, subscriptionId);

//		var result = await _mediator.Send(query);

//		return result.Match(
//			reminders => Ok(reminders.ConvertAll(ToDto)),
//			Problem);
//	}

//	private ReminderResponse ToDto(Reminder reminder) =>
//		new(reminder.Id, reminder.Text, reminder.DateTime, reminder.IsDismissed);
//}