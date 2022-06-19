using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Equin.ApplicationFramework;
namespace Lab_5
{
    public partial class Form1 : Form
    {
        BooksRegister books;
        BindingListView<Book> booksView; 
        public Form1()
        {
            InitializeComponent();
            statusStrip1.Text = Convert.ToString(DateTime.Now);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //string author, string name, string publication, int publicationYear, DateTime issueDate, int returnPeriod)
            XDocument xDocument = XDocument.Load("config.xml");
            IEnumerable<Book> booksSequence = xDocument.Root.Elements("Book").Select(item => new Book(
            item.Element("Author").Value,
            item.Element("Name").Value,
            item.Element("Publication").Value,
            (int)item.Element("PublicationYear"),
            (DateTime)item.Element("IssueDate"),
            (int)item.Element("ReturnPeriod"),
            (bool)item.Element("IsReturned")
        )); 
            books = new BooksRegister(booksSequence);

            //foreach (Book book in books) 
            //     Console.WriteLine(book.Name);   

            booksView = new BindingListView<Book>(books.Books);
            bindingSource1.DataSource = booksView;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveData();

        }

        private void SaveData()
        {
            XDocument xDocument = new XDocument();
            IEnumerable<XElement> booksSequence = books.Select(item => new XElement("Book",
            new XElement("Author", item.Author),
            new XElement("Name", item.Name),
            new XElement("Publication", item.Publication),
            new XElement("PublicationYear", item.PublicationYear),
            new XElement("IssueDate", item.IssueDate),
            new XElement("ReturnPeriod", item.ReturnPeriod),
            new XElement("IsReturned", item.IsReturned)
        ));
            xDocument.Add(new XElement("Books", booksSequence));
            xDocument.Save("config.xml");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripTextBoxFilter.Text))
            {
                booksView.ApplyFilter(item => item.Name.Contains(toolStripTextBoxFilter.Text));
            }
            else
            {
                booksView.RemoveFilter();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            booksView.ApplyFilter(item => item.IssueDate.AddDays(item.ReturnPeriod) <DateTime.Now && !item.IsReturned);
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            booksView.ApplyFilter(item => item.ReturnPeriod>1);
        }
    }
}
