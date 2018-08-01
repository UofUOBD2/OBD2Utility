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

        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets Test Run ";

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

            // The spreadsheet we want to connect to
            String spreadsheetId = "1buoculiAlX_jz9m9Tt8Y9YYF6LPOPOLEGSVmbB5bSHU";

            // Creates the object we will use to interact with spreadsheets
            SheetsService service = connectToGoogle();
            

            // Update the user on the status of the application
            displayBox.Text = "Downloading latest data from the cloud...";

            // Reads current data from the google spread sheet
            List<List<Object>> results = retreiveData("A:H", spreadsheetId, service);

            displayBox.Text = "Loading...";

            // Creates a new instance of the application window and passes data read from google sheet.
            this.Hide();
            UofUOBD2Utility application = new UofUOBD2Utility(results);
            application.ShowDialog();

        }

        private static List<List<Object>> retreiveData(String rng, String spreadSheet, SheetsService service)
        {

            String range = "Sheet1!" + rng;
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = service.Spreadsheets.Values.Get(spreadSheet, range);
            ValueRange response = getRequest.Execute();
            IList<IList<Object>> values = response.Values;

            List<List<Object>> results = new List<List<Object>>();

            int index =  1;

            List<String> cells_to_update = new List<String>();

            foreach(List<Object> list in values){

                if (index != 1)
                {

                    if (!(list.Count == 0))
                    {
                        if (!(list.Last<Object>().Equals("X")))
                        {
                            String cell = "H" + index;
                            cells_to_update.Add(cell);
                        }
                    }

                    results.Add(list);
                    index++;

                } else
                {
                    index = 2;
                }
            }

            massUpdateData("X", cells_to_update, spreadSheet, service);
            return results;

        }

        private static void updateData(String msg, String rng, String spreadSheet, SheetsService service)
        {
            ValueRange body = new ValueRange();
            body.MajorDimension = "ROWS";
            String updateRange = "Sheet1!" + rng;
            var oblist = new List<object>() { msg };
            body.Values = new List<IList<object>> { oblist };

            SpreadsheetsResource.ValuesResource.UpdateRequest updateRequest = service.Spreadsheets.Values.Update(body, spreadSheet, updateRange);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            UpdateValuesResponse result = updateRequest.Execute();

        }

        private static void massUpdateData(String msg, List<String> ranges, String spreadSheet, SheetsService service)
        {
            foreach (String rng in ranges)
            {
                ValueRange body = new ValueRange();
                body.MajorDimension = "ROWS";
                String updateRange = "Sheet1!" + rng;
                var oblist = new List<object>() { msg };
                body.Values = new List<IList<object>> { oblist };

                SpreadsheetsResource.ValuesResource.UpdateRequest updateRequest = service.Spreadsheets.Values.Update(body, spreadSheet, updateRange);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                UpdateValuesResponse result = updateRequest.Execute();
            }

        }

        private static SheetsService connectToGoogle()
        {

            UserCredential credential;

            // Gets authorization to access and modify google sheets
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {

                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None,
                    new FileDataStore(credPath, true)
                    ).Result;
                Console.WriteLine("Credential file saved to: " + credPath);

            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // This object is used to interact with Google API
            return service;

        }
    }  
}
