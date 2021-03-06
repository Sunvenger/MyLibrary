﻿using System;
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

        public void AddBookToSnapshot(Book bookToAdd)
        {
            int newId=1;
            bookToAdd.Id = newId;
            if (library.Books.Count!=0)
            newId = (from b in library.Books select b.Id).Max() + 1;
            cBook newBook = new cBook
            {
                Id = newId,
                Name = bookToAdd.Name,
                Author = bookToAdd.Author,
                Borrowed = null
            };

            library.AddBookToSnapshot(newBook);

        }

        public void RemoveBookFromSnapshot(Book bookToRemove)
        {

            library.RemoveBook(bookToRemove.Id);
        }

        public void EditBook(Book book)
        {
            string borrowedTime = "";
            if (book.Borrowed == null)
                book.Borrowed = new User();

            if (book.BorrowedFrom != null) borrowedTime = book.BorrowedFrom.ToString();

            cBook newBook = new cBook
            {
                Id = book.Id,
                Author = book.Author,
                Borrowed = new cBorrowed
                {
                    FirstName = book.Borrowed.FirstName,
                    LastName = book.Borrowed.LastName,
                    From = borrowedTime

                },
                Name = book.Name,
            };
            library.EditBook(newBook);
        }

        public void BorrowBook(int bookId, User userToAssign) 
        {

            library.BorrowBook(bookId, userToAssign.FirstName, userToAssign.LastName, DateTime.Now);
        }


        public void RemoveBookFromSnapshot(int bookToRemoveId)
        {

            library.RemoveBook(bookToRemoveId);
        }

        public List<Book> GetAllBooks(Users users)
        {

            List<Book> result = new List<Book>();
 
            foreach (cBook book in library.Books)
            {
                User borrowed = null;
                DateTime? borrowedFrom = null;
                if (book.Borrowed != null)
                {
                     borrowed = users.GetUserByName(book.Borrowed.FirstName, book.Borrowed.LastName);
                    try
                    { 
                        borrowedFrom = DateTime.Parse(book.Borrowed.From);
                    }
                    catch
                    {
                        borrowedFrom = null;

                    }
                }

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
                        BorrowedFrom = borrowedFrom,
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

        public static void InitLibrary()
        {
            cLibrary.Init();
        }

        public void LoadSnapshot(string filename = "Library.xml")
        {
            library = library.LoadSnapshotFromFile(filename);
        }

        public List<Book> GetAvailableBooks(Users users)
        {
            var books = GetAllBooks(users);

            var result = from b in books where b.Borrowed ==null select b;

            return result.ToList();
        }

        public List<Book> GetBooksByBorrow(int borrowUserId, Users users)
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

        public void SaveSnapshotToFile(string fileName)
        {
            library.SaveSnapshotToFile(fileName);
        }

        public void RemoveBooksFromSnapshot(List<int> idsToRemove)
        {
            library.RemoveBooks(idsToRemove);
        }

        public void ReturnBook(int id)
        {
            library.ReturnBook(id);

        }
    }
}
