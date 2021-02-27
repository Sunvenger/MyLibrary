using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace MyLibrary.DataLayer
{

    public class cBook
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public String Name { get; set; }

        [XmlElement("Author")]
        public String Author { get; set; }

        [XmlElement("Borrowed")]
        public cBorrowed Borrowed { get; set; }


    }
}
