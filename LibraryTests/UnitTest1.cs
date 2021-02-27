using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyLibrary.DataLayer;

namespace LibraryTests
{
    [TestClass]
    public class cLibraryDataParserTest
    {
        [TestMethod]
        public void CheckBookNumber()
        {
            cLibrary lib = cLibrary.LoadLibrary();

            Assert.AreEqual(6, lib.Books.Count);
        }
    }
}
