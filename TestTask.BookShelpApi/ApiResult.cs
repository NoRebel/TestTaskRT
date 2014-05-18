using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.BookShelfApi
{
	public class ApiResult<T>
	{
		public bool Success { get; set; }
		public List<String> ErrorMessages { get; set; }
		public T Result { get; set; }

		public ApiResult()
		{
			ErrorMessages = new List<string>();
		}
	}
}
