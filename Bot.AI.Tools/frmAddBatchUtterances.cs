using Microsoft.Cognitive.LUIS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Bot.AI.Tools
{
    public partial class frmAddBatchUtterances : Form
    {
        private const char Delimeter = ';';

        string appId = ConfigurationManager.AppSettings["Luis:ApiId"];
        string subscriptionKey = ConfigurationManager.AppSettings["Luis:SubsciptionKey"];
        string luisUri = ConfigurationManager.AppSettings["Luis:Uri2"];
        string versionId = ConfigurationManager.AppSettings["Luis:VersionId"];
        string region = ConfigurationManager.AppSettings["Luis:Region"];

        List<UtteranceModel> utterances = null;

        public frmAddBatchUtterances()
        {
            InitializeComponent();
        }

        private void btLoadUtteranceList_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileUtterancesList = new OpenFileDialog();

            string tempFolder = Path.GetTempPath();
            openFileUtterancesList.InitialDirectory = tempFolder;
            openFileUtterancesList.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileUtterancesList.FilterIndex = 2;
            openFileUtterancesList.DefaultExt = "csv";
            openFileUtterancesList.Title = "Browse batch intent&utterances file";
            openFileUtterancesList.RestoreDirectory = true;
            openFileUtterancesList.Multiselect = false;

            if (openFileUtterancesList.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wrongMatchingKB = string.Empty;

                    txtUtteranceListFile.Text = openFileUtterancesList.FileName;
                    myStream = File.OpenRead(txtUtteranceListFile.Text);

                    if (myStream != null)
                    {
                        utterances = new List<UtteranceModel>();
                        using (myStream)
                        {
                            StreamReader streamReader = new StreamReader(myStream);
                            var totalData = streamReader.ReadLine().Split(Delimeter);
                            while (!streamReader.EndOfStream)
                            {
                                totalData = streamReader.ReadLine().Split(Delimeter);

                                utterances.Add(new UtteranceModel() { IntentName = totalData[0], Utterance = totalData[1] });
                            }

                            grdUtterances.DataSource = utterances;
                            grdUtterances.Columns["IntentName"].Width = 250;
                            grdUtterances.Columns["Utterance"].Width = 350;

                            if (grdUtterances.Rows != null && grdUtterances.Rows.Count > 0)
                                grdUtterances.Rows[0].Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    if (ex.InnerException != null)
                    {
                        msg += " innerException: " + ex.InnerException.Message;
                    }

                    MessageBox.Show("Error on File Read: Exception: " + msg);
                }
            }
        }

        private async Task BatchSaveUtterances()
        {          
            if (utterances == null)
            {
                MessageBox.Show("No utterances found");
                return;
            }
            
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = $"{luisUri}/{appId}/versions/{versionId}/examples?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(utterances));

            var json = string.Empty;

            using (var content = new ByteArrayContent(byteData))
            { 
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Batch utterance labeling failed!");
            }
        }

        private async Task TrainLuis()
        {
            var client = new HttpClient();
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = $"{luisUri}/{appId}/versions/{versionId}/train";

            HttpResponseMessage response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Luis training has failed!");
            }
        }        

        private async Task ValidateIntents()
        {
            var client = new LuisClient(appId, subscriptionKey, true, region);
            var testSucceed = false;

            DataTable dt = new DataTable();
            dt.Columns.Add("Utterance");
            dt.Columns.Add("Intent");
            dt.Columns.Add("TestSucceed");

            foreach (var input in utterances)
            {
                testSucceed = false;
                var luisResult = await client.Predict(input.Utterance);
                var ret = luisResult.TopScoringIntent.Name;
                if (ret == input.IntentName)
                {
                    testSucceed = true;
                }
                dt.Rows.Add(input.Utterance, ret, testSucceed);
            }

            grdTestIntents.DataSource = dt;
            grdTestIntents.Columns["Utterance"].Width = 350;
            grdTestIntents.Columns["Intent"].Width = 150;
            grdTestIntents.Columns["TestSucceed"].Width = 100;

            if (grdTestIntents.Rows != null && grdTestIntents.Rows.Count > 0)
                grdTestIntents.Rows[0].Selected = true;
        }

        private async void btAddBatch_Click(object sender, EventArgs e)
        {
            await BatchSaveUtterances();
            await TrainLuis();
            await ValidateIntents();
        }
    }
}
