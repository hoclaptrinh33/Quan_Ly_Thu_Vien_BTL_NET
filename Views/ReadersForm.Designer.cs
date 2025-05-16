using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Data;
using Quan_Ly_Thu_Vien_BTL_NET.Models;
using System.Xml.Linq;
using System;
using System.Windows.Forms;
using Quan_Ly_Thu_Vien_BTL_NET.ViewModels;

namespace Quan_Ly_Thu_Vien_BTL_NET.Views
{



    public partial class ReadersForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dataGridViewReaders;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            dataGridViewReaders = new DataGridView();
            lblName = new Label();
            txtName = new TextBox();
            lblNgaySinh = new Label();
            lblContact = new Label();
            txtContact = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblIDCard = new Label();
            txtIDCard = new TextBox();
            dtpDOB = new DateTimePicker();
            txtSearch = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReaders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewReaders
            // 
            dataGridViewReaders = new DataGridView()
            {
                Name = "dataGridViewReaders",
                Top = 175,
                Left = 20,
                Width = 840,
                Height = 405,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 1;
            lblName.Text = "Tên:";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 23);
            txtName.TabIndex = 2;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.Location = new Point(20, 46);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(100, 23);
            lblNgaySinh.TabIndex = 3;
            lblNgaySinh.Text = "Ngày sinh :";
            // 
            // lblContact
            // 
            lblContact.Location = new Point(20, 75);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(100, 23);
            lblContact.TabIndex = 5;
            lblContact.Text = "SĐT:";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(120, 75);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(180, 23);
            txtContact.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(320, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(320, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Sửa";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(320, 100);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(20, 104);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 23);
            lblAddress.TabIndex = 10;
            lblAddress.Text = "Địa Chỉ :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(120, 104);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(180, 23);
            txtAddress.TabIndex = 11;
            txtAddress.TextChanged += textBox1_TextChanged;
            // 
            // lblIDCard
            // 
            lblIDCard.Location = new Point(20, 133);
            lblIDCard.Name = "lblIDCard";
            lblIDCard.Size = new Size(100, 23);
            lblIDCard.TabIndex = 12;
            lblIDCard.Text = "Thẻ sinh viên :";
            // 
            // txtIDCard
            // 
            txtIDCard.Location = new Point(120, 133);
            txtIDCard.Name = "txtIDCard";
            txtIDCard.Size = new Size(180, 23);
            txtIDCard.TabIndex = 13;
            // 
            // dtpDOB
            // 
            dtpDOB.Location = new Point(120, 46);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(180, 23);
            dtpDOB.TabIndex = 14;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(499, 142);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(221, 23);
            txtSearch.TabIndex = 15;
            // 
            // label1
            // 
            label1.Location = new Point(393, 142);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 16;
            label1.Text = "Tìm Kiếm :";
            // 
            // ReadersForm
            // 
            ClientSize = new Size(744, 511);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(dtpDOB);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblIDCard);
            Controls.Add(txtIDCard);
            Controls.Add(dataGridViewReaders);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblNgaySinh);
            Controls.Add(lblContact);
            Controls.Add(txtContact);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "ReadersForm";
            Text = "Quản lý Độc giả";
            Load += ReadersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewReaders).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }




        private ReaderViewModel _viewModel;

            public ReadersForm()
            {
                InitializeComponent();
                _viewModel = new ReaderViewModel(new ReaderRepository(new AppDbContext()));
                BindData();
            }
            private void ReadersForm_Load(object sender, EventArgs e)
            {
            BindData(); 
            SetColumnHeaders(); 
            }
        private void SetColumnHeaders()
        {
            if (dataGridViewReaders.Columns.Count > 0)
            {
                dataGridViewReaders.Columns["ReaderId"].HeaderText = "Mã độc giả";
                dataGridViewReaders.Columns["FullName"].HeaderText = "Họ và tên";
                dataGridViewReaders.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
                dataGridViewReaders.Columns["IDCardNumber"].HeaderText = "Số thẻ SV";
                dataGridViewReaders.Columns["Address"].HeaderText = "Địa chỉ";
                dataGridViewReaders.Columns["ContactInfo"].HeaderText = "Số liên hệ";
                if (dataGridViewReaders.Columns.Contains("BorrowRecords"))
                    dataGridViewReaders.Columns["BorrowRecords"].Visible = false;
                    dataGridViewReaders.Columns["ReaderId"].Visible = false;

            }
        }

        private void BindData()
            {
                dataGridViewReaders.DataSource = _viewModel.Readers;
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                var reader = new Reader
                {
                    FullName = txtName.Text,
                    DateOfBirth = dtpDOB.Value,
                    IDCardNumber = txtIDCard.Text,
                    Address = txtAddress.Text,
                    ContactInfo = txtContact.Text
                };

                _viewModel.AddReader(reader);
                MessageBox.Show("Thêm độc giả thành công!");
            }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                if (dataGridViewReaders.CurrentRow?.DataBoundItem is Reader selectedReader)
                {
                    selectedReader.FullName = txtName.Text;
                    selectedReader.DateOfBirth = dtpDOB.Value;
                    selectedReader.IDCardNumber = txtIDCard.Text;
                    selectedReader.Address = txtAddress.Text;
                    selectedReader.ContactInfo = txtContact.Text;

                    _viewModel.UpdateReader(selectedReader);
                    MessageBox.Show("Cập nhật độc giả thành công!");
                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                if (dataGridViewReaders.CurrentRow?.DataBoundItem is Reader selectedReader)
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        _viewModel.DeleteReader(selectedReader.ReaderId);
                    }
                }
            }

            private void txtSearch_TextChanged(object sender, EventArgs e)
            {
                _viewModel.Search(txtSearch.Text.Trim());
            }

            private void dataGridViewReaders_SelectionChanged(object sender, EventArgs e)
            {
                if (dataGridViewReaders.CurrentRow?.DataBoundItem is Reader selectedReader)
                {
                    txtName.Text = selectedReader.FullName;
                    dtpDOB.Value = selectedReader.DateOfBirth;
                    txtIDCard.Text = selectedReader.IDCardNumber;
                    txtAddress.Text = selectedReader.Address;
                    txtContact.Text = selectedReader.ContactInfo;
                }
        }
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblIDCard;
        private TextBox txtIDCard;
        private DateTimePicker dtpDOB;
        private TextBox txtSearch;
        private Label label1;
    }
    }













