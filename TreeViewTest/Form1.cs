using System.Windows.Forms;
using System.IO;

namespace TreeViewTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.displayTreeview();
        }

        private void displayTreeview()
        {
            /*TreeNode tnRoot = new TreeNode("Myroot");
            tvMain.Nodes.Add(tnRoot);
            TreeNode tnRoot1 = new TreeNode("1");
            tnRoot.Nodes.Add(tnRoot1);
            tvMain.ExpandAll();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Setting Inital Value of Progress Bar  
            progressBar1.Value = 0;
            // Clear All Nodes if Already Exists  
            treeView1.Nodes.Clear();
            toolTip1.ShowAlways = true;
            if (textBox1.Text != "" && Directory.Exists(textBox1.Text))
                LoadDirectory(textBox1.Text);
            else
                MessageBox.Show("Select Directory!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBox1.Text;
            DialogResult drResult = folderBrowserDialog1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
        public void LoadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value  
            progressBar1.Maximum = Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(Dir, "**", SearchOption.AllDirectories).Length;
            TreeNode tds = treeView1.Nodes.Add(di.Name);
            tds.ImageIndex = 0;
            tds.SelectedImageIndex = 1;
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadFiles(Dir, tds);
            LoadSubDirectories(Dir, tds);
        }
        private void LoadSubDirectories(string dir, TreeNode td)
        {
            // Get all subdirectories  
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories  
            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                td.ImageIndex = 0;
                td.SelectedImageIndex = 1;
                tds.Tag = di.FullName;
                LoadFiles(subdirectory, tds);
                LoadSubDirectories(subdirectory, tds);
                UpdateProgress();

            }
        }

        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            // Loop through them to see files  
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;
                UpdateProgress();

            }
        }

        private void UpdateProgress()
        { 
           if (progressBar1.Value<progressBar1.Maximum)  
           {  
               progressBar1.Value++;  
               int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
        progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));  
  
               Application.DoEvents();  
           }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }




        //TODO : mettre des icones de repértoires 
    }
}