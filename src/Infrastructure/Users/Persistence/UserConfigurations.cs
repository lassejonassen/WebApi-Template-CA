﻿using Domain.Users;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Users.Persistence;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(u => u.Id);

		builder.Property(u => u.Id)
			.ValueGeneratedNever();

		builder.OwnsOne<Calendar>("_calendar", cb =>
			cb.Property<Dictionary<DateOnly, int>>("_calendar")
				.HasColumnName("CalendarDictionary")
				.HasValueJsonConverter());

		builder.Property<List<Guid>>("_reminderIds")
			.HasColumnName("ReminderIds")
			.HasListOfIdsConverter();

		builder.Property<List<Guid>>("_dismissedReminderIds")
			.HasColumnName("DismissedReminderIds")
			.HasListOfIdsConverter();

		builder.OwnsOne(u => u.Subscription, sb =>
		{
			sb.Property(s => s.Id)
				.HasColumnName("SubscriptionId");

			sb.Property(s => s.SubscriptionType)
				.HasConversion(
					v => v.Name,
					v => SubscriptionType.FromName(v, false));
		});

		builder.Property(u => u.Email);

		builder.Property(u => u.LastName);

		builder.Property(u => u.FirstName);
	}
}