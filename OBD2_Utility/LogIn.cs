using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;



namespace OBD2_Utility
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayBox.Text = "Logging in...";
            
            // TODO: Eventually do something with a log in
            String username = usrBox.Text;
            String password = pwdBox.Text;

            
            

            // Update the user on the status of the application
            displayBox.Text = "Checking Credentials";

            displayBox.Text = "Loading...";

            // Creates a new instance of the application window and passes data read from google sheet.
            this.Hide();
            UofUOBD2Utility application = new UofUOBD2Utility();
            application.ShowDialog();

        }

        

        

        

        
    }  
}
