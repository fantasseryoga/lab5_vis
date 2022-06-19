using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class Book
    {
        public Book() { }
        public Book(string author, string name, string publication, int publicationYear, DateTime issueDate, int returnPeriod,bool isReturned)
        {
            Author = author;
            Name = name;
            Publication = publication;
            PublicationYear = publicationYear;
            IssueDate = issueDate;
            ReturnPeriod = returnPeriod;
            IsReturned = isReturned;
        }

        public string Author { get;  set; }
        public string Name { get; set; } 
        public string Publication { get; set; }
        public int PublicationYear { get;  set; }
        public DateTime IssueDate { get;  set; }
        public int ReturnPeriod { get;  set; }
        public bool IsReturned { get;  set; }


    }
}
