using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equin.ApplicationFramework;
namespace Lab_5
{
    internal class BooksRegister : IEnumerable<Book>
    {
        public BooksRegister() { }
        public BooksRegister(IEnumerable<Book> books)
        {
            foreach (var item in books)
            {
                Books.Add(item);
            }
        }
        public List<Book> Books { get;private set; } = new List<Book>();

        public void Add(Book book)
        {
            Books.Add(book);
        }
        public void Remove(Book book)
        {
            Books.Remove(book);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return Books.GetEnumerator(); ;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)Books).GetEnumerator();
        }
       
    }
}
