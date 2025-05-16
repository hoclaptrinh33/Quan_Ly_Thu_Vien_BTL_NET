using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Data;
using Quan_Ly_Thu_Vien_BTL_NET.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Quan_Ly_Thu_Vien_BTL_NET.ViewModels;

namespace Quan_Ly_Thu_Vien_BTL_NET.Views
{
    public partial class CategoryForm : Form
    {

        private System.ComponentModel.IContainer components = null;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvCategories;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(30, 30);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(93, 20);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Tên thể loại:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(130, 27);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(250, 27);
            this.txtCategoryName.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(400, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(500, 25);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(600, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(400, 75);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(73, 20);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(480, 72);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(700, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(30, 120);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.RowTemplate.Height = 29;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(750, 300);
            this.dgvCategories.TabIndex = 8;
            


            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.lblCategoryName);
            this.Name = "CategoryForm";
            this.Text = "Quản lý thể loại";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += CategoryForm_Load;

        }

        private readonly ICategoryRepository _categoryRepository;
        private int _selectedCategoryId;


            private CategoryVM _viewModel;

            public CategoryForm()
            {
                InitializeComponent();
                _viewModel = new CategoryVM();
                this.DataBindings.Add(new Binding("Text", _viewModel, "CategoryName"));
                
            }

            private void CategoryForm_Load(object sender, EventArgs e)
            {
            RefreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _viewModel.AddCategory(txtCategoryName.Text);
            RefreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn dòng để sửa.");
                return;
            }

            int id = GetSelectedCategoryId();
            _viewModel.UpdateCategory(id, txtCategoryName.Text);
            RefreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn dòng để xóa.");
                return;
            }

            int id = GetSelectedCategoryId();
            _viewModel.DeleteCategory(id);
            RefreshData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _viewModel.Search(txtSearch.Text);
            dgvCategories.DataSource = _viewModel.Categories.Select(c => new
            {
                c.CategoryId,
                c.CategoryName
            }).ToList();
            dgvCategories.Columns["CategoryId"].HeaderText = "Mã thể loại";
            dgvCategories.Columns["CategoryName"].HeaderText = "Tên thể loại";
        }

        private void RefreshData()
        {
            _viewModel.LoadCategories();
            dgvCategories.DataSource = _viewModel.Categories.Select(c => new
            {
                c.CategoryId,
                c.CategoryName
            }).ToList();
            txtCategoryName.Clear();
            dgvCategories.Columns["CategoryId"].HeaderText = "Mã thể loại";
            dgvCategories.Columns["CategoryName"].HeaderText = "Tên thể loại";
        }


        private int GetSelectedCategoryId()
            {
                // Lấy ID từ dòng đang được chọn trong DataGridView
                return (int)dgvCategories.SelectedRows[0].Cells["CategoryId"].Value;
            }
        }
    }





