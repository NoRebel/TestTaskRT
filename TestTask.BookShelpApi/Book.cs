using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace TestTask.BookShelfApi
{
    public class Book
    {
		[Key]
	    public string Isbn { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public bool Loaned { get; set; }
    }
}
