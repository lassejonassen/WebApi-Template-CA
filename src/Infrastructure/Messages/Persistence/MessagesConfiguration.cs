using Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Messages.Persistence;

public class MessagesConfiguration : IEntityTypeConfiguration<Message>
{
	public void Configure(EntityTypeBuilder<Message> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.CorrelationId).IsRequired();
		builder.Property(x => x.To).IsRequired();
		builder.Property(x => x.From).IsRequired();
		builder.Property(x => x.Text).IsRequired();
		builder.Property(x => x.Read).IsRequired();
	}
}
