using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Core
{
    public class PowerOf
    {
	    public readonly int Subject = 2;

	    public bool Check(int number)
	    {		    		 
			while ((number > 1) && (number % Subject == 0))
			{
				number = number / Subject;
		    }

			return number == 1;
	    }
    }
}
