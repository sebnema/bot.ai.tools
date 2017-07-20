using Bot.AI.Tools.DocDB;
using Bot.AI.Tools.Helpers;
using Bot.AI.Tools.Interfaces;
using Bot.AI.Tools.KbSearch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Azure.Search.Models;

namespace Bot.AI.Tools
{
    public partial class frmAddTags : Form
    {
        public frmAddTags()
        {
            InitializeComponent();
            GetIndexes();
        }

        private void GetIndexes()
        {
            cmdIndexNames.DataSource = CommonHelper.GetIndexes();
        }

        private void btLoadKBQuestions_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialogKBQuestions = new OpenFileDialog();

            string tempFolder = Path.GetTempPath();
            openFileDialogKBQuestions.InitialDirectory = tempFolder;
            openFileDialogKBQuestions.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialogKBQuestions.FilterIndex = 2;
            openFileDialogKBQuestions.DefaultExt = "csv";
            openFileDialogKBQuestions.Title = "Browse KB question files";
            openFileDialogKBQuestions.RestoreDirectory = true;
            openFileDialogKBQuestions.Multiselect = false;

            if (openFileDialogKBQuestions.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wrongMatchingKB = string.Empty;

                    txtKBQuestionsFile.Text = openFileDialogKBQuestions.FileName;
                    myStream = File.OpenRead(txtKBQuestionsFile.Text);

                    if (myStream != null)
                    {
                        using (myStream)
                        {
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Question");
                            dt.Columns.Add("ExpectedKBArticle");
                            dt.Columns.Add("ExpectedKbId");
                            dt.Columns.Add("MatchingKBArticle");


                            StreamReader streamReader = new StreamReader(myStream);
                            var totalData = streamReader.ReadLine().Split('|');
                            while (!streamReader.EndOfStream)
                            {
                                totalData = streamReader.ReadLine().Split('|');

                                wrongMatchingKB = string.Empty;
                                var expectedKbId = GetKbIdByClusterName(totalData[1]);

                                if(totalData.Length == 3)
                                {
                                    wrongMatchingKB = totalData[2];
                                }

                                dt.Rows.Add(totalData[0], totalData[1], expectedKbId, wrongMatchingKB);
                            }
                            grdFailedKBQuestions.DataSource = dt;

                            grdFailedKBQuestions.Columns["Question"].Width = 350;
                            grdFailedKBQuestions.Columns["ExpectedKBArticle"].Width = 150;
                            grdFailedKBQuestions.Columns["ExpectedKbId"].Width = 5;
                            grdFailedKBQuestions.Columns["MatchingKBArticle"].Width = 150;

                            if (grdFailedKBQuestions.Rows != null && grdFailedKBQuestions.Rows.Count > 0)
                                grdFailedKBQuestions.Rows[0].Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    if(ex.InnerException!= null)
                    {
                        msg += " innerException: "+ ex.InnerException.Message;
                    }

                    MessageBox.Show("Error on File Read: Exception: " + msg);
                }
            }
        }

        private string GetKbIdByClusterName(string clusterName)
        {
            DocDbClient docDbClient = new DocDbClient();
            var expectedArticle = docDbClient.GetDocByKBClusterName(clusterName);

            return expectedArticle?.KbId ?? string.Empty;
        }

        private List<string> GenerateTags(string question)
        {
            string[] exclusion =
                    {
                        "I|You|We|They|He|She|It",
                        "am|is|are|was|were",
                        "have|has|had",
                        "Where|What|Why|When|While|How|How much|How many",
                        "do|does|did",
                        "a|an|the",
                        "can|could|will|would|shall|should|must",
                        "as",
                    };
            var exclusionList = string.Join("|", exclusion);

            //E.g. I have a doubt on my metering as i am getting high amount in my invoice
            // TODO: (SA) Use Cognitive services liguistics api to generate tags
            var pattern = @"\b(" + exclusionList + @")\s";  //w+b(?<!bfox)
            var newQ = Regex.Replace(question, pattern, String.Empty, RegexOptions.IgnoreCase);
            var matches = Regex.Matches(newQ, @"\b(\w+)", RegexOptions.IgnoreCase);

            List<string> tags = new List<string>();
            foreach (Match item in matches)
            {
                tags.Add(item.Value);
            }

            return tags;
        }

        private void btGenerateTags_Click(object sender, EventArgs e)
        {
            if (grdFailedKBQuestions.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.grdFailedKBQuestions.SelectedRows[0];
                var question = row.Cells["Question"].Value.ToString();

                var tags = GenerateTags(question);

                var i = 1;
                panelTags.Controls.Clear();
                lstSelectedTags.Items.Clear();

                foreach (var item in tags)
                {
                    var btn = new Button();
                    btn.Text = item;
                    btn.Click += btGenerateTagButtons_Click;
                    btn.Location = new Point(i * 80, 0);
                    btn.Size = new Size(80, 30);
                    btn.Font = new Font("Arial", 11);
                    btn.ForeColor = Color.Black;
                    btn.BackColor = Color.LightGray;
                    panelTags.Controls.Add(btn);
                    i++;
                }
            }
        }

        List<string> tags = new List<string>();
        private void btGenerateTagButtons_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackColor = Color.LightBlue;
            btn.ForeColor = Color.White;
            tags.Add(btn.Text);
        }

        private void btnAddAsTag_Click(object sender, EventArgs e)
        {
            var item = string.Join(" ", tags.ToArray());
            lstSelectedTags.Items.Add(item);

            //Clear Tag selection
            tags.Clear();
            foreach (var ctrl in panelTags.Controls)
            {
                var btn = (Button)ctrl;
                btn.Font = new Font("Arial", 11);
                btn.ForeColor = Color.Black;
                btn.BackColor = Color.LightGray;
            }
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            if (grdFailedKBQuestions.SelectedRows.Count != 0 && lstSelectedTags.Items.Count > 0)
            {
                DataGridViewRow row = this.grdFailedKBQuestions.SelectedRows[0];
                var question = row.Cells["Question"].Value.ToString();
                var expectedKbId = row.Cells["ExpectedKbId"].Value.ToString();

                //copy tags listbox items to array
                string[] selectedTags = new string[lstSelectedTags.Items.Count];
                lstSelectedTags.Items.CopyTo(selectedTags, 0);

                //saving tags to kb article in docdb
                DocDbClient docDbClient = new DocDbClient();
                var ret = await docDbClient.UpdateTags(expectedKbId, selectedTags);

                if (ret)
                {
                    MessageBox.Show("KB article is saved");
                    return;
                }
                MessageBox.Show("KB article not saved");
            }
        }

        string strClusterExists = "Exists";

        private async void btSearchValidate_Click(object sender, EventArgs e)
        {
            // get index name from drop down list
            string indexName = string.Empty;

            if (cmdIndexNames.SelectedIndex >= 0)
            {
                indexName = cmdIndexNames.SelectedValue.ToString();
            }
            grdSearchValidation.DataSource = null;

            IAzureSearchClient azSrchClient = new AzureSearchClient(indexName);
            //azSrchClient.RunIndexer(indexName);

            strClusterExists = "No";
            int index = 0;

            DocumentSearchResult<KBSearchResult> sr = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Question");
            dt.Columns.Add("ExpectedKBArticle");
            dt.Columns.Add("MatchingKBArticle");
            dt.Columns.Add("IsFound");
            dt.Columns.Add("Order");

            foreach (DataGridViewRow row in this.grdFailedKBQuestions.Rows)
            {
                var question = row.Cells["Question"].Value.ToString();
                var kBArticle = row.Cells["ExpectedKBArticle"].Value.ToString();

                sr = await azSrchClient.GetSearchResults(question);

                foreach (var searchResults in sr.Results)
                {
                    index++;
                    if (searchResults.Document.TopicEnglish.Trim() == kBArticle.Trim())
                    {
                        strClusterExists = "Yes";
                        dt.Rows.Add(question, kBArticle, searchResults.Document.TopicEnglish, strClusterExists, index);
                        break;
                    }
                }
                index = 0;
                strClusterExists = "No";
            }

            grdSearchValidation.DataSource = dt;
            grdSearchValidation.Columns["Question"].Width = 250;
            grdSearchValidation.Columns["ExpectedKBArticle"].Width = 120;
            grdSearchValidation.Columns["MatchingKBArticle"].Width = 120;
            grdSearchValidation.Columns["IsFound"].Width = 50;
            grdSearchValidation.Columns["Order"].Width = 50;
        }
    }
}
