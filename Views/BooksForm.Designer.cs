using System;
using System.Linq;
using System.Windows.Forms;
using Quan_Ly_Thu_Vien_BTL_NET.Data;
using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Models;
using Quan_Ly_Thu_Vien_BTL_NET.ViewModels;

namespace Quan_Ly_Thu_Vien_BTL_NET.Views
{
    public partial class BooksForm : Form
    {
        private readonly BookViewModel _viewModel;

        // Controls
        private DataGridView dgvBooks;
        private TextBox txtSearch;
        private Button btnSearch, btnAdd, btnUpdate, btnDelete, btnRefresh;

        private void InitializeComponent()
        {
            this.Text = "Quản lý Sách";
            this.Size = new System.Drawing.Size(900, 600);

            // Search box
            txtSearch = new TextBox { Left = 20, Top = 20, Width = 300 };
            btnSearch = new Button { Text = "Tìm kiếm", Left = 330, Top = 18, Width = 100 };
            btnSearch.Click += BtnSearch_Click;

            // Buttons
            btnAdd = new Button { Text = "Thêm", Left = 450, Top = 18, Width = 80 };
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = new Button { Text = "Sửa", Left = 540, Top = 18, Width = 80 };
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = new Button { Text = "Xóa", Left = 630, Top = 18, Width = 80 };
            btnDelete.Click += BtnDelete_Click;

            btnRefresh = new Button { Text = "Làm mới", Left = 720, Top = 18, Width = 80 };
            btnRefresh.Click += BtnRefresh_Click;

            // DataGridView
            dgvBooks = new DataGridView
            {
                Left = 20,
                Top = 60,
                Width = 840,
                Height = 480,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            // Add controls
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(dgvBooks);
        }

        public BooksForm()
        {
            InitializeComponent();

            var context = new AppDbContext();
            var bookRepo = new BookRepository(context);
            _viewModel = new BookViewModel(bookRepo);

            _viewModel.LoadBooks();
            BindData();
        }

        private void BindData()
        {
            dgvBooks.DataSource = _viewModel.Books.Select(b => new
            {
                b.BookId,
                b.Title,
                b.Author,
                b.Publisher,
                Category = b.Category?.CategoryName ?? "",
                b.Location,
                b.Quantity
            }).ToList();
            dgvBooks.Columns["BookId"].HeaderText = "Mã Sách";
            dgvBooks.Columns["Title"].HeaderText = "Tiêu đề";
            dgvBooks.Columns["Author"].HeaderText = "Tác giả";
            dgvBooks.Columns["Publisher"].HeaderText = "Nhà xuất bản";
            dgvBooks.Columns["Category"].HeaderText = "Thể loại";
            dgvBooks.Columns["Location"].HeaderText = "Vị trí";
            dgvBooks.Columns["Quantity"].HeaderText = "Số lượng";
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _viewModel.SearchBooks(txtSearch.Text);
            BindData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new BookDetailForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _viewModel.AddBook(form.CurrentBook);
                    BindData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm sách: " + ex.Message);
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách để sửa.");
                return;
            }

            int bookId = (int)dgvBooks.CurrentRow.Cells["BookId"].Value;
            var book = _viewModel.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
            {
                MessageBox.Show("Sách không tồn tại.");
                return;
            }

            var form = new BookDetailForm(book);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _viewModel.UpdateBook(form.CurrentBook);
                    BindData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật sách: " + ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách để xóa.");
                return;
            }

            int bookId = (int)dgvBooks.CurrentRow.Cells["BookId"].Value;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _viewModel.DeleteBook(bookId);
                    BindData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sách: " + ex.Message);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            _viewModel.LoadBooks();
            BindData();
        }
    }
}
