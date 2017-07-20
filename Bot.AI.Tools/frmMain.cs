using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot.AI.Tools
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUtterancesTranslatorTest _f = new frmUtterancesTranslatorTest();
            _f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddTags _f = new frmAddTags();
            _f.Show();
            this.Hide();
        }

        private void btnAddBatchUtterances_Click(object sender, EventArgs e)
        {
            frmAddBatchUtterances _f = new frmAddBatchUtterances();
            _f.Show();
            this.Hide();
        }
    }
}
