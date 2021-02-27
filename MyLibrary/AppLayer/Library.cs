using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyLibrary.DataLayer;
namespace MyLibrary.AppLayer
{

    public class Library
    {
        public cLibrary library;

        public Library()
        {
            library = new cLibrary();
        }



        public List<Book> GetAllBooks(Users users)
        {

            List<Book> result = new List<Book>();
 
            foreach (cBook book in library.Books)
            {
                User borrowed = users.GetUserByName(book.Borrowed.FirstName, book.Borrowed.LastName);
                if (borrowed != null)
                {
                    result.Add(new Book
                    {
                        Author = book.Author,
                        Name = book.Name,
                        Borrowed = new User
                        {
                            Id = borrowed.Id,
                            FirstName = borrowed.FirstName,
                            LastName = borrowed.LastName,
                            Login = borrowed.Login,
                            PasswordPrivate = borrowed.PasswordPrivate
                        },
                        Id = book.Id
                    });
                }
                else
                {
                    result.Add(new Book
                    {
                        Author = book.Author,
                        Name = book.Name,
                        Borrowed = null,
                        Id = book.Id
                    });
                }

            }



            return result;
        }



        internal void RefreshFromFile()
        {
            library = library.RefreshLibFromFile();
        }

        internal List<Book> GetAvailableBooks(Users users)
        {
            var books = GetAllBooks(users);

            var result = from b in books where b.Borrowed ==null select b;

            return result.ToList();
        }

        internal List<Book> GetBooksByBorrow(int borrowUserId, Users users)
        {
            var books = GetAllBooks(users);
            var result = new List<Book>();
            User userToVerifyBorrow = (from usr in users.AppUsers
                                       where usr.Id == borrowUserId
                                       select usr).FirstOrDefault();

            var borrowedBooks = (from b in books where b.Borrowed != null select b).ToList();
            result = (from b in borrowedBooks
                      where b.Borrowed.FirstName == userToVerifyBorrow.FirstName &&
                      b.Borrowed.LastName == userToVerifyBorrow.LastName
                      select b).ToList();
            return result;
        }
    }
}
