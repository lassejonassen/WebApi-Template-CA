namespace Domain.Users;

public class Calendar
{
	/// <summary>
	/// day -> num events.
	/// </summary>
	private readonly Dictionary<DateOnly, int> _calendar = [];

	public static Calendar Empty()
	{
		return new Calendar();
	}

	public void IncrementEventCount(DateOnly date)
	{
		if (!_calendar.TryGetValue(date, out int value))
		{
			value = 0;
			_calendar[date] = value;
		}

		_calendar[date] = ++value;
	}

	public void DecrementEventCount(DateOnly date)
	{
		if (!_calendar.TryGetValue(date, out int value))
		{
			return;
		}

		_calendar[date] = --value;
	}

	public void SetEventCount(DateOnly date, int numEvents)
	{
		_calendar[date] = numEvents;
	}

	public int GetNumEventsOnDay(DateTimeOffset dateTime)
	{
		return _calendar.TryGetValue(DateOnly.FromDateTime(dateTime.Date), out int numEvents)
			? numEvents
			: 0;
	}

	private Calendar()
	{
	}
}