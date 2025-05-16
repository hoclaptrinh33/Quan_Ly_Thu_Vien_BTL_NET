using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Data;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Views
{
    public partial class SystemConfigForm : Form
    {

        

        private System.ComponentModel.IContainer components = null;
            private Label lblMaxBorrowDays;
            private TextBox txtMaxBorrowDays;
            private Label lblMaxBorrowQuantity;
            private TextBox txtMaxBorrowQuantity;
            private Label lblOverdueFinePerDay;
            private TextBox txtOverdueFinePerDay;
            private Button btnSave;
            private Button btnReload;


        private void InitializeComponent()
        {
            lblMaxBorrowDays = new Label();
            txtMaxBorrowDays = new TextBox();
            lblMaxBorrowQuantity = new Label();
            txtMaxBorrowQuantity = new TextBox();
            lblOverdueFinePerDay = new Label();
            txtOverdueFinePerDay = new TextBox();
            btnSave = new Button();
            btnReload = new Button();
            SuspendLayout();
            // 
            // lblMaxBorrowDays
            // 
            lblMaxBorrowDays.AutoSize = true;
            lblMaxBorrowDays.Location = new Point(26, 22);
            lblMaxBorrowDays.Name = "lblMaxBorrowDays";
            lblMaxBorrowDays.Size = new Size(120, 15);
            lblMaxBorrowDays.TabIndex = 0;
            lblMaxBorrowDays.Text = "Số ngày mượn tối đa:";
            // 
            // txtMaxBorrowDays
            // 
            txtMaxBorrowDays.Location = new Point(175, 20);
            txtMaxBorrowDays.Margin = new Padding(3, 2, 3, 2);
            txtMaxBorrowDays.Name = "txtMaxBorrowDays";
            txtMaxBorrowDays.Size = new Size(176, 23);
            txtMaxBorrowDays.TabIndex = 1;
            // 
            // lblMaxBorrowQuantity
            // 
            lblMaxBorrowQuantity.AutoSize = true;
            lblMaxBorrowQuantity.Location = new Point(26, 60);
            lblMaxBorrowQuantity.Name = "lblMaxBorrowQuantity";
            lblMaxBorrowQuantity.Size = new Size(125, 15);
            lblMaxBorrowQuantity.TabIndex = 2;
            lblMaxBorrowQuantity.Text = "Số lượng mượn tối đa:";
            // 
            // txtMaxBorrowQuantity
            // 
            txtMaxBorrowQuantity.Location = new Point(175, 58);
            txtMaxBorrowQuantity.Margin = new Padding(3, 2, 3, 2);
            txtMaxBorrowQuantity.Name = "txtMaxBorrowQuantity";
            txtMaxBorrowQuantity.Size = new Size(176, 23);
            txtMaxBorrowQuantity.TabIndex = 3;
            // 
            // lblOverdueFinePerDay
            // 
            lblOverdueFinePerDay.AutoSize = true;
            lblOverdueFinePerDay.Location = new Point(26, 98);
            lblOverdueFinePerDay.Name = "lblOverdueFinePerDay";
            lblOverdueFinePerDay.Size = new Size(131, 15);
            lblOverdueFinePerDay.TabIndex = 4;
            lblOverdueFinePerDay.Text = "Phí phạt quá hạn/ngày:";
            // 
            // txtOverdueFinePerDay
            // 
            txtOverdueFinePerDay.Location = new Point(175, 95);
            txtOverdueFinePerDay.Margin = new Padding(3, 2, 3, 2);
            txtOverdueFinePerDay.Name = "txtOverdueFinePerDay";
            txtOverdueFinePerDay.Size = new Size(176, 23);
            txtOverdueFinePerDay.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(175, 135);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 26);
            btnSave.TabIndex = 6;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(271, 135);
            btnReload.Margin = new Padding(3, 2, 3, 2);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(79, 26);
            btnReload.TabIndex = 7;
            btnReload.Text = "Tải lại";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // SystemConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 188);
            Controls.Add(btnReload);
            Controls.Add(btnSave);
            Controls.Add(txtOverdueFinePerDay);
            Controls.Add(lblOverdueFinePerDay);
            Controls.Add(txtMaxBorrowQuantity);
            Controls.Add(lblMaxBorrowQuantity);
            Controls.Add(txtMaxBorrowDays);
            Controls.Add(lblMaxBorrowDays);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SystemConfigForm";
            Text = "Cấu hình hệ thống";
            ResumeLayout(false);
            PerformLayout();
        }
        private readonly SystemConfigRepository _configRepository;
        private SystemConfig _config;

        public SystemConfigForm()
        {
            InitializeComponent();
            _configRepository = new SystemConfigRepository(new AppDbContext());
            LoadConfig();
        }

        private void LoadConfig()
        {
            _config = _configRepository.GetConfig();
            if (_config != null)
            {
                txtMaxBorrowDays.Text = _config.MaxBorrowDays.ToString();
                txtMaxBorrowQuantity.Text = _config.MaxBooksPerReader.ToString();
                txtOverdueFinePerDay.Text = _config.FinePerDay.ToString();
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu System Config trong Database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_config != null)
            {
                _config.MaxBorrowDays = int.Parse(txtMaxBorrowDays.Text);
                _config.MaxBooksPerReader = int.Parse(txtMaxBorrowQuantity.Text);
                _config.FinePerDay = decimal.Parse(txtOverdueFinePerDay.Text);

                _configRepository.UpdateConfig(_config);
                MessageBox.Show("Cập nhật cấu hình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }
    }
    }


