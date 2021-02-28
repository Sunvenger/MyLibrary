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



        public void ChangePassword(User usr, string passwordUnprotected)
        {
            throw new NotImplementedException();
        }

    }


}
