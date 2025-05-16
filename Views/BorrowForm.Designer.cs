using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Data;
using Quan_Ly_Thu_Vien_BTL_NET.ViewModels;

namespace Quan_Ly_Thu_Vien_BTL_NET.Views
{
    public partial class BorrowForm : Form
    {
        private ComboBox cbReaders;
        private ComboBox cbBooks;
        private DataGridView dgvBorrowRecords;
        private DateTimePicker dtBorrow;
        private DateTimePicker dtDue;

        private Button btnBorrow;
        private Button btnReturn;
        private Button btnRenew;
        private Button btnRefresh;
        private TextBox txtSearch;
        private ComboBox cbFilter;


        private readonly BorrowVM _viewModel;

        public BorrowForm()
        {
            InitializeComponent();

            var context = new AppDbContext();
            var borrowRepo = new BorrowRepository(context);
            var bookRepo = new BookRepository(context);
            var readerRepo = new ReaderRepository(context);
            var configRepo = new SystemConfigRepository(context);

            _viewModel = new BorrowVM(borrowRepo, bookRepo, readerRepo, configRepo);

            LoadDataToControls();
            dtBorrow.ValueChanged += DtBorrow_ValueChanged;
            UpdateDueDate();
        }

        private void InitializeComponent()
        {
            this.Text = "Quản lý Mượn Sách";
            this.Size = new System.Drawing.Size(900, 600);

            // ComboBox độc giả
            Label lblReader = new Label() { Text = "Độc giả:", Top = 20, Left = 20, Width = 70 };
            cbReaders = new ComboBox() { Name = "cbReaders", Top = 20, Left = 120, Width = 200 };

            // ComboBox sách
            Label lblBook = new Label() { Text = "Sách:", Top = 60, Left = 20, Width = 70 };
            cbBooks = new ComboBox() { Name = "cbBooks", Top = 60, Left = 120, Width = 200 };

            // Ngày mượn
            Label lblBorrowDate = new Label() { Text = "Ngày mượn:", Top = 100, Left = 20 };
            dtBorrow = new DateTimePicker() { Name = "dtBorrowDate", Top = 100, Left = 120, Width = 200 };

            // Hạn trả (readonly vì tự tính)
            Label lblDueDate = new Label() { Text = "Hạn trả:", Top = 140, Left = 20 };
            dtDue = new DateTimePicker() { Name = "dtDueDate", Top = 140, Left = 120, Width = 200, Enabled = false };

            // Các nút
            btnBorrow = new Button() { Text = "📥 Mượn", Top = 180, Left = 100, Width = 80 };
            btnReturn = new Button() { Text = "📤 Trả", Top = 180, Left = 200, Width = 80 };
            btnRenew = new Button() { Text = "🔄 Gia hạn", Top = 180, Left = 300, Width = 100 };
            btnRefresh = new Button() { Text = "🔃 Làm mới", Top = 180, Left = 420, Width = 100 };

            // Tìm Kiếm 
            Label lblSearch = new Label() { Text = "Tìm kiếm:", Top = 20, Left = 350 };
            txtSearch = new TextBox() { Name = "txtSearch", Top = 20, Left = 450, Width = 200 };
            this.Controls.Add(lblSearch);
            this.Controls.Add(txtSearch);
            txtSearch.TextChanged += txtSearch_TextChanged;


            // ComboBox bộ lọc
            Label lblFilter = new Label() { Text = "Lọc:", Top = 60, Left = 350 };
            cbFilter = new ComboBox() { Name = "cbFilter", Top = 60, Left = 450, Width = 200 };
            cbFilter.Items.AddRange(new string[]
            {"Tất cả","Chưa trả","Đã trả","Quá hạn","Phải đóng phạt"});
            cbFilter.SelectedIndex = 0; // Default: Tất cả
            this.Controls.Add(lblFilter);
            this.Controls.Add(cbFilter);
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;



            // DataGridView
            dgvBorrowRecords = new DataGridView()
            {
                Name = "dgvBorrowRecords",
                Top = 230,
                Left = 20,
                Width = 840,
                Height = 350,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Thêm controls vào form
            this.Controls.Add(lblReader);
            this.Controls.Add(cbReaders);
            this.Controls.Add(lblBook);
            this.Controls.Add(cbBooks);
            this.Controls.Add(lblBorrowDate);
            this.Controls.Add(dtBorrow);
            this.Controls.Add(lblDueDate);
            this.Controls.Add(dtDue);
            this.Controls.Add(btnBorrow);
            this.Controls.Add(btnReturn);
            this.Controls.Add(btnRenew);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(dgvBorrowRecords);

            // Gán sự kiện cho các nút
            btnBorrow.Click += btnBorrow_Click;
            btnReturn.Click += btnReturn_Click;
            btnRenew.Click += btnRenew_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void LoadDataToControls()
        {
            cbReaders.DataSource = null;
            cbReaders.DataSource = _viewModel.Readers;
            cbReaders.DisplayMember = "FullName";
            cbReaders.ValueMember = "ReaderId";

            cbBooks.DataSource = null;
            cbBooks.DataSource = _viewModel.Books;
            cbBooks.DisplayMember = "Title";
            cbBooks.ValueMember = "BookId";

            // Gán dữ liệu cho DataGridView
            dgvBorrowRecords.DataSource = null;
            dgvBorrowRecords.DataSource = _viewModel.BorrowRecords
                .Select(b => new
                {
                    b.BorrowId,
                    ReaderName = b.Reader.FullName,
                    BookTitle = b.Book.Title,
                    b.BorrowDate,
                    b.DueDate,
                    b.ReturnDate,
                    b.FineAmount,
                    b.IsRenewed
                }).ToList();

            if (dgvBorrowRecords.Columns.Count > 0)
            {
                dgvBorrowRecords.Columns["BorrowId"].HeaderText = "Mã phiếu";
                dgvBorrowRecords.Columns["ReaderName"].HeaderText = "Độc giả";
                dgvBorrowRecords.Columns["BookTitle"].HeaderText = "Tên sách";
                dgvBorrowRecords.Columns["BorrowDate"].HeaderText = "Ngày mượn";
                dgvBorrowRecords.Columns["DueDate"].HeaderText = "Hạn trả";
                dgvBorrowRecords.Columns["ReturnDate"].HeaderText = "Ngày trả";
                dgvBorrowRecords.Columns["FineAmount"].HeaderText = "Tiền phạt";
                dgvBorrowRecords.Columns["IsRenewed"].HeaderText = "Đã gia hạn";
            }

            UpdateDueDate();
        }


        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                int readerId = (int)cbReaders.SelectedValue;
                int bookId = (int)cbBooks.SelectedValue;
                DateTime borrowDate = dtBorrow.Value;

                DateTime dueDate = borrowDate.AddDays(_viewModel.MaxBorrowDays);

                _viewModel.BorrowBook(readerId, bookId, borrowDate, dueDate);
                LoadDataToControls();

                MessageBox.Show("Mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mượn sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvBorrowRecords.CurrentRow != null)
            {
                int borrowId = (int)dgvBorrowRecords.CurrentRow.Cells["BorrowId"].Value;
                try
                {
                    _viewModel.ReturnBook(borrowId);
                    LoadDataToControls();
                    MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi trả sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (dgvBorrowRecords.CurrentRow != null)
            {
                int borrowId = (int)dgvBorrowRecords.CurrentRow.Cells["BorrowId"].Value;
                try
                {
                    _viewModel.RenewBook(borrowId);
                    LoadDataToControls();
                    MessageBox.Show("Gia hạn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gia hạn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _viewModel.Refresh();
            LoadDataToControls();
        }

        private void DtBorrow_ValueChanged(object sender, EventArgs e)
        {
            UpdateDueDate();
        }

        private void UpdateDueDate()
        {
            dtDue.Value = dtBorrow.Value.AddDays(_viewModel.MaxBorrowDays);
        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }



        private void ApplyFilterAndSearch()
        {
            string keyword = (txtSearch?.Text ?? "").ToLower().Trim();
            string filter = cbFilter?.SelectedItem?.ToString();

            var records = _viewModel.BorrowRecords;

            // Tìm kiếm
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                records = records.Where(b =>
                    b.Reader.FullName.ToLower().Contains(keyword) ||
                    b.Book.Title.ToLower().Contains(keyword)
                ).ToList();
            }

            // Lọc theo trạng thái
            switch (filter)
            {
                case "Chưa trả":
                    records = records.Where(b => b.ReturnDate == null).ToList();
                    break;
                case "Đã trả":
                    records = records.Where(b => b.ReturnDate != null).ToList();
                    break;
                case "Quá hạn":
                    records = records.Where(b => b.ReturnDate == null && b.DueDate < DateTime.Now).ToList();
                    break;
                case "Phải đóng phạt":
                    records = records.Where(b => b.FineAmount > 0).ToList();
                    break;
                case "Tất cả":
                default:
                    break;
            }

            // Cập nhật DataGridView
            dgvBorrowRecords.DataSource = records
                .Select(b => new
                {
                    b.BorrowId,
                    ReaderName = b.Reader.FullName,
                    BookTitle = b.Book.Title,
                    b.BorrowDate,
                    b.DueDate,
                    b.ReturnDate,
                    b.FineAmount,
                    b.IsRenewed
                }).ToList();

            if (dgvBorrowRecords.Columns.Count > 0)
            {
                dgvBorrowRecords.Columns["BorrowId"].HeaderText = "Mã phiếu";
                dgvBorrowRecords.Columns["ReaderName"].HeaderText = "Độc giả";
                dgvBorrowRecords.Columns["BookTitle"].HeaderText = "Tên sách";
                dgvBorrowRecords.Columns["BorrowDate"].HeaderText = "Ngày mượn";
                dgvBorrowRecords.Columns["DueDate"].HeaderText = "Hạn trả";
                dgvBorrowRecords.Columns["ReturnDate"].HeaderText = "Ngày trả";
                dgvBorrowRecords.Columns["FineAmount"].HeaderText = "Tiền phạt";
                dgvBorrowRecords.Columns["IsRenewed"].HeaderText = "Đã gia hạn";
            }
        }


    }
}
