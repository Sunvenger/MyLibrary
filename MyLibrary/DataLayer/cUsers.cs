using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace MyLibrary.DataLayer
{
    [XmlRoot("Users")]
    public class cUsers
    {

        [XmlElement("User")]
        public List<cUser> Users { get; set; }
        public StreamProvider UsersStreamProvider { get; set; }

        public cUsers() 
        {
            UsersStreamProvider = new StreamProvider();
        }

        public void GetUserStreamFromXML(String filename = "Users.xml")
        {
            UsersStreamProvider.LoadStream(filename);
            XmlDocument doc = new XmlDocument();
        }
        public static cUsers GetUsers()
        {

            String rawData;

            XmlDocument doc = new XmlDocument();



            try
            {
                doc.Load("Users.xml");
                rawData = doc.InnerXml;
                XmlSerializer serializer = new XmlSerializer(typeof(cUsers));
                using (TextReader reader = new StringReader(rawData))
                {
                    cUsers result = (cUsers)serializer.Deserialize(reader);
                    return result;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public cUser GetUserByName(String FirstName,  String Lastname)
        {
            var users = Users;

            cUser result = (from usr in users 
                            where usr.FirstName == FirstName && usr.LastName == Lastname
                            select usr).FirstOrDefault();
            return result;
        }


        public cUsers GetUsersFromSnapshot()
        {

            String rawData;

            XmlDocument doc = new XmlDocument();



            try
            {

                UsersStreamProvider.StreamSnapshot.Position = 0;
                doc.Load(UsersStreamProvider.StreamSnapshot);
                rawData = doc.InnerXml;
                XmlSerializer serializer = new XmlSerializer(typeof(cUsers));
                using (TextReader reader = new StringReader(rawData))
                {
                    cUsers result = (cUsers)serializer.Deserialize(reader);
                    result.UsersStreamProvider = UsersStreamProvider;
                    return result;
                }
               
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void SaveUserSnapshot(string filename)
        {
            XmlDocument doc = new XmlDocument();
            UsersStreamProvider.StreamSnapshot.Position = 0;
            doc.Load(UsersStreamProvider.StreamSnapshot);
            String rawData;
            rawData = doc.InnerXml;

            using (StreamWriter sr = new StreamWriter(filename))
            {
                sr.Write(rawData);
            }
            

        }
        public void AddUser(cUser newUser)
        {
            var users = Users;

            if ((from usr in users where usr.Login == newUser.Login select usr.Id).ToList().Count > 0)
                throw new IOException("Login already exists in xml file");


            List<int> IDs = (from u in users
                             select Convert.ToInt32(u.Id)).ToList();  // generate new ID
            int newId;
            if (IDs.Count == 0) newId = 1;
            else
            {
                newId = IDs.Max();
                newUser.Id = newId + 1;
            }
            XmlDocument doc = new XmlDocument();
            UsersStreamProvider.StreamSnapshot.Position = 0;
            doc.Load(UsersStreamProvider.StreamSnapshot);
            XmlNode root = doc.DocumentElement;
            XmlElement newUserElement = doc.CreateElement("User");
            XmlAttribute idAttr = doc.CreateAttribute("id");
            idAttr.Value = $"{newUser.Id}";
            newUserElement.Attributes.Append(idAttr);

            XmlElement newUserLoginElement = doc.CreateElement("Login");
            newUserLoginElement.InnerText = $"{newUser.Login}";
            newUserElement.AppendChild(newUserLoginElement);

            XmlElement newUserFNameElement = doc.CreateElement("FirstName");
            newUserFNameElement.InnerText = $"{newUser.FirstName}";
            newUserElement.AppendChild(newUserFNameElement);

            XmlElement newUserLNameElement = doc.CreateElement("LastName");
            newUserLNameElement.InnerText = $"{newUser.LastName}";
            newUserElement.AppendChild(newUserLNameElement);


            XmlElement newUserPasswordElement = doc.CreateElement("Password");
            newUserPasswordElement.InnerText = $"{newUser.PasswordPublic}";
            newUserElement.AppendChild(newUserPasswordElement);

            root.AppendChild(newUserElement);
            UsersStreamProvider.StreamSnapshot.Position = 0;
            doc.Save(UsersStreamProvider.StreamSnapshot);

            Users = GetUsersFromSnapshot().Users;





        }


    }
}
