using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Core
{
	public class OddNumbersFinder
	{
		public IEnumerable<int> Find(int start, int end, bool isSmartSolution = true)
		{
			return isSmartSolution ? SmartFind(start, end) : StupidFind(start, end);

		}

		private IEnumerable<int> StupidFind(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				if (i % 2 == 1)
					yield return i;
			}
		}

		private IEnumerable<int> SmartFind(int start, int end)
		{
			int index = start;
			int step = 1;
			bool isStepChanged = false;
			while (index <= end)
			{
				if (index%2 == 1)
				{
					if (!isStepChanged)
					{
						step ++;
						isStepChanged = true;
					}
					yield return index;
				}
					
				index += step;
			}
		}

	}
}
