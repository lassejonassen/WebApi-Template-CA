using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
	public class Result<TValue, TError>
	{
		public readonly TValue? Value;
		public readonly TError Error;

		public bool _isSuccess;

		private Result(TValue value)
		{
			_isSuccess = true;
			Value = value;
			Error = default;
		}

		private Result(TError error)
		{
			_isSuccess = false;
			Value = default;
			Error = error;
		}

		// Happy path
		public static implicit operator Result<TValue, TError>(TValue value) => new(value);

		// Error path
		public static implicit operator Result<TValue, TError>(TError error) => new(error);

		public Result<TValue, TError> Match(Func<TValue, Result<TValue, TError>> success, Func<TError, Result<TValue, TError>> failure)
		{
			if (_isSuccess)
			{
				return success(Value!);
			}
			return failure(Error!);
		}
	}
}
