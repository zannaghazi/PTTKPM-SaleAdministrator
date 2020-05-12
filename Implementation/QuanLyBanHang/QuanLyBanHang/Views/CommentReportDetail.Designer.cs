namespace QuanLyBanHang.Views
{
    partial class CommentReportDetail
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
            this.listComment = new System.Windows.Forms.ListView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnGivePoint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSanPham = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BẢN THỐNG KÊ CHI TIẾT COMMENT";
            // 
            // listComment
            // 
            this.listComment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colSanPham,
            this.colName,
            this.colStatus,
            this.colDetail});
            this.listComment.HideSelection = false;
            this.listComment.Location = new System.Drawing.Point(13, 44);
            this.listComment.Name = "listComment";
            this.listComment.Size = new System.Drawing.Size(775, 342);
            this.listComment.TabIndex = 1;
            this.listComment.UseCompatibleStateImageBehavior = false;
            this.listComment.View = System.Windows.Forms.View.Details;
            //this.listComment.SelectedIndexChanged += new System.EventHandler(this.listComment_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colSanPham
            // 
            this.colSanPham.Text = "Tên sản phẩm";
            // 
            // colEmail
            // 
            this.colName.Text = "Tên khách hàng";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Trạng thái";
            // 
            // colDetail
            // 
            this.colDetail.Text = "Chi tiết";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15, 392);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(146, 46);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Submit";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(167, 392);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(146, 46);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnGivePoint
            // 
            this.btnGivePoint.Location = new System.Drawing.Point(319, 392);
            this.btnGivePoint.Name = "btnGivePoint";
            this.btnGivePoint.Size = new System.Drawing.Size(146, 46);
            this.btnGivePoint.TabIndex = 4;
            this.btnGivePoint.Text = "Give Point";
            this.btnGivePoint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(642, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 46);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancle";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CommentReportDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGivePoint);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.listComment);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommentReportDetail";
            this.Text = "CommentReportDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listComment;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colSanPham;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnGivePoint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colDetail;
    }
}