using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace MyLibrary.DataLayer
{
    [XmlRoot("Library")]
    public class cLibrary
    {
        [XmlElement("Book")]
        public List<cBook> Books { get; set; }
        [XmlIgnore()]
        public StreamProvider LibraryProvider { get; set; }

        public cLibrary()
        {
            LibraryProvider = new StreamProvider();
        }

        public cLibrary LoadSnapshotFromFile(string filename = "Library.xml")
        {
            String rawData;
            LibraryProvider.LoadStream(filename);
            XmlDocument doc = new XmlDocument();
            LibraryProvider.StreamSnapshot.Position = 0;

            doc.Load(LibraryProvider.StreamSnapshot);
            rawData = doc.InnerXml;
            XmlSerializer serializer = new XmlSerializer(typeof(cLibrary));
            StreamProvider StreamBackup = LibraryProvider;
            try
            {
                using (TextReader reader = new StringReader(rawData))
                {
                    cLibrary result = serializer.Deserialize(reader) as cLibrary;
                    result.LibraryProvider = StreamBackup;
                    return result;
                }
            }
            catch
            {
                return null;
            }

        }

        internal void EditBook(cBook newBook)
        {
            cBook originalBook = (from b in Books where b.Id == newBook.Id select b).First();
            originalBook.Name = newBook.Name;
            originalBook.Author = newBook.Author;
            originalBook.Borrowed = newBook.Borrowed;
            UpdateSnapshotFromDataLayer();
        }

        internal void BorrowBook(int bookId, string firstName, string lastName, DateTime now)
        {

            cBook bookToAssign = (from book in Books where book.Id == bookId select book).First();
            
            if(bookToAssign.Borrowed == null)
            {
                bookToAssign.Borrowed = new cBorrowed(); 
            }
            bookToAssign.Borrowed.FirstName = firstName;
            bookToAssign.Borrowed.LastName = lastName;
            bookToAssign.Borrowed.From = now.ToString();
            UpdateSnapshotFromDataLayer();


        }

        internal void RemoveBook(int id)
        {

            List<cBook> newBookList = (from b in Books
                                       where b.Id != id
                                       select b).ToList(); // construct new lists without original
            Books = newBookList; // replacing original Books container
            UpdateSnapshotFromDataLayer();
        }

        private void UpdateSnapshotFromDataLayer()
        {
            var overrides = new XmlAttributeOverrides();
            var attributes = new XmlAttributes();
            attributes.XmlIgnore = true;
            string plainTextXml;

            using (var sw = new StringWriter())
            {
                var xs = new XmlSerializer(typeof(cLibrary), overrides);
                xs.Serialize(sw, this);
                plainTextXml = sw.ToString();
            }


            XmlDocument newDoc = new XmlDocument();
            newDoc.LoadXml(plainTextXml);
            LibraryProvider.StreamSnapshot = new MemoryStream();
            LibraryProvider.StreamSnapshot.Position = 0;
            newDoc.Save(LibraryProvider.StreamSnapshot);
            LibraryProvider.StreamSnapshot.Position = 0;
        }

        internal void AddBookToSnapshot(cBook newBook)
        {
            Books.Add(newBook);

            var overrides = new XmlAttributeOverrides();
            var attributes = new XmlAttributes();
            attributes.XmlIgnore = true;
            string plainTextXml;
            newBook.Borrowed = new cBorrowed
            {
                FirstName = "",
                LastName = "",
                From = ""

            };
            using (var sw = new StringWriter())
            {
                var xs = new XmlSerializer(typeof(cLibrary), overrides);
                xs.Serialize(sw, this);
                plainTextXml = sw.ToString();
            }

            
            XmlDocument newDoc = new XmlDocument(); 
            newDoc.LoadXml(plainTextXml);
            LibraryProvider.StreamSnapshot = new MemoryStream();
            LibraryProvider.StreamSnapshot.Position = 0;
            newDoc.Save(LibraryProvider.StreamSnapshot);
            LibraryProvider.StreamSnapshot.Position = 0;








        }
        public static cLibrary LoadLibrary(string filename = "Library.xml")
        {
            String rawData;

            XmlDocument doc = new XmlDocument();


            doc.Load(filename);
            rawData = doc.InnerXml;
            XmlSerializer serializer = new XmlSerializer(typeof(cLibrary));
            try
            {
                using (TextReader reader = new StringReader(rawData))
                {
                    cLibrary result = (cLibrary)serializer.Deserialize(reader);
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        internal void ReturnBook(int id)
        {
            cBook BookToReturn = (from b in Books
                                where b.Id == id
                                select b).First();
            BookToReturn.Borrowed = null;
            UpdateSnapshotFromDataLayer();

        }

        internal void RemoveBooks(List<int> idsToRemove)
        {
            var actualBookIds = (from b in Books
                                 where !idsToRemove.Contains(b.Id)
                                 select b.Id).ToList();
            List<cBook> newBookList = (from b in Books
                                       where actualBookIds.Contains(b.Id)
                                       select b).ToList();
            Books = newBookList; // replacing original Books container
            var overrides = new XmlAttributeOverrides();
            var attributes = new XmlAttributes();
            attributes.XmlIgnore = true;
            string plainTextXml;

            using (var sw = new StringWriter())
            {
                var xs = new XmlSerializer(typeof(cLibrary), overrides);
                xs.Serialize(sw, this);
                plainTextXml = sw.ToString();
            }


            XmlDocument newDoc = new XmlDocument();
            newDoc.LoadXml(plainTextXml);
            LibraryProvider.StreamSnapshot.Position = 0;
            LibraryProvider.StreamSnapshot = new MemoryStream();
            newDoc.Save(LibraryProvider.StreamSnapshot);
            LibraryProvider.StreamSnapshot.Position = 0;
        }

        internal static void Init()
        {
            using (StreamWriter sw = new StreamWriter("Library.xml"))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<Library>");
                sw.WriteLine("</Library>");
            }

        }

        internal void SaveSnapshotToFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            LibraryProvider.StreamSnapshot.Position = 0;

            try {
            doc.Load(LibraryProvider.StreamSnapshot);
            }
            catch (Exception e)
            {
                using (StreamWriter sr = new StreamWriter("Invalid_"+fileName))
                {
                    sr.Write(LibraryProvider.StreamSnapshot);
                }
                throw new IOException();
            }
            String rawData;
            
            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", null, null);
            xmldecl.Encoding = "UTF-8";

            XmlElement root = doc.DocumentElement;
            doc.ReplaceChild(xmldecl, doc.FirstChild);
            rawData = doc.InnerXml;
            using (StreamWriter sr = new StreamWriter(fileName))
            {
                sr.Write(rawData);
            }
            LibraryProvider.StreamSnapshot.Position = 0;
        }


    }

}
