namespace book_store
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        // Only keep the main structural panels
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgvClients;
        // Inputs
        private System.Windows.Forms.TextBox txtID, txtName, txtPhone, txtEmail;
        private System.Windows.Forms.ComboBox cmbMembership, cmbGenre;
        private System.Windows.Forms.Button btnSave, btnLoad, btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainContainer = new System.Windows.Forms.Panel();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmbMembership = new System.Windows.Forms.ComboBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Set the exact size here and nowhere else
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ResumeLayout(false);
        }
    }
}