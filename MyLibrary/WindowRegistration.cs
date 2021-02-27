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
    public partial class WindowRegistration : Form
    {
        public Users UsersSnapshot { get; set; }
        public WindowRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text.Length > 0 && tbPassword.Text.Length > SecurityUtils.MinimumPasswordLength &&
                tbFirstName.Text.Length> 0 && tbLastName.Text.Length > 0)

            {
                User newUser = new User {
                    Login = tbLogin.Text,
                    PasswordPrivate = tbPassword.Text,
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text
                    };
                try
                {
                    UsersSnapshot.AddUserToSnapshot(newUser);
                    this.Close();

                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show($"Všetky polia sú povinné a heslo-aspoň {SecurityUtils.MinimumPasswordLength} znakov");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
