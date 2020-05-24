namespace QuanLyBanHang
{
    partial class InitPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSanPham = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSPImport = new System.Windows.Forms.Button();
            this.btnSPAdd = new System.Windows.Forms.Button();
            this.btnSPBillBack = new System.Windows.Forms.Button();
            this.btnSPCreateBill = new System.Windows.Forms.Button();
            this.listSPBill = new System.Windows.Forms.ListView();
            this.colSPBillDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSPBillOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listSanPham = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMinNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabComment = new System.Windows.Forms.TabPage();
            this.btnCommentViewStatistic = new System.Windows.Forms.Button();
            this.listComment = new System.Windows.Forms.ListView();
            this.colCommentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentStat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabQuangCao = new System.Windows.Forms.TabPage();
            this.btnQCSDT = new System.Windows.Forms.Button();
            this.AddPartner = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listQCSDT = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listPartner = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDatHang = new System.Windows.Forms.TabPage();
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabSanPham.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabComment.SuspendLayout();
            this.tabQuangCao.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quan Ly ban hang v1.0";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1481, 15);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(1440, 15);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 28);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSanPham);
            this.tabControl.Controls.Add(this.tabComment);
            this.tabControl.Controls.Add(this.tabQuangCao);
            this.tabControl.Controls.Add(this.tabDatHang);
            this.tabControl.Controls.Add(this.tabThanhToan);
            this.tabControl.Location = new System.Drawing.Point(16, 48);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1501, 718);
            this.tabControl.TabIndex = 3;
            // 
            // tabSanPham
            // 
            this.tabSanPham.Controls.Add(this.label3);
            this.tabSanPham.Controls.Add(this.panel1);
            this.tabSanPham.Controls.Add(this.listSPBill);
            this.tabSanPham.Controls.Add(this.listSanPham);
            this.tabSanPham.Location = new System.Drawing.Point(4, 25);
            this.tabSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.tabSanPham.Name = "tabSanPham";
            this.tabSanPham.Padding = new System.Windows.Forms.Padding(4);
            this.tabSanPham.Size = new System.Drawing.Size(1493, 689);
            this.tabSanPham.TabIndex = 0;
            this.tabSanPham.Text = "SAN PHAM";
            this.tabSanPham.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1147, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đơn nhập/trả hàng";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSPImport);
            this.panel1.Controls.Add(this.btnSPAdd);
            this.panel1.Controls.Add(this.btnSPBillBack);
            this.panel1.Controls.Add(this.btnSPCreateBill);
            this.panel1.Location = new System.Drawing.Point(1147, 336);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 342);
            this.panel1.TabIndex = 1;
            // 
            // btnSPImport
            // 
            this.btnSPImport.Location = new System.Drawing.Point(3, 89);
            this.btnSPImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnSPImport.Name = "btnSPImport";
            this.btnSPImport.Size = new System.Drawing.Size(328, 78);
            this.btnSPImport.TabIndex = 3;
            this.btnSPImport.Text = "Nhập hàng";
            this.btnSPImport.UseVisualStyleBackColor = true;
            this.btnSPImport.Click += new System.EventHandler(this.BtnSPImport_Click);
            // 
            // btnSPAdd
            // 
            this.btnSPAdd.Location = new System.Drawing.Point(3, 4);
            this.btnSPAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSPAdd.Name = "btnSPAdd";
            this.btnSPAdd.Size = new System.Drawing.Size(328, 78);
            this.btnSPAdd.TabIndex = 2;
            this.btnSPAdd.Text = "Thêm mặt hàng mới";
            this.btnSPAdd.UseVisualStyleBackColor = true;
            this.btnSPAdd.Click += new System.EventHandler(this.BtnSPAdd_Click);
            // 
            // btnSPBillBack
            // 
            this.btnSPBillBack.Location = new System.Drawing.Point(3, 174);
            this.btnSPBillBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnSPBillBack.Name = "btnSPBillBack";
            this.btnSPBillBack.Size = new System.Drawing.Size(328, 78);
            this.btnSPBillBack.TabIndex = 1;
            this.btnSPBillBack.Text = "Lập đơn trả hàng";
            this.btnSPBillBack.UseVisualStyleBackColor = true;
            this.btnSPBillBack.Click += new System.EventHandler(this.BtnSPBillBack_Click);
            // 
            // btnSPCreateBill
            // 
            this.btnSPCreateBill.Location = new System.Drawing.Point(3, 258);
            this.btnSPCreateBill.Margin = new System.Windows.Forms.Padding(4);
            this.btnSPCreateBill.Name = "btnSPCreateBill";
            this.btnSPCreateBill.Size = new System.Drawing.Size(328, 78);
            this.btnSPCreateBill.TabIndex = 0;
            this.btnSPCreateBill.Text = "Lập đơn nhập hàng";
            this.btnSPCreateBill.UseVisualStyleBackColor = true;
            this.btnSPCreateBill.Click += new System.EventHandler(this.BtnSPCreateBill_Click);
            // 
            // listSPBill
            // 
            this.listSPBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSPBillDate,
            this.colSPBillOwner});
            this.listSPBill.FullRowSelect = true;
            this.listSPBill.HideSelection = false;
            this.listSPBill.Location = new System.Drawing.Point(1147, 27);
            this.listSPBill.Margin = new System.Windows.Forms.Padding(4);
            this.listSPBill.Name = "listSPBill";
            this.listSPBill.Size = new System.Drawing.Size(335, 301);
            this.listSPBill.TabIndex = 0;
            this.listSPBill.UseCompatibleStateImageBehavior = false;
            this.listSPBill.View = System.Windows.Forms.View.Details;
            this.listSPBill.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListSPBill_ColumnWidthChanging);
            this.listSPBill.SelectedIndexChanged += new System.EventHandler(this.ListSPBill_SelectedIndexChanged);
            // 
            // colSPBillDate
            // 
            this.colSPBillDate.Text = "Ngày";
            // 
            // colSPBillOwner
            // 
            this.colSPBillOwner.Text = "Người lập đơn";
            // 
            // listSanPham
            // 
            this.listSanPham.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName,
            this.colType,
            this.colNum,
            this.colMinNum});
            this.listSanPham.FullRowSelect = true;
            this.listSanPham.HideSelection = false;
            this.listSanPham.Location = new System.Drawing.Point(8, 7);
            this.listSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.listSanPham.Name = "listSanPham";
            this.listSanPham.Size = new System.Drawing.Size(1128, 670);
            this.listSanPham.TabIndex = 0;
            this.listSanPham.UseCompatibleStateImageBehavior = false;
            this.listSanPham.View = System.Windows.Forms.View.Details;
            this.listSanPham.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListSanPham_ColumnWidthChanging);
            this.listSanPham.SelectedIndexChanged += new System.EventHandler(this.ListSanPham_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colName
            // 
            this.colName.Text = "Tên mặt hàng";
            // 
            // colType
            // 
            this.colType.Text = "Loại hàng";
            // 
            // colNum
            // 
            this.colNum.Text = "Số lượng còn lại";
            // 
            // colMinNum
            // 
            this.colMinNum.Text = "Số lượng quy định";
            // 
            // tabComment
            // 
            this.tabComment.Controls.Add(this.btnCommentViewStatistic);
            this.tabComment.Controls.Add(this.listComment);
            this.tabComment.Location = new System.Drawing.Point(4, 25);
            this.tabComment.Margin = new System.Windows.Forms.Padding(4);
            this.tabComment.Name = "tabComment";
            this.tabComment.Padding = new System.Windows.Forms.Padding(4);
            this.tabComment.Size = new System.Drawing.Size(1493, 689);
            this.tabComment.TabIndex = 1;
            this.tabComment.Text = "COMMENT";
            this.tabComment.UseVisualStyleBackColor = true;
            // 
            // btnCommentViewStatistic
            // 
            this.btnCommentViewStatistic.Location = new System.Drawing.Point(1211, 587);
            this.btnCommentViewStatistic.Margin = new System.Windows.Forms.Padding(4);
            this.btnCommentViewStatistic.Name = "btnCommentViewStatistic";
            this.btnCommentViewStatistic.Size = new System.Drawing.Size(272, 74);
            this.btnCommentViewStatistic.TabIndex = 3;
            this.btnCommentViewStatistic.Text = "Xem thống kê";
            this.btnCommentViewStatistic.UseVisualStyleBackColor = true;
            this.btnCommentViewStatistic.Click += new System.EventHandler(this.BtnCommentViewStatistic_Click);
            // 
            // listComment
            // 
            this.listComment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCommentID,
            this.colCommentSP,
            this.colCommentOwner,
            this.colCommentStat,
            this.colCommentDetail});
            this.listComment.FullRowSelect = true;
            this.listComment.HideSelection = false;
            this.listComment.Location = new System.Drawing.Point(9, 9);
            this.listComment.Margin = new System.Windows.Forms.Padding(4);
            this.listComment.Name = "listComment";
            this.listComment.Size = new System.Drawing.Size(1472, 570);
            this.listComment.TabIndex = 0;
            this.listComment.UseCompatibleStateImageBehavior = false;
            this.listComment.View = System.Windows.Forms.View.Details;
            this.listComment.SelectedIndexChanged += new System.EventHandler(this.listComment_SelectedIndexChanged);
            // 
            // colCommentID
            // 
            this.colCommentID.Text = "ID";
            // 
            // colCommentSP
            // 
            this.colCommentSP.Text = "Sản phẩm";
            // 
            // colCommentOwner
            // 
            this.colCommentOwner.Text = "Tên khách hàng";
            // 
            // colCommentStat
            // 
            this.colCommentStat.Text = "Trạng thái";
            // 
            // colCommentDetail
            // 
            this.colCommentDetail.Text = "Chi tiết";
            // 
            // tabQuangCao
            // 
            this.tabQuangCao.Controls.Add(this.btnQCSDT);
            this.tabQuangCao.Controls.Add(this.AddPartner);
            this.tabQuangCao.Controls.Add(this.label4);
            this.tabQuangCao.Controls.Add(this.label2);
            this.tabQuangCao.Controls.Add(this.listQCSDT);
            this.tabQuangCao.Controls.Add(this.listPartner);
            this.tabQuangCao.Location = new System.Drawing.Point(4, 25);
            this.tabQuangCao.Margin = new System.Windows.Forms.Padding(4);
            this.tabQuangCao.Name = "tabQuangCao";
            this.tabQuangCao.Size = new System.Drawing.Size(1493, 689);
            this.tabQuangCao.TabIndex = 2;
            this.tabQuangCao.Text = "QUANG CAO";
            this.tabQuangCao.UseVisualStyleBackColor = true;
            // 
            // btnQCSDT
            // 
            this.btnQCSDT.Location = new System.Drawing.Point(722, 598);
            this.btnQCSDT.Margin = new System.Windows.Forms.Padding(4);
            this.btnQCSDT.Name = "btnQCSDT";
            this.btnQCSDT.Size = new System.Drawing.Size(272, 74);
            this.btnQCSDT.TabIndex = 6;
            this.btnQCSDT.Text = "Tạo Quảng Cáo Số Điện Thoại";
            this.btnQCSDT.UseVisualStyleBackColor = true;
            this.btnQCSDT.Click += new System.EventHandler(this.btnQCSDT_Click);
            // 
            // AddPartner
            // 
            this.AddPartner.Location = new System.Drawing.Point(8, 598);
            this.AddPartner.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartner.Name = "AddPartner";
            this.AddPartner.Size = new System.Drawing.Size(272, 74);
            this.AddPartner.TabIndex = 5;
            this.AddPartner.Text = "Thêm Đối Tác";
            this.AddPartner.UseVisualStyleBackColor = true;
            this.AddPartner.Click += new System.EventHandler(this.AddPartner_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(718, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quảng Cáo Số Điện Thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quảng Cáo Đối Tác";
            // 
            // listQCSDT
            // 
            this.listQCSDT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listQCSDT.FullRowSelect = true;
            this.listQCSDT.HideSelection = false;
            this.listQCSDT.Location = new System.Drawing.Point(722, 51);
            this.listQCSDT.Margin = new System.Windows.Forms.Padding(4);
            this.listQCSDT.Name = "listQCSDT";
            this.listQCSDT.Size = new System.Drawing.Size(758, 523);
            this.listQCSDT.TabIndex = 2;
            this.listQCSDT.UseCompatibleStateImageBehavior = false;
            this.listQCSDT.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số Điện Thoại";
            this.columnHeader5.Width = 128;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đã Quảng Cáo";
            this.columnHeader6.Width = 174;
            // 
            // listPartner
            // 
            this.listPartner.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listPartner.FullRowSelect = true;
            this.listPartner.HideSelection = false;
            this.listPartner.Location = new System.Drawing.Point(8, 51);
            this.listPartner.Margin = new System.Windows.Forms.Padding(4);
            this.listPartner.Name = "listPartner";
            this.listPartner.Size = new System.Drawing.Size(706, 523);
            this.listPartner.TabIndex = 1;
            this.listPartner.UseCompatibleStateImageBehavior = false;
            this.listPartner.View = System.Windows.Forms.View.Details;
            this.listPartner.SelectedIndexChanged += new System.EventHandler(this.listPartner_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Đối Tác";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày Hết Hạn";
            // 
            // tabDatHang
            // 
            this.tabDatHang.Location = new System.Drawing.Point(4, 25);
            this.tabDatHang.Margin = new System.Windows.Forms.Padding(4);
            this.tabDatHang.Name = "tabDatHang";
            this.tabDatHang.Size = new System.Drawing.Size(1493, 689);
            this.tabDatHang.TabIndex = 3;
            this.tabDatHang.Text = "DAT HANG";
            this.tabDatHang.UseVisualStyleBackColor = true;
            // 
            // tabThanhToan
            // 
            this.tabThanhToan.Location = new System.Drawing.Point(4, 25);
            this.tabThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Size = new System.Drawing.Size(1493, 689);
            this.tabThanhToan.TabIndex = 4;
            this.tabThanhToan.Text = "THANH TOAN";
            this.tabThanhToan.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(1133, 15);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(299, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // InitPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 780);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InitPage";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabSanPham.ResumeLayout(false);
            this.tabSanPham.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabComment.ResumeLayout(false);
            this.tabQuangCao.ResumeLayout(false);
            this.tabQuangCao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSanPham;
        private System.Windows.Forms.TabPage tabComment;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TabPage tabQuangCao;
        private System.Windows.Forms.TabPage tabDatHang;
        private System.Windows.Forms.TabPage tabThanhToan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listSanPham;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colNum;
        private System.Windows.Forms.ColumnHeader colMinNum;
        private System.Windows.Forms.ListView listComment;
        private System.Windows.Forms.ColumnHeader colCommentID;
        private System.Windows.Forms.ColumnHeader colCommentSP;
        private System.Windows.Forms.ColumnHeader colCommentOwner;
        private System.Windows.Forms.ColumnHeader colCommentStat;
        private System.Windows.Forms.ColumnHeader colCommentDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listSPBill;
        private System.Windows.Forms.ColumnHeader colSPBillDate;
        private System.Windows.Forms.ColumnHeader colSPBillOwner;
        private System.Windows.Forms.Button btnSPImport;
        private System.Windows.Forms.Button btnSPAdd;
        private System.Windows.Forms.Button btnSPBillBack;
        private System.Windows.Forms.Button btnSPCreateBill;
        private System.Windows.Forms.Button btnCommentViewStatistic;
        private System.Windows.Forms.ListView listPartner;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listQCSDT;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddPartner;
        private System.Windows.Forms.Button btnQCSDT;
    }
}

