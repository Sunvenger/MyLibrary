using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary.AppLayer;
namespace MyLibrary
{

    public partial class WindowLogin : Form
    {
        public User CurrentUser;
        public Users UsersSnapshot { get; set; }
        public WindowRegistration windowRegistration;
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text.Length > 0 && tbPassword.Text.Length > 0)
            {
                UsersSnapshot.GetUsers();
                var users = UsersSnapshot.AppUsers;

                if (users is null) MessageBox.Show("Zoznam používateľov chýba alebo je poškodený");

                var authorizedUser = (from usr in users
                                      where usr.Login == tbLogin.Text &&
                                      usr.PasswordPrivate == tbPassword.Text
                                      select usr).FirstOrDefault<User>();

                CurrentUser = authorizedUser;
                if (CurrentUser is null)
                {
                    MessageBox.Show("Nesprávne meno alebo heslo");
                }
                else this.Close(); //login successful ; user stored in CurrentUser


            }
            else MessageBox.Show("Vaše prihlásenie musí obsahovať meno a heslo");




        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            windowRegistration = new WindowRegistration();
            windowRegistration.UsersSnapshot = UsersSnapshot;
            windowRegistration.ShowDialog();

        }
    }
}
