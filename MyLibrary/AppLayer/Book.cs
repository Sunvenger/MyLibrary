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

        public static List<Book> GetAllBooks(Library lib, Users users)
        {
            var library = cLibrary.LoadLibrary();
            List<Book> result = new List<Book>();

            foreach (cBook book in library.Books)
            {
                result.Add(new Book
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
                });
            }



            return result;
        }
        /*public static List<Book> GetBookByBorrow(User borrowUser)
        {
            var books = GetAllBooks();
            var result = new List<Book>();

            result = (from b in books
                      where b.Borrowed.FirstName == borrowUser.FirstName &&
                      b.Borrowed.LastName == borrowUser.LastName
                      select b).ToList();
            return result;
        }*/
        /*
        public static List<Book> GetAvailableBooks(Library lib = null)
        {
            var books = GetAllBooks();
            var result = from b in books where b.Borrowed.FirstName == "" && b.Borrowed.LastName == "" select b;

            return result.ToList();

        }*/

        internal static void InitLibrary()
        {
            cLibrary.Init();
        }
    }
}
