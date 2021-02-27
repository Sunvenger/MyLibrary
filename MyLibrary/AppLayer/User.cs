using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DataLayer;

namespace MyLibrary.AppLayer
{
    public class User
    {
        public String Login { get; set; }
        public String PasswordPrivate { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Id { get; set; }

        public static List<User> GetUsers()
        {
            cUsers users = cUsers.GetUsers();
            List<User> result = new List<User>();

            if (users is null)
            { return null; }
            foreach (cUser usr in users.Users)
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
            return result;
        }

        /*public void SaveToDatabase(Users userSnapshot)
        {
            cUser newDataUser = new cUser
            {
                Id = 0, //not necessary - generated in data layer
                Login = Login,
                FirstName = FirstName,
                LastName = LastName,
                PasswordPublic = SecurityUtils.EncryptPlainTextToCipherText(PasswordPrivate)

            };

            //cUsers.AddUser(newDataUser, userSnapshot.DataUsers);

        }*/


        public void ChangePassword(User usr, string passwordUnprotected)
        {
            throw new NotImplementedException();
        }

    }


}
