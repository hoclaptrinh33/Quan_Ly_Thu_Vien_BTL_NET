namespace Quan_Ly_Thu_Vien_BTL_NET.Views
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelSidebar;
        private Panel panelMain;
        private Button btnBooks;
        private Button btnCategories;
        private Button btnSettings;
        private Button btnReaders;
        private Button btnBorrow;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new Panel();
            this.btnBooks = new Button();
            this.btnCategories = new Button();
            this.btnSettings = new Button();
            this.btnBorrow = new Button();     
            this.btnReaders = new Button();    
            this.panelMain = new Panel();

            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();

            // 
            // btnReaders
            // 
            this.btnReaders.Dock = DockStyle.Top;
            this.btnReaders.FlatStyle = FlatStyle.Flat;
            this.btnReaders.ForeColor = System.Drawing.Color.White;
            this.btnReaders.Text = "👤 Độc giả";
            this.btnReaders.Height = 50;
            this.btnReaders.Click += new EventHandler(this.btnReaders_Click);

            // 
            // btnBorrow
            // 
            this.btnBorrow.Dock = DockStyle.Top;
            this.btnBorrow.FlatStyle = FlatStyle.Flat;
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Text = "🔄 Mượn - Trả";
            this.btnBorrow.Height = 50;
            this.btnBorrow.Click += new EventHandler(this.btnBorrow_Click);

            // 
            // btnBooks
            // 
            this.btnBooks.Dock = DockStyle.Top;
            this.btnBooks.FlatStyle = FlatStyle.Flat;
            this.btnBooks.ForeColor = System.Drawing.Color.White;
            this.btnBooks.Text = "📚 Quản lý Sách";
            this.btnBooks.Height = 50;
            this.btnBooks.Click += new EventHandler(this.btnBooks_Click);

            // 
            // btnCategories
            // 
            this.btnCategories.Dock = DockStyle.Top;
            this.btnCategories.FlatStyle = FlatStyle.Flat;
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Text = "📂 Thể Loại";
            this.btnCategories.Height = 50;
            this.btnCategories.Click += new EventHandler(this.btnCategories_Click);

            // 
            // btnSettings
            // 
            this.btnSettings.Dock = DockStyle.Top;
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Text = "⚙️ Cấu Hình";
            this.btnSettings.Height = 50;
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);

            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Width = 200;
            this.panelSidebar.Controls.Add(this.btnSettings);
            this.panelSidebar.Controls.Add(this.btnCategories);
            this.panelSidebar.Controls.Add(this.btnBooks);
            this.panelSidebar.Controls.Add(this.btnBorrow);   
            this.panelSidebar.Controls.Add(this.btnReaders);  

            // 
            // panelMain
            // 
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1080, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Thư viện";
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void LoadFormInPanel(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }
        private void btnBooks_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Views.BooksForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Views.CategoryForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Views.SystemConfigForm());
        }
        private void btnReaders_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Views.ReadersForm());
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Views.BorrowForm());
        }

    }
}
