using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.AppLayer;
namespace MyLibrary.PresentationLayer
{
    public class pBook
    {
        public int Id { get; set; }
        public String Názov { get; set; }
        public String Autor { get; set; }
        public String Požičané  { get; set; }
        public String PožičanéOd { get; set; }
        public User owner;
        public static List<pBook> GetBooks(Library lib, Users users)
        {
            var books = lib.GetAllBooks(users);


            List<pBook> result = new List<pBook>();
            foreach (Book book in books)
            {

                string požičané;
                if (book.Borrowed != null)
                    požičané = $"{book.Borrowed.FirstName} {book.Borrowed.LastName}";
                else
                    požičané = "Voľné";

                result.Add(
                    new pBook
                    {
                        Id = book.Id,
                        Názov = book.Name,
                        Autor = book.Author,
                        Požičané = požičané,
                        owner = book.Borrowed,
                        PožičanéOd = book.BorrowedFrom.ToString(),
                    }
                ) ;
            }
            return result;

        }
        /*
        public static List<pBook> GetBooks()
        {
            var books = lib.GetAllBooks();
            List<pBook> result = new List<pBook>();
            foreach (Book book in books)
            {
                string požičané = $"{book.Borrowed.FirstName} {book.Borrowed.LastName}";
                result.Add(
                    new pBook
                    {
                        Id = book.Id,
                        Názov = book.Name,
                        Autor = book.Author,
                        Požičané = požičané,
                    }
                );
            }
            return result;

        }*/
        public static List<pBook> GetAvailableBooks(Library lib, Users users)
        {
            
            List<Book> books;
            books = lib.GetAvailableBooks(users);


            List<pBook> result = new List<pBook>();
            foreach (Book b in books)
            {
                result.Add(new pBook
                {
                    Autor = b.Author,
                    Názov = b.Name,
                    Požičané = "Nie",
                    Id = b.Id
                });

            }

            return result;
        }



        public static List<pBook> GetBookByBorrow(User owner, Library lib, Users users)
        {
            var books = lib.GetBooksByBorrow(owner.Id, users);

            

            List<pBook> result = new List<pBook>();
            foreach (Book b in books)
            {
                result.Add(new pBook
                {
                    Autor = b.Author,
                    Názov = b.Name,
                    Požičané = "Máte požičané",
                    Id = b.Id

                });

            }

            return result;


        }

    }
    
}
