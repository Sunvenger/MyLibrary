using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DataLayer;
namespace MyLibrary.AppLayer
{
    public class Book
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public User Borrowed { get; set; }
        public DateTime? BorrowedFrom { get; set; }
        public static List<Book> GetAllBooks(Library lib, Users users)
        {
            var library = cLibrary.LoadLibrary();
            List<Book> result = new List<Book>();

            foreach (cBook book in library.Books)
            {
                Book newBook = new Book
                {
                    Author = book.Author,
                    Name = book.Name,
                    Borrowed = new User
                    {
                        Id = 0,
                        FirstName = book.Borrowed.FirstName,
                        LastName = book.Borrowed.LastName,
                    },

                    Id = book.Id
                };
                try
                {
                    newBook.BorrowedFrom = DateTime.Parse(book.Borrowed.From);
                }
                catch 
                {
                    newBook.BorrowedFrom = null;
                }

                result.Add(newBook);
            }



            return result;
        }


        internal static void InitLibrary()
        {
            cLibrary.Init();
        }
    }
}
