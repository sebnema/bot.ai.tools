using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;
using Microsoft;
using Bot.AI.Tools.Helpers;
using Bot.AI.Tools.Interfaces;
using Bot.AI.Tools.KbSearch;

namespace Bot.AI.Tools
{
    public partial class frmUtterancesTranslatorTest : Form
    {
        private readonly string luisUri = ConfigurationManager.AppSettings["Luis:Uri"];
        private readonly string luisAppId = ConfigurationManager.AppSettings["Luis:ApiId"];
        private readonly string luisSubsciptionKey = ConfigurationManager.AppSettings["Luis:SubsciptionKey"];
        private readonly string translateAccountKey = ConfigurationManager.AppSettings["Translate:AccountKey"];
        private readonly string translateUri = ConfigurationManager.AppSettings["Translate:Uri"];
        //static string headerValue; //used for auth in http header

        public frmUtterancesTranslatorTest()
        {
            InitializeComponent();
            GetIndexes();
        }

        private void GetIndexes()
        {
            cmdIndexNames.DataSource = CommonHelper.GetIndexes();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ofdSource.ShowDialog();
            txtSource.Text = ofdSource.FileName;
        }

        private string Translate(string textToTranslate, string toLang, string fromLang)
        {
            var serviceRootUri =
                   new Uri(translateUri);

            // the TranslatorContainer gives us access to the Microsoft Translator services
            TranslatorContainer tc = new TranslatorContainer(serviceRootUri);

            // Give the TranslatorContainer access to your subscription
            tc.Credentials = new NetworkCredential(translateAccountKey, translateAccountKey);

            var translateQuery = tc.Translate(textToTranslate, toLang, fromLang);
            var translationResults = translateQuery.Execute().ToList();

            // Verify there was a result 
            if (translationResults.Count() <= 0)
            {
                return null;
            }

            // In case there were multiple results, pick the first one 
            var translationResult = translationResults.First();
            return translationResult.Text;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            StringBuilder sb = new StringBuilder();

            var sourceFileLines = File.ReadAllLines(txtSource.Text);
            string strClusterExists = "Exists";
            string searchField = "";
            string intentName = string.Empty;
            string KBCluster = string.Empty;
            //TODO: Add header to geenratedfile

            // get index name from drop down list
            string indexName = string.Empty;

            if (cmdIndexNames.SelectedIndex >= 0)
            {
                indexName = cmdIndexNames.SelectedValue.ToString();
            }

            int i = 0;
            //TODO:Adding validation to check source file columns
            foreach (var lineItem in sourceFileLines)
            {
                searchField = string.Empty;
                KBCluster = string.Empty;
                i++;
                if (chkTestSpecificLine.Checked && i.ToString() != txtLineNumber.Text)
                {
                    continue;
                }

                var SelectedCluster = string.Empty;
                var strFieldsList = lineItem.Split('\t');
                //TODO:To call translation asynchronously
                var translationResult = GetQuestionToTest(strFieldsList[2]);


                if (rbTestLUISAndSearch.Checked || rbTestFullSenario.Checked)
                {
                    //Now we need to check luis api to get the related intent name
                    var luisApi = string.Format("{0}?id={1}&subscription-key={2}&q={3}&timezoneOffset=0.0", luisUri, luisAppId, luisSubsciptionKey, HttpUtility.UrlEncode(translationResult));

                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(luisApi);
                        if (response.IsSuccessStatusCode)
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            var rootResult = JsonConvert.DeserializeObject<RootObject>(result);

                            if (rootResult.intents != null && rootResult.intents.Count > 0)
                            {
                                intentName = rootResult.intents.First().intent;
                                KBCluster = (rootResult.entities != null && rootResult.entities.Where(x => x.type == "KBCluster").Count() > 0) ? rootResult.entities.Where(x => x.type == "KBCluster").First().entity : "";
                            }
                            else
                            {
                                intentName = string.Empty;
                            }

                        }
                    }

                }

                if (rbTestFullSenario.Checked && !string.IsNullOrEmpty(KBCluster))
                {
                    searchField = "cluster_en";
                    translationResult = KBCluster;
                }
                
                //translationResult = AzureSearchHelper.GetSearchQuery(translationResult);
                //check in Azure search if there is any match of translated question with searh field cluster_en
                IAzureSearchClient azSrchClient = new AzureSearchClient(indexName);
                var sr = await azSrchClient.GetSearchResults(translationResult, searchField);

                strClusterExists = "Not Found";

                int index = 0;

                foreach (var searchResults in sr.Results)
                {
                    index++;
                    if (searchResults.Document.TopicEnglish.Trim() == strFieldsList[1].Trim())
                    {
                        strClusterExists = "Found";
                        break;
                    }
                }

                if (strClusterExists == "Not Found")
                {
                    index = 0;
                }                

                //Add record to generated file
                sb.AppendLine(string.Concat(lineItem, '\t', translationResult, '\t', strClusterExists, '\t', intentName, '\t', index.ToString()));

                if (chkTestSpecificLine.Checked)
                {
                    break;
                }
            }

            try
            {
                File.WriteAllText(txtDestination.Text, sb.ToString(), Encoding.Unicode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("The file is not created", ex));
                return;
            }
            finally
            {
                button2.Enabled = true;
            }

            MessageBox.Show("The file is generated");
        }



        private string GetQuestionToTest(string OriginalQuestion)
        {

            if (chkTranslateToEnglish.Checked)
            {
                return Translate(OriginalQuestion, "en", "ar");  //2 index arabic question   
            }
            else
            {
                return OriginalQuestion;
            }
        }


    }
}
