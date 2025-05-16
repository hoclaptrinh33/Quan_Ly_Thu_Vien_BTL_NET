using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Quan_Ly_Thu_Vien_BTL_NET.Models;
using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Data;

namespace Quan_Ly_Thu_Vien_BTL_NET.Views
{
    public partial class BookDetailForm : Form
    {
        private Book _book;
        private readonly ICategoryRepository _categoryRepository;
        private List<Category> _categories;

        public Book CurrentBook { get; private set; }

        public BookDetailForm()
        {
            InitializeComponent();
            _categoryRepository = new CategoryRepository(new AppDbContext());

            LoadCategories();

            _book = new Book();
        }

        public BookDetailForm(Book book) : this()
        {
            _book = book ?? new Book();

            txtTitle.Text = _book.Title;
            txtAuthor.Text = _book.Author;
            txtPublisher.Text = _book.Publisher;
            cbCategory.SelectedValue = _book.CategoryId;
            txtLocation.Text = _book.Location;
            txtQuantity.Text = _book.Quantity.ToString();
        }

        private void LoadCategories()
        {
            _categories = new List<Category>(_categoryRepository.GetAll());
            cbCategory.DataSource = _categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryId";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Tên sách không được để trống!");
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!");
                return;
            }

            _book.Title = txtTitle.Text.Trim();
            _book.Author = txtAuthor.Text.Trim();
            _book.Publisher = txtPublisher.Text.Trim();
            _book.CategoryId = (int)cbCategory.SelectedValue;
            _book.Location = txtLocation.Text.Trim();
            _book.Quantity = quantity;

            CurrentBook = _book;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.Text = "Chi tiết Sách";
            this.Size = new System.Drawing.Size(400, 350);

            Label lblTitle = new Label() { Text = "Tiêu đề:", Left = 20, Top = 20, Width = 80 };
            txtTitle = new TextBox() { Left = 110, Top = 20, Width = 250 };

            Label lblAuthor = new Label() { Text = "Tác giả:", Left = 20, Top = 60, Width = 80 };
            txtAuthor = new TextBox() { Left = 110, Top = 60, Width = 250 };

            Label lblPublisher = new Label() { Text = "Nhà xuất bản:", Left = 20, Top = 100, Width = 80 };
            txtPublisher = new TextBox() { Left = 110, Top = 100, Width = 250 };

            Label lblCategory = new Label() { Text = "Thể loại:", Left = 20, Top = 140, Width = 80 };
            cbCategory = new ComboBox() { Left = 110, Top = 140, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblLocation = new Label() { Text = "Vị trí:", Left = 20, Top = 180, Width = 80 };
            txtLocation = new TextBox() { Left = 110, Top = 180, Width = 250 };

            Label lblQuantity = new Label() { Text = "Số lượng:", Left = 20, Top = 220, Width = 80 };
            txtQuantity = new TextBox() { Left = 110, Top = 220, Width = 250 };

            btnSave = new Button() { Text = "Lưu", Left = 110, Top = 260, Width = 100 };
            btnCancel = new Button() { Text = "Hủy", Left = 260, Top = 260, Width = 100 };

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblAuthor);
            this.Controls.Add(txtAuthor);
            this.Controls.Add(lblPublisher);
            this.Controls.Add(txtPublisher);
            this.Controls.Add(lblCategory);
            this.Controls.Add(cbCategory);
            this.Controls.Add(lblLocation);
            this.Controls.Add(txtLocation);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtPublisher;
        private ComboBox cbCategory;
        private TextBox txtLocation;
        private TextBox txtQuantity;
        private Button btnSave;
        private Button btnCancel;
    }
}
