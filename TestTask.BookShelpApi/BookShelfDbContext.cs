using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace TestTask.BookShelfApi
{
	public class BookShelfDbContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
	}
}
