using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Field_Service_Toolkit
{
    public partial class Logon : Form
    {
        public Logon()
        {            
            InitializeComponent();
            lblWelcome.Text += $@" {UserName.ToUpper()}";
        }

        private static string userName = WindowsIdentity.GetCurrent().Name.Split('\\')[1],
            password,
            domain = WindowsIdentity.GetCurrent().Name.Split('\\')[0];

        public string UserName
        {
            get { return userName; }
            private set { userName = value; }
        }

        public string? Password
        {
            get { return password; }
            private set { password = value; }
        }

        public string Domain
        {
            get { return domain; }
            private set { domain = value; }
        }        

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Checks if the user input is valid, if so it opens the toolkit form.

            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter a password");
            }
            else
            {
                Password = txtPassword.Text;
                if(AuthenticateCredentials(UserName, Password, Domain))
                { 
                    Toolkit toolkit = new Toolkit();
                    this.Hide();
                    toolkit.Show();
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static bool AuthenticateCredentials(string userName, string password, string domain)
        {
            //Takes the user input and authenticates it with the local domain.

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
            {
                return context.ValidateCredentials(userName, password);
            }
        }
    }
}
