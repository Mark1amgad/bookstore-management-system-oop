using System;
using System.Windows.Forms;
using book_store;

namespace book_store
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(100, 30, 30, 30);
        }

        // This method name MUST match what the designer is looking for
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CFile fileManager = new CFile();

                Client newClient = new Client
                {
                    Id = "1",
                    Name = "Test User",
                    EMembershipType = ENMembershipType.Student
                };

                string line = fileManager.ConvertToLine(newClient);
                fileManager.AddDataLineToFile(line);

                MessageBox.Show("Client Saved to File!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}