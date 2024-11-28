using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, string author, string yearStr)
        {
            if (int.TryParse(yearStr, out int year))
            {
                if (title.Length == 0 || author.Length == 0 || year > DateTime.Now.Year)
                    throw new Exception("Creation book failed");
                Title = title;
                Author = author;
                PublicationYear = year;
            }
            else
            {
                throw new Exception("Invalid year of publication");
            }
        }

        public Book(string title, string author, int year) 
        {
            if (title.Length == 0 || author.Length == 0 || year > DateTime.Now.Year)
                throw new Exception("Creation book failed");
            Title = title;
            Author = author;
            PublicationYear = year;
        }

        public override string ToString()
        {
            return "Title: " + Title + "; Author: " + Author + "; Year of publication: " + PublicationYear;
        }
    }
}
