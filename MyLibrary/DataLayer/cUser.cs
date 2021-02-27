using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
namespace MyLibrary.DataLayer
{

    public class cUser
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("Login")]
        public string Login { get; set; }
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Password")]
        public string PasswordPublic { get; set; }

        public void AddToXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Users.xml");
        }
    }
}
