using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
namespace MyLibrary.DataLayer
{
    [XmlRoot("Library")]
    public class cLibrary
    {
        [XmlElement("Book")]
        public List<cBook> Books { get; set; }
        public StreamProvider LibraryProvider { get; set; }

        public cLibrary()
        {
            LibraryProvider = new StreamProvider();
        }

        public cLibrary RefreshLibFromFile()
        {
            String rawData;
            LibraryProvider.LoadStream();
            XmlDocument doc = new XmlDocument();
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
        public static cLibrary LoadLibrary()
        {
            String rawData;

            XmlDocument doc = new XmlDocument();

             
            doc.Load("Library.xml");
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

        internal static void Init()
        {
            using (StreamWriter sw = new StreamWriter("Library.xml"))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<Users>");
                sw.WriteLine("</Users>");
            }

        }
    }

}
