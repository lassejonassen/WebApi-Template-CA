namespace Persistence.Entities
{
	public record MessageEntity : BaseEntity
	{
		public string Msg { get; set; }
	}
}
