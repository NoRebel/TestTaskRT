using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Core
{
	public class StringReplicator
	{
		public string Replicate(string source, uint timesToReplicate)
		{
			var sb = new StringBuilder();
			for (int i = 0; i < timesToReplicate; i++)
			{
				sb.Append(source);
			}
			return sb.ToString();
		}
	}
}
