using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TestTask.BookShelfApi
{
	public class BookShelf
	{
		public ApiResult<IEnumerable<Book>> GetBooks()
		{
			try
			{
				using (var db = new BookShelfDbContext())
				{
					return new ApiResult<IEnumerable<Book>>()
					{
						Success = true,
						Result = db.Books.ToList()
					};
				}
			}
			catch (Exception e)
			{
				return new ApiResult<IEnumerable<Book>>()
				{
					Success = false,
					ErrorMessages = new List<string>() { e.Message }
				};
			}
		}

		public ApiResult<Book> LoanBook(string isbn)
		{
			try
			{
				using (var db = new BookShelfDbContext())
				{
					var book = db.Books.SingleOrDefault(b => b.Isbn == isbn);
					if (book == null)
						return new ApiResult<Book>()
						{
							Success = false,
							ErrorMessages = new List<string>() { "Book doesn't exist" }
						};
					if (book.Loaned)
						return new ApiResult<Book>()
						{
							Success = false,
							ErrorMessages = new List<string>() { "Book is already loaned" }
						};
					book.Loaned = true;
					db.Entry(book).State = EntityState.Modified;
					db.SaveChanges();
					return new ApiResult<Book>()
					{
						Result = book,
						Success = true
					};
				}

			}
			catch (Exception e)
			{
				return new ApiResult<Book>()
				{
					Success = false,
					ErrorMessages = new List<string>() { e.Message }
				};
			}
		}

		public ApiResult<Book> ReturnBook(string isbn)
		{
			try
			{
				using (var db = new BookShelfDbContext())
				{
					var book = db.Books.SingleOrDefault(b => b.Isbn == isbn);
					if (book == null)
						return new ApiResult<Book>()
						{
							Success = false,
							ErrorMessages = new List<string>() {"Book doesn't exist"}
						};
					if (!book.Loaned)
						return new ApiResult<Book>()
						{
							Success = false,
							ErrorMessages = new List<string>() {"Book is already on shelf"}
						};
					book.Loaned = false;
					db.Entry(book).State = EntityState.Modified;
					db.SaveChanges();
					return new ApiResult<Book>()
					{
						Result = book,
						Success = true
					};
				}
			}
			catch (Exception e)
			{
				return new ApiResult<Book>()
				{
					Success = false, ErrorMessages = new List<string>(){e.Message}
				};
			}
		}

		public ApiResult<Book> AddBook(Book book)
		{
			try
			{
				using (var db = new BookShelfDbContext())
				{
					db.Books.Add(book);
					db.SaveChanges();
					return new ApiResult<Book>()
					{
						Success = true, Result = book
					};
				}				
			}
			catch(Exception e)
			{
				return new ApiResult<Book>()
				{
					Success = false,
					ErrorMessages = new List<string>(){e.Message}
				};
			} 
		}
	}
}
