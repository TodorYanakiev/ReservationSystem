﻿
namespace PresentationLayerForms
{
    partial class FormAdmin
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
            label2 = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnNewAdminAccount = new Button();
            chkStartDate = new CheckBox();
            chkEndDate = new CheckBox();
            chkExactDate = new CheckBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            dtpExactDate = new DateTimePicker();
            btnSearch = new Button();
            chkIsVerified = new CheckBox();
            chkIncludeCancelled = new CheckBox();
            chkIncludePassed = new CheckBox();
            btnAddTable = new Button();
            btnOccasions = new Button();
            btnBack = new Button();
            button1 = new Button();
            btnOperatingHour = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(630, 84);
            label2.Name = "label2";
            label2.Size = new Size(277, 50);
            label2.TabIndex = 5;
            label2.Text = "Добре дошли!";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(488, 17);
            label1.Name = "label1";
            label1.Size = new Size(517, 50);
            label1.TabIndex = 4;
            label1.Text = "Администраторски панел";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(438, 305);
            flowLayoutPanel1.Margin = new Padding(3, 5, 3, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(664, 199);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // btnNewAdminAccount
            // 
            btnNewAdminAccount.BackColor = Color.White;
            btnNewAdminAccount.FlatStyle = FlatStyle.Flat;
            btnNewAdminAccount.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnNewAdminAccount.ForeColor = Color.Green;
            btnNewAdminAccount.Location = new Point(679, 607);
            btnNewAdminAccount.Margin = new Padding(3, 5, 3, 5);
            btnNewAdminAccount.Name = "btnNewAdminAccount";
            btnNewAdminAccount.Size = new Size(240, 93);
            btnNewAdminAccount.TabIndex = 8;
            btnNewAdminAccount.Text = "Администратори";
            btnNewAdminAccount.UseVisualStyleBackColor = false;
            btnNewAdminAccount.Click += btnNewAdminAccount_Click;
            // 
            // chkStartDate
            // 
            chkStartDate.AutoSize = true;
            chkStartDate.BackColor = Color.Green;
            chkStartDate.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic);
            chkStartDate.ForeColor = SystemColors.Control;
            chkStartDate.Location = new Point(342, 200);
            chkStartDate.Margin = new Padding(3, 5, 3, 5);
            chkStartDate.Name = "chkStartDate";
            chkStartDate.Size = new Size(157, 29);
            chkStartDate.TabIndex = 10;
            chkStartDate.Text = "начална дата";
            chkStartDate.UseVisualStyleBackColor = false;
            chkStartDate.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chkEndDate
            // 
            chkEndDate.AutoSize = true;
            chkEndDate.BackColor = Color.Green;
            chkEndDate.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic);
            chkEndDate.ForeColor = SystemColors.Control;
            chkEndDate.Location = new Point(725, 200);
            chkEndDate.Margin = new Padding(3, 5, 3, 5);
            chkEndDate.Name = "chkEndDate";
            chkEndDate.Size = new Size(145, 29);
            chkEndDate.TabIndex = 11;
            chkEndDate.Text = "крайна дата";
            chkEndDate.UseVisualStyleBackColor = false;
            chkEndDate.CheckedChanged += chkEndDate_CheckedChanged;
            // 
            // chkExactDate
            // 
            chkExactDate.AutoSize = true;
            chkExactDate.BackColor = Color.Green;
            chkExactDate.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic);
            chkExactDate.ForeColor = SystemColors.Control;
            chkExactDate.Location = new Point(1139, 200);
            chkExactDate.Margin = new Padding(3, 5, 3, 5);
            chkExactDate.Name = "chkExactDate";
            chkExactDate.Size = new Size(142, 29);
            chkExactDate.TabIndex = 12;
            chkExactDate.Text = "точна дата";
            chkExactDate.UseVisualStyleBackColor = false;
            chkExactDate.CheckedChanged += chkExactDate_CheckedChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(277, 253);
            dtpStartDate.Margin = new Padding(3, 5, 3, 5);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 13;
            dtpStartDate.Visible = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(661, 253);
            dtpEndDate.Margin = new Padding(3, 5, 3, 5);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 14;
            dtpEndDate.Visible = false;
            // 
            // dtpExactDate
            // 
            dtpExactDate.Format = DateTimePickerFormat.Short;
            dtpExactDate.Location = new Point(1066, 253);
            dtpExactDate.Margin = new Padding(3, 5, 3, 5);
            dtpExactDate.Name = "dtpExactDate";
            dtpExactDate.Size = new Size(250, 27);
            dtpExactDate.TabIndex = 15;
            dtpExactDate.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Bold);
            btnSearch.Location = new Point(1241, 305);
            btnSearch.Margin = new Padding(3, 5, 3, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(107, 39);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "търси";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chkIsVerified
            // 
            chkIsVerified.AutoSize = true;
            chkIsVerified.BackColor = Color.Transparent;
            chkIsVerified.FlatStyle = FlatStyle.Flat;
            chkIsVerified.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic);
            chkIsVerified.Location = new Point(1139, 17);
            chkIsVerified.Margin = new Padding(3, 5, 3, 5);
            chkIsVerified.Name = "chkIsVerified";
            chkIsVerified.Size = new Size(233, 27);
            chkIsVerified.TabIndex = 17;
            chkIsVerified.Text = "Потвърдени резервации";
            chkIsVerified.UseVisualStyleBackColor = false;
            chkIsVerified.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // chkIncludeCancelled
            // 
            chkIncludeCancelled.AutoSize = true;
            chkIncludeCancelled.BackColor = Color.Transparent;
            chkIncludeCancelled.FlatStyle = FlatStyle.Flat;
            chkIncludeCancelled.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic);
            chkIncludeCancelled.Location = new Point(1139, 64);
            chkIncludeCancelled.Margin = new Padding(3, 5, 3, 5);
            chkIncludeCancelled.Name = "chkIncludeCancelled";
            chkIncludeCancelled.Size = new Size(276, 27);
            chkIncludeCancelled.TabIndex = 18;
            chkIncludeCancelled.Text = "Включи отказани резервации";
            chkIncludeCancelled.UseVisualStyleBackColor = false;
            chkIncludeCancelled.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // chkIncludePassed
            // 
            chkIncludePassed.AutoSize = true;
            chkIncludePassed.BackColor = Color.Transparent;
            chkIncludePassed.FlatStyle = FlatStyle.Flat;
            chkIncludePassed.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic);
            chkIncludePassed.Location = new Point(1139, 111);
            chkIncludePassed.Margin = new Padding(3, 5, 3, 5);
            chkIncludePassed.Name = "chkIncludePassed";
            chkIncludePassed.Size = new Size(281, 27);
            chkIncludePassed.TabIndex = 19;
            chkIncludePassed.Text = "Включи отминали резервации";
            chkIncludePassed.UseVisualStyleBackColor = false;
            // 
            // btnAddTable
            // 
            btnAddTable.BackColor = Color.White;
            btnAddTable.FlatStyle = FlatStyle.Flat;
            btnAddTable.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnAddTable.ForeColor = Color.Green;
            btnAddTable.Location = new Point(398, 607);
            btnAddTable.Margin = new Padding(3, 5, 3, 5);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(274, 93);
            btnAddTable.TabIndex = 20;
            btnAddTable.Text = "Маси";
            btnAddTable.UseVisualStyleBackColor = false;
            btnAddTable.Click += button1_Click;
            // 
            // btnOccasions
            // 
            btnOccasions.BackColor = Color.White;
            btnOccasions.FlatStyle = FlatStyle.Flat;
            btnOccasions.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnOccasions.ForeColor = Color.Green;
            btnOccasions.Location = new Point(1189, 607);
            btnOccasions.Margin = new Padding(3, 5, 3, 5);
            btnOccasions.Name = "btnOccasions";
            btnOccasions.Size = new Size(274, 93);
            btnOccasions.TabIndex = 21;
            btnOccasions.Text = "Неработни дни";
            btnOccasions.UseVisualStyleBackColor = false;
            btnOccasions.Click += btnOccasions_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.Green;
            btnBack.Location = new Point(10, 416);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(163, 70);
            btnBack.TabIndex = 22;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            button1.ForeColor = Color.Green;
            button1.Location = new Point(117, 607);
            button1.Margin = new Padding(3, 5, 3, 5);
            button1.Name = "button1";
            button1.Size = new Size(274, 93);
            button1.TabIndex = 22;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnOperatingHour
            // 
            btnOperatingHour.BackColor = Color.White;
            btnOperatingHour.FlatStyle = FlatStyle.Flat;
            btnOperatingHour.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnOperatingHour.ForeColor = Color.Green;
            btnOperatingHour.Location = new Point(925, 607);
            btnOperatingHour.Margin = new Padding(3, 5, 3, 5);
            btnOperatingHour.Name = "btnOperatingHour";
            btnOperatingHour.Size = new Size(258, 93);
            btnOperatingHour.TabIndex = 23;
            btnOperatingHour.Text = "Работно време";
            btnOperatingHour.UseVisualStyleBackColor = false;
            btnOperatingHour.Click += btnOperatingHour_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormAdmin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1623, 763);
            Controls.Add(btnOperatingHour);
            Controls.Add(button1);
            Controls.Add(btnOccasions);
            Controls.Add(btnAddTable);
            Controls.Add(chkIncludePassed);
            Controls.Add(chkIncludeCancelled);
            Controls.Add(chkIsVerified);
            Controls.Add(btnSearch);
            Controls.Add(dtpExactDate);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(chkExactDate);
            Controls.Add(chkEndDate);
            Controls.Add(chkStartDate);
            Controls.Add(btnNewAdminAccount);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAdmin";
            Text = "FormAdmin";
            Load += FormAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAddReservation;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnNewAdminAccount;
        private CheckBox chkStartDate;
        private CheckBox chkEndDate;
        private CheckBox chkExactDate;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpExactDate;
        private Button btnSearch;
        private CheckBox chkIsVerified;
        private CheckBox chkIncludeCancelled;
        private CheckBox chkIncludePassed;
        private Button btnAddTable;
        private Button btnOccasions;
        private Button btnBack;
        private Button button1;
        private Button btnOperatingHour;
    }
}