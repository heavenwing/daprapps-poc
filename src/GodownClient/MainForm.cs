using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;

namespace GodownClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ApplicationCreateForm();
            form.MdiParent = this;
            form.Show();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (CustomControls.InputBox("Application form id", "id:", ref value) == DialogResult.OK)
            {
                var form = new ApplicationLoadForm(value);
                form.MdiParent = this;
                form.Show();
            }
        }

        private void addBizScopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddBizScopeOrLimitationForm(true);
            form.ShowDialog();
        }

        private void addLimitationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddBizScopeOrLimitationForm(false);
            form.ShowDialog();
        }
    }
}
