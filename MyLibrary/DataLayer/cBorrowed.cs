using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace MyLibrary.DataLayer
{

    public class cBorrowed
    {
        [XmlElement("FirstName")]
        public String FirstName { get; set; }

        [XmlElement("LastName")]
        public String LastName { get; set; }

        [XmlElement("From")]
        public String From { get; set; }
    }
}
