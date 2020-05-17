namespace QuanLyBanHang.Views
{
    partial class CommentStatistic
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelValueNone = new System.Windows.Forms.Label();
            this.labelValueClasscified = new System.Windows.Forms.Label();
            this.labelValueNormal = new System.Windows.Forms.Label();
            this.lableValueBad = new System.Windows.Forms.Label();
            this.labelValueGood = new System.Windows.Forms.Label();
            this.pbNormal = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.pbNone = new System.Windows.Forms.ProgressBar();
            this.pbClassifed = new System.Windows.Forms.ProgressBar();
            this.pbBad = new System.Windows.Forms.ProgressBar();
            this.pbGood = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(159, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(235, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(159, 100);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(235, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thống kê bình luận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày kết thúc";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(425, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelValueNone);
            this.panel1.Controls.Add(this.labelValueClasscified);
            this.panel1.Controls.Add(this.labelValueNormal);
            this.panel1.Controls.Add(this.lableValueBad);
            this.panel1.Controls.Add(this.labelValueGood);
            this.panel1.Controls.Add(this.pbNormal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pbNone);
            this.panel1.Controls.Add(this.pbClassifed);
            this.panel1.Controls.Add(this.pbBad);
            this.panel1.Controls.Add(this.pbGood);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(15, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 157);
            this.panel1.TabIndex = 6;
            // 
            // labelValueNone
            // 
            this.labelValueNone.AutoSize = true;
            this.labelValueNone.Location = new System.Drawing.Point(470, 129);
            this.labelValueNone.Name = "labelValueNone";
            this.labelValueNone.Size = new System.Drawing.Size(0, 13);
            this.labelValueNone.TabIndex = 14;
            // 
            // labelValueClasscified
            // 
            this.labelValueClasscified.AutoSize = true;
            this.labelValueClasscified.Location = new System.Drawing.Point(470, 96);
            this.labelValueClasscified.Name = "labelValueClasscified";
            this.labelValueClasscified.Size = new System.Drawing.Size(0, 13);
            this.labelValueClasscified.TabIndex = 13;
            // 
            // labelValueNormal
            // 
            this.labelValueNormal.AutoSize = true;
            this.labelValueNormal.Location = new System.Drawing.Point(470, 65);
            this.labelValueNormal.Name = "labelValueNormal";
            this.labelValueNormal.Size = new System.Drawing.Size(0, 13);
            this.labelValueNormal.TabIndex = 12;
            // 
            // lableValueBad
            // 
            this.lableValueBad.AutoSize = true;
            this.lableValueBad.Location = new System.Drawing.Point(470, 34);
            this.lableValueBad.Name = "lableValueBad";
            this.lableValueBad.Size = new System.Drawing.Size(0, 13);
            this.lableValueBad.TabIndex = 11;
            // 
            // labelValueGood
            // 
            this.labelValueGood.AutoSize = true;
            this.labelValueGood.Location = new System.Drawing.Point(470, 5);
            this.labelValueGood.Name = "labelValueGood";
            this.labelValueGood.Size = new System.Drawing.Size(0, 13);
            this.labelValueGood.TabIndex = 10;
            // 
            // pbNormal
            // 
            this.pbNormal.ForeColor = System.Drawing.Color.Lime;
            this.pbNormal.Location = new System.Drawing.Point(143, 65);
            this.pbNormal.Name = "pbNormal";
            this.pbNormal.Size = new System.Drawing.Size(321, 23);
            this.pbNormal.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Bình luận bình thường";
            // 
            // pbNone
            // 
            this.pbNone.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pbNone.Location = new System.Drawing.Point(143, 129);
            this.pbNone.Name = "pbNone";
            this.pbNone.Size = new System.Drawing.Size(321, 23);
            this.pbNone.TabIndex = 7;
            // 
            // pbClassifed
            // 
            this.pbClassifed.ForeColor = System.Drawing.Color.Aqua;
            this.pbClassifed.Location = new System.Drawing.Point(143, 96);
            this.pbClassifed.Name = "pbClassifed";
            this.pbClassifed.Size = new System.Drawing.Size(321, 23);
            this.pbClassifed.TabIndex = 6;
            // 
            // pbBad
            // 
            this.pbBad.ForeColor = System.Drawing.Color.Red;
            this.pbBad.Location = new System.Drawing.Point(143, 34);
            this.pbBad.Name = "pbBad";
            this.pbBad.Size = new System.Drawing.Size(321, 23);
            this.pbBad.TabIndex = 5;
            // 
            // pbGood
            // 
            this.pbGood.ForeColor = System.Drawing.Color.Lime;
            this.pbGood.Location = new System.Drawing.Point(143, 5);
            this.pbGood.Name = "pbGood";
            this.pbGood.Size = new System.Drawing.Size(321, 23);
            this.pbGood.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Bình luận chưa phân loại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Bình luận đã phân loại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Bình luận xấu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bình luận tốt";
            // 
            // CommentStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 320);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommentStatistic";
            this.Text = "CommentStatistic";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbNone;
        private System.Windows.Forms.ProgressBar pbClassifed;
        private System.Windows.Forms.ProgressBar pbBad;
        private System.Windows.Forms.ProgressBar pbGood;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pbNormal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelValueNone;
        private System.Windows.Forms.Label labelValueClasscified;
        private System.Windows.Forms.Label labelValueNormal;
        private System.Windows.Forms.Label lableValueBad;
        private System.Windows.Forms.Label labelValueGood;
    }
}