
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
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(196, 40);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 5;
            label2.Text = "Добре дошли!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(114, 7);
            label1.Name = "label1";
            label1.Size = new Size(333, 32);
            label1.TabIndex = 4;
            label1.Text = "Администраторски панел";
            label1.Click += label1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(100, 155);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(581, 149);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // btnNewAdminAccount
            // 
            btnNewAdminAccount.BackColor = Color.Transparent;
            btnNewAdminAccount.FlatStyle = FlatStyle.Flat;
            btnNewAdminAccount.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnNewAdminAccount.ForeColor = Color.Green;
            btnNewAdminAccount.Location = new Point(335, 310);
            btnNewAdminAccount.Name = "btnNewAdminAccount";
            btnNewAdminAccount.Size = new Size(210, 52);
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
            chkStartDate.Location = new Point(88, 96);
            chkStartDate.Name = "chkStartDate";
            chkStartDate.Size = new Size(134, 24);
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
            chkEndDate.Location = new Point(345, 96);
            chkEndDate.Name = "chkEndDate";
            chkEndDate.Size = new Size(125, 24);
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
            chkExactDate.Location = new Point(606, 93);
            chkExactDate.Name = "chkExactDate";
            chkExactDate.Size = new Size(119, 24);
            chkExactDate.TabIndex = 12;
            chkExactDate.Text = "точна дата";
            chkExactDate.UseVisualStyleBackColor = false;
            chkExactDate.CheckedChanged += chkExactDate_CheckedChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(38, 126);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(219, 23);
            dtpStartDate.TabIndex = 13;
            dtpStartDate.Visible = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(296, 126);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(219, 23);
            dtpEndDate.TabIndex = 14;
            dtpEndDate.Visible = false;
            // 
            // dtpExactDate
            // 
            dtpExactDate.Format = DateTimePickerFormat.Short;
            dtpExactDate.Location = new Point(546, 126);
            dtpExactDate.Name = "dtpExactDate";
            dtpExactDate.Size = new Size(219, 23);
            dtpExactDate.TabIndex = 15;
            dtpExactDate.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Bold);
            btnSearch.Location = new Point(694, 155);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
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
            chkIsVerified.Location = new Point(499, 7);
            chkIsVerified.Name = "chkIsVerified";
            chkIsVerified.Size = new Size(189, 23);
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
            chkIncludeCancelled.Location = new Point(499, 33);
            chkIncludeCancelled.Name = "chkIncludeCancelled";
            chkIncludeCancelled.Size = new Size(224, 23);
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
            chkIncludePassed.Location = new Point(499, 59);
            chkIncludePassed.Name = "chkIncludePassed";
            chkIncludePassed.Size = new Size(229, 23);
            chkIncludePassed.TabIndex = 19;
            chkIncludePassed.Text = "Включи отминали резервации";
            chkIncludePassed.UseVisualStyleBackColor = false;
            // 
            // btnAddTable
            // 
            btnAddTable.BackColor = Color.Transparent;
            btnAddTable.FlatStyle = FlatStyle.Flat;
            btnAddTable.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnAddTable.ForeColor = Color.Green;
            btnAddTable.Location = new Point(225, 310);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(104, 52);
            btnAddTable.TabIndex = 20;
            btnAddTable.Text = "Маси";
            btnAddTable.UseVisualStyleBackColor = false;
            btnAddTable.Click += button1_Click;
            // 
            // btnOccasions
            // 
            btnOccasions.BackColor = Color.Transparent;
            btnOccasions.FlatStyle = FlatStyle.Flat;
            btnOccasions.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnOccasions.ForeColor = Color.Green;
            btnOccasions.Location = new Point(551, 309);
            btnOccasions.Name = "btnOccasions";
            btnOccasions.Size = new Size(130, 52);
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
            btnBack.Click += btnBack_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            button1.ForeColor = Color.Green;
            button1.Location = new Point(100, 309);
            button1.Name = "button1";
            button1.Size = new Size(119, 52);
            button1.TabIndex = 22;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = false;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormAdmin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(808, 373);
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
            Margin = new Padding(3, 2, 3, 2);
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
    }
}