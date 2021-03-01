using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DataLayer;

namespace MyLibrary.AppLayer
{

    public class Users
    {
        public cUsers DataUsers { set; get; }
        public List<User> AppUsers { set; get; }
        public Users()
        {
            DataUsers = new cUsers();
        }
        public void LoadXmlStreamSnapshot(String filename = "Users.xml")
        {
            DataUsers.GetUserStreamFromXML(filename);

        }

        internal void LoadFromSnapshot()
        {
            DataUsers.GetUsersFromSnapshot();
        }

        public void SaveSnapshotToFile(String filename)
        {
            DataUsers.SaveUserSnapshot(filename);
        }
        public void AddUserToSnapshot(User newUser)
        {
            cUser newDataUser = new cUser
            {
                Id = 0, //not necessary - generated in data layer
                Login = newUser.Login,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PasswordPublic = SecurityUtils.EncryptPlainTextToCipherText(newUser.PasswordPrivate)

            };

            DataUsers.AddUser(newDataUser);

        }


        public User GetUserByName(String FirstName, String LastName)
        {
            cUser user = DataUsers.GetUserByName(FirstName, LastName);
            if (user != null)
            {
                return new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Login = user.Login,
                    PasswordPrivate = SecurityUtils.DecryptCipherTextToPlainText(user.PasswordPublic)
                };
            }
            else
            { return null; }

        }

        


        public List<User> GetUsers()
        {
            DataUsers = DataUsers.GetUsersFromSnapshot();
            List<User> result = new List<User>();

            if (DataUsers is null)
            { return null; }
            foreach (cUser usr in DataUsers.Users)
            {


                result.Add(new User
                {
                    Login = usr.Login,
                    PasswordPrivate = SecurityUtils.DecryptCipherTextToPlainText(usr.PasswordPublic),
                    FirstName = usr.FirstName,
                    LastName = usr.LastName,
                    Id = Convert.ToInt32(usr.Id),
                });




            }
            AppUsers = result;
            return result;


        }

        internal static void InitUsers()
        {
            cUsers.Init();
        }
    }
}
