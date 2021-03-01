using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyLibrary.AppLayer;

namespace LibraryTests
{
    [TestClass]
    public class cLibraryDataParserTest
    {
        [TestMethod]
        public void CheckBookNumber() // this simple test checks book count after insert and after deleting book
        {
            Library LibrarySnapshot = new Library();
            LibrarySnapshot.LoadSnapshot();
            Book newBook = new Book
            {
                Author = "testAuthor",
                Name = "TestName",
                Borrowed = new User
                {
                    FirstName = "testUserName",
                    LastName = "testUserLastName",
                    PasswordPrivate = "testUserPassword",
                    Login = "testUserPassword"
                }

            };

            int countBefore = LibrarySnapshot.library.Books.Count;

            LibrarySnapshot.AddBookToSnapshot(newBook);
            LibrarySnapshot.SaveSnapshotToFile("TestUnitLibraryTest.xml");
            LibrarySnapshot.LoadSnapshot("TestUnitLibraryTest.xml");
            int countAfter= LibrarySnapshot.library.Books.Count;
            Assert.AreEqual(countBefore + 1, countAfter);

            LibrarySnapshot.RemoveBookFromSnapshot(newBook);
            countAfter = LibrarySnapshot.library.Books.Count;
            Assert.AreEqual(countBefore, countAfter);






        }
    }
}
