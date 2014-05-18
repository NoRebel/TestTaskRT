using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.BookShelfApi;
using TestTask.Core;

namespace TestTask
{
	class Program
	{
		static void Main(string[] args)
		{
			//TestPowerOf();
			//TestStringReverse();
			//TestStringReplicate();
			//TestFindOdds(1, 100);
			TestBookShelfApi();
		}

		private static void TestBookShelfApi()
		{
			var api = new BookShelf();
			var book1 = new Book()
			{
				Author = "A. Miln",
				Isbn = "000-0-000-00000-2",
				Title = "Winnie the Pooh"
			};
			// TODO: Uncomment for the first run;
			//var addResult = api.AddBook(book1);
			//Console.WriteLine(addResult.Success);
			//Console.WriteLine("AddBooks books: Success - {0}, ErrorMessages - {1}", addResult.Success, String.Join("\t", addResult.ErrorMessages));
			var getBooksResult = api.GetBooks();
			Console.WriteLine("Get books: Success - {0}, ErrorMessages - {1}", getBooksResult.Success, String.Join("\t", getBooksResult.ErrorMessages));
			foreach (var book in getBooksResult.Result)
			{
				Console.WriteLine("{0}, {1}, {2}, {3}", book.Author, book.Isbn, book.Title, book.Loaned);
			}			
			var loanBook = api.LoanBook("000-0-000-00000-2");
			Console.WriteLine("Loan book: Success - {0}, ErrorMessages - {1}", loanBook.Success, String.Join("\t", loanBook.ErrorMessages));

			// TODO: Uncomment for the second run
			var returnBook = api.ReturnBook("000-0-000-00000-2");			
			Console.WriteLine("Return book: Success - {0}, ErrorMessages - {1}", returnBook.Success, String.Join("; ", returnBook.ErrorMessages));
			Console.ReadLine();

		}

		private static void TestFindOdds(int start, int end)
		{
			var oddsFinder = new OddNumbersFinder();
			foreach (var odd in oddsFinder.Find(start, end))
			{
				Console.Write("{0}; ", odd);
			}
			Console.ReadLine();
		}

		private static void TestStringReplicate()
		{
			var stringReplicator = new StringReplicator();
			Console.WriteLine("Please enter a string to be replicated: ");
			var sourceString = Console.ReadLine();
			Console.WriteLine("Please enter how many tumes it has to be replicated");
			var strTimes = Console.ReadLine();
			int times;
			Int32.TryParse(strTimes, out times);
			Console.WriteLine("Resulted string is {0}", stringReplicator.Replicate(sourceString, (uint)Math.Abs(times)));
			Console.ReadLine();
		}

		private static void TestStringReverse()
		{
			var stringReverser = new StringReverser();
			Console.WriteLine("Please enter a string to be reversed: ");
			var sourceString = Console.ReadLine();
			Console.WriteLine("Reversed string is: {0}", stringReverser.Reverse(sourceString, SmartnessLevel.Smart));
			Console.ReadKey();
		}

		private static void TestPowerOf()
		{
			var testPowerOf = new PowerOf();
			Console.WriteLine("Please enter number to see if it is power of {0}", testPowerOf.Subject);
			var input = Console.ReadLine();
			int number;
			var parseResult = Int32.TryParse(input, out number);
			if (parseResult)
			{
				var is2Powered = testPowerOf.Check(number);
				Console.WriteLine(is2Powered ? "{0} is 2-powered" : "{0} is not 2-powered", number);
			}
			else
			{
				Console.WriteLine("You entered an invalid integer number");
			}
			Console.ReadLine();
		}
	}
}
