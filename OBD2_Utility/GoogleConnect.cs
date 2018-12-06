using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public static class GoogleConnect
    {

        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets Test Run ";

        public static SheetsService connectToGoogle()
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

        public static List<List<Object>> retreiveData(String rng, String dataType, String spreadSheet, SheetsService service)
        {

            String range = "Sheet1!" + rng;
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = service.Spreadsheets.Values.Get(spreadSheet, range);
            ValueRange response = getRequest.Execute();
            IList<IList<Object>> values = response.Values;

            List<List<Object>> results = new List<List<Object>>();

            int index = 1;

            foreach (List<Object> list in values)
            {
                if (index != 1)
                {
                    String data = (String)list[1];
                    String[] splitData = data.Split('-');

                    if (validResult(splitData))
                    {
                        results.Add(list);
                    }
                    index++;
                }
                else
                {
                    index = 2;
                }
            }

            return results;

        }

        public static String[] retreiveMostRecentData(String rng, String spreadSheet, SheetsService service)
        {
            String range = "Sheet1!" + rng;
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = service.Spreadsheets.Values.Get(spreadSheet, range);
            ValueRange response = getRequest.Execute();
            IList<IList<Object>> values = response.Values;

            List<List<Object>> results = new List<List<Object>>();

            String[] splitData;

            // DATA STRUCTRE
            // 1st bytes: 7E8
            // 1st 2 bytes: RPM data
            // 2nd 2 bytes: SPEED data
            // 3rd 2 bytes: FUEL data
            // 4th 2 bytes: TEMP data

            foreach (List<Object> list in values.Reverse<IList<Object>>())
            {

                    String data = (String)list[1];
                    splitData = data.Split('-');

                    if (validResult(splitData))
                    {
                        return splitData;
                    }

                   
                
            }

            splitData = null;
            return splitData;
                
                

        }

        public static List<List<Object>> retrieveLoginData(String rng, String spreadSheet, SheetsService service)
        {
            String range = "Sheet1!" + rng;
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = service.Spreadsheets.Values.Get(spreadSheet, range);
            ValueRange response = getRequest.Execute();
            IList<IList<Object>> values = response.Values;

            List<List<Object>> results = new List<List<Object>>();

            int index = 1;

            foreach (List<Object> list in values)
            {
                if(index != 1)
                {
                    results.Add(list);
                }
                index++;
            }

            return results;
        }

        

        public static void addUser(String rng, String spreadSheet, SheetsService service)
        {

        }

        public static void updateData(String msg, String rng, String spreadSheet, SheetsService service)
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

        public static void massUpdateData(String msg, List<String> ranges, String spreadSheet, SheetsService service)
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

        public static bool validResult(String[] result)
        {
            if (result.Length == 9 && result[0].Equals("7e8")) 
            {
                return true;
            } else
            {
                return false;
            }

        }


        public static String convertToPid(String dataType)
        {
            if(dataType == "RPM")
            {
                return "c";
            }

            else if(dataType == "SPEED")
            {
                return "d";
            }

            else if(dataType == "TEMP")
            {
                return "5c";
            }

            else if(dataType == "FUEL")
            {
                return "2f";
            }

            else if(dataType == "ODOMETER")
            {
                return "a5";
            }

            return "";
        }
    }
}
