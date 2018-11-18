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

            String spreadSheetID = "1VPuLBGybTZU2DLpzTosy2yr6TYtsfdltVDREBnBmb2M";
            SheetsService service = GoogleConnect.connectToGoogle();
            List<List<Object>> google_results = GoogleConnect.retrieveLoginData("A:B", spreadSheetID, service);

            foreach(List<Object> data in google_results)
            {
                if(data[0].Equals(username) && data[1].Equals(password))
                {
                    displayBox.Text = "Loading...";

                    // Creates a new instance of the application window and passes data read from google sheet.
                    this.Hide();
                    UofUOBD2Utility application = new UofUOBD2Utility();
                    application.ShowDialog();
                }
            }

            displayBox.Text = "Incorrect Credentials";

        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            String username = usrBox.Text;
            String password = pwdBox.Text;

            if(username.Equals("") || password.Equals(""))
            {
                displayBox.Text = "Can not provide blank password or username";
            } else
            {
                String spreadSheetID = "1VPuLBGybTZU2DLpzTosy2yr6TYtsfdltVDREBnBmb2M";
                SheetsService service = GoogleConnect.connectToGoogle();
                List<List<Object>> google_results = GoogleConnect.retrieveLoginData("A:B", spreadSheetID, service);

                int nextEmptyCell = google_results.Count() + 2;

                GoogleConnect.updateData(username, "A" + nextEmptyCell, spreadSheetID, service);
                GoogleConnect.updateData(password, "B" + nextEmptyCell, spreadSheetID, service);
            }
        }
    }  
}
