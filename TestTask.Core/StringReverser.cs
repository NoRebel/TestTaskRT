using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Core
{
	public class StringReverser
	{
		public string Reverse(string source, SmartnessLevel smartness = SmartnessLevel.Smart)
		{
			switch (smartness)
			{
				case SmartnessLevel.Dumb:
					return DumbReverse(source);
				case SmartnessLevel.Smart:
					return NormalReverse(source);
				case SmartnessLevel.Genious:
					return GeniousReverse(source);
				default:
					return String.Empty;
			}			
		}

		private string DumbReverse(string source)
		{
			var sb = new StringBuilder();
			for (int i = source.Length - 1; i >= 0; i--)
			{
				sb.Append(source[i]);
			}
			return sb.ToString();
		}

		private string NormalReverse(string source)
		{
			var charArray = source.ToCharArray();
			var reversedArray = charArray.Reverse();
			return new string(reversedArray.ToArray());
		}

		private string GeniousReverse(string source)
		{
			return new string(source.Reverse().ToArray());
		}
	}
}
