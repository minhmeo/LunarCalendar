namespace LunarEventCalendar
{
    partial class ExportAD
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
            this.txtStartFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEvents = new System.Windows.Forms.TextBox();
            this.btnXuatICal = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm bắt đầu";
            // 
            // txtStartFrom
            // 
            this.txtStartFrom.Location = new System.Drawing.Point(99, 28);
            this.txtStartFrom.Name = "txtStartFrom";
            this.txtStartFrom.Size = new System.Drawing.Size(95, 20);
            this.txtStartFrom.TabIndex = 1;
            this.txtStartFrom.Text = "2012";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Các ngày đưa vào (ngày/tháng: Tên sự kiện)";
            // 
            // txtEvents
            // 
            this.txtEvents.Location = new System.Drawing.Point(26, 94);
            this.txtEvents.Multiline = true;
            this.txtEvents.Name = "txtEvents";
            this.txtEvents.Size = new System.Drawing.Size(434, 246);
            this.txtEvents.TabIndex = 3;
            // 
            // btnXuatICal
            // 
            this.btnXuatICal.Location = new System.Drawing.Point(26, 346);
            this.btnXuatICal.Name = "btnXuatICal";
            this.btnXuatICal.Size = new System.Drawing.Size(75, 23);
            this.btnXuatICal.TabIndex = 4;
            this.btnXuatICal.Text = "Xuất iCal";
            this.btnXuatICal.UseVisualStyleBackColor = true;
            this.btnXuatICal.Click += new System.EventHandler(this.btnXuatICal_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(239, 28);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(95, 20);
            this.txtTo.TabIndex = 1;
            this.txtTo.Text = "2015";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "đến";
            // 
            // ExportAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 381);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXuatICal);
            this.Controls.Add(this.txtEvents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtStartFrom);
            this.Controls.Add(this.label1);
            this.Name = "ExportAD";
            this.Text = "Lịch sự kiện âm lịch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEvents;
        private System.Windows.Forms.Button btnXuatICal;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label3;
    }
}