using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq;

namespace book_store
{
    public partial class Form1 : Form
    {
        private CFile _fileManager = new CFile();

        // Custom Title Bar Controls
        private Panel titleBar;
        private Button btnClose, btnMaximize, btnMinimize;

        public Form1()
        {
            InitializeComponent();

            // 1. Force Remove White Border
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = String.Empty;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            BuildModernLayout();
            SetupCustomTitleBar(); // This is the fixed method
            InitializeDropdowns();
            RefreshGrid();
        }

        private void SetupCustomTitleBar()
        {
            // Create the dark bar
            titleBar = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.FromArgb(25, 25, 25) };
            titleBar.MouseDown += TitleBar_MouseDown;
            this.Controls.Add(titleBar);

            // --- BUTTON ORDER: FIRST ADDED = FURTHEST RIGHT ---

            // 1. ADD CLOSE (This will be on the FAR RIGHT)
            btnClose = CreateTitleButton("✕", Color.Crimson);
            btnClose.Click += (s, e) => Application.Exit();
            titleBar.Controls.Add(btnClose);

            // 2. ADD MAXIMIZE (This will be in the MIDDLE)
            btnMaximize = CreateTitleButton("▢", Color.FromArgb(60, 60, 60));
            btnMaximize.Click += (s, e) => ToggleMaximize();
            titleBar.Controls.Add(btnMaximize);

            // 3. ADD MINIMIZE (This will be to the LEFT of Maximize)
            btnMinimize = CreateTitleButton("—", Color.FromArgb(60, 60, 60));
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            titleBar.Controls.Add(btnMinimize);

            // Title text on the left
            Label lblTitle = new Label
            {
                Text = "📚 Bookstore System",
                ForeColor = Color.LightGray,
                Location = new Point(10, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            titleBar.Controls.Add(lblTitle);
        }

        private Button CreateTitleButton(string text, Color hoverColor)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Dock = DockStyle.Right;
            btn.Width = 45;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Transparent;
            btn.Font = new Font("Segoe UI", 10);

            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;
            return btn;
        }

        private void ToggleMaximize()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = "▢";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "❐";
            }
        }

        private void BuildModernLayout()
        {
            try
            {
                this.BackgroundImage = Image.FromFile("Bldg_Duke Humfreys_BOD_JC_2019_0.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { this.BackColor = Color.FromArgb(20, 20, 20); }

            lblHeader.Text = "Bookstore Management";
            lblHeader.Font = new Font("Times New Roman", 28, FontStyle.Regular);
            lblHeader.ForeColor = Color.NavajoWhite;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblHeader.Height = 90;
            lblHeader.Padding = new Padding(0, 30, 0, 0);
            this.Controls.Add(lblHeader);

            mainContainer.BackColor = Color.FromArgb(180, 20, 20, 20);
            mainContainer.Location = new Point(40, 120);
            mainContainer.Size = new Size(this.Width - 80, this.Height - 150);
            mainContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(mainContainer);

            detailsPanel.Size = new Size(320, 450);
            detailsPanel.Location = new Point(20, 20);
            detailsPanel.BackColor = Color.Transparent;
            detailsPanel.BorderStyle = BorderStyle.FixedSingle;
            mainContainer.Controls.Add(detailsPanel);

            Label lblDetails = new Label { Text = "Client Details", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.White, Location = new Point(90, 10), AutoSize = true };
            detailsPanel.Controls.Add(lblDetails);

            CreateInputRow("ID", txtID, 60);
            CreateInputRow("Name", txtName, 110);
            CreateInputRow("Phone", txtPhone, 160);
            CreateInputRow("Email", txtEmail, 210);
            CreateInputRow("Type", cmbMembership, 260);
            CreateInputRow("Genre", cmbGenre, 310);

            StyleButton(btnSave, "Save", 20);
            StyleButton(btnLoad, "Load", 125);
            StyleButton(btnDelete, "Delete", 230);

            dgvClients.Location = new Point(360, 20);
            dgvClients.Size = new Size(mainContainer.Width - 380, mainContainer.Height - 40);
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClients.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvClients.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            dgvClients.DefaultCellStyle.ForeColor = Color.White;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainContainer.Controls.Add(dgvClients);
        }

        private void InitializeDropdowns()
        {
            cmbMembership.DataSource = Enum.GetValues(typeof(ENMembershipType));
            cmbGenre.DataSource = Enum.GetValues(typeof(ENGenre));
        }

        private void CreateInputRow(string text, Control ctrl, int y)
        {
            Label lbl = new Label { Text = text, ForeColor = Color.LightGray, Location = new Point(15, y + 5), AutoSize = true, BackColor = Color.Transparent };
            ctrl.Location = new Point(110, y);
            ctrl.Width = 190;
            ctrl.BackColor = Color.FromArgb(50, 50, 50);
            ctrl.ForeColor = Color.White;
            if (ctrl is TextBox tb) tb.BorderStyle = BorderStyle.FixedSingle;
            if (ctrl is ComboBox cb) cb.FlatStyle = FlatStyle.Flat;
            detailsPanel.Controls.Add(lbl);
            detailsPanel.Controls.Add(ctrl);
        }

        private void StyleButton(Button btn, string text, int x)
        {
            btn.Text = text;
            btn.Size = new Size(80, 35);
            btn.Location = new Point(x, 400);
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(60, 60, 60);

            if (text == "Save") btn.Click += (s, e) => SaveClient();
            if (text == "Load") btn.Click += (s, e) => RefreshGrid();
            if (text == "Delete") btn.Click += (s, e) => DeleteClient();

            detailsPanel.Controls.Add(btn);
        }

        private void RefreshGrid()
        {
            dgvClients.DataSource = null;
            dgvClients.DataSource = _fileManager.LoadDataFromFile();

            if (dgvClients.Columns.Count > 0)
            {
                if (dgvClients.Columns["Id"] != null) dgvClients.Columns["Id"].HeaderText = "ID";
                if (dgvClients.Columns["Name"] != null) dgvClients.Columns["Name"].HeaderText = "Client";
                if (dgvClients.Columns["Phone"] != null) dgvClients.Columns["Phone"].HeaderText = "Phone";
                if (dgvClients.Columns["Email"] != null) dgvClients.Columns["Email"].HeaderText = "Email";
                if (dgvClients.Columns["EMembershipType"] != null) dgvClients.Columns["EMembershipType"].HeaderText = "Membership";
                if (dgvClients.Columns["FavBook"] != null) dgvClients.Columns["FavBook"].HeaderText = "Favorite Genre";
                if (dgvClients.Columns["MarkForDelete"] != null) dgvClients.Columns["MarkForDelete"].Visible = false;
            }
        }

        private void SaveClient()
        {
            if (cmbMembership.SelectedItem == null || cmbGenre.SelectedItem == null) return;
            Client c = new Client
            {
                Id = txtID.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                EMembershipType = (ENMembershipType)cmbMembership.SelectedItem,
                FavBook = (ENGenre)cmbGenre.SelectedItem
            };
            _fileManager.AddDataLineToFile(_fileManager.ConvertToLine(c));
            RefreshGrid();
        }

        private void DeleteClient()
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                string id = dgvClients.SelectedRows[0].Cells["Id"].Value.ToString();
                _fileManager.Delete(id);
                RefreshGrid();
            }
        }

        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); }
        }
    }
}