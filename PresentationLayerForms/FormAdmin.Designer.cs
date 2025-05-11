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
            btnAddReservation = new Button();
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
            SuspendLayout();
            // 
            // btnAddReservation
            // 
            btnAddReservation.BackColor = Color.Transparent;
            btnAddReservation.FlatStyle = FlatStyle.Flat;
            btnAddReservation.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddReservation.ForeColor = Color.Green;
            btnAddReservation.Location = new Point(581, 416);
            btnAddReservation.Name = "btnAddReservation";
            btnAddReservation.Size = new Size(163, 70);
            btnAddReservation.TabIndex = 6;
            btnAddReservation.Text = "Добави резервация";
            btnAddReservation.UseVisualStyleBackColor = false;
            btnAddReservation.Click += btnAddReservation_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(222, 44);
            label2.Name = "label2";
            label2.Size = new Size(225, 41);
            label2.TabIndex = 5;
            label2.Text = "Добре дошли!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(137, 6);
            label1.Name = "label1";
            label1.Size = new Size(395, 38);
            label1.TabIndex = 4;
            label1.Text = "Администраторски панел";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(100, 202);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(700, 199);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // btnNewAdminAccount
            // 
            btnNewAdminAccount.BackColor = Color.Transparent;
            btnNewAdminAccount.FlatStyle = FlatStyle.Flat;
            btnNewAdminAccount.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewAdminAccount.ForeColor = Color.Green;
            btnNewAdminAccount.Location = new Point(348, 416);
            btnNewAdminAccount.Name = "btnNewAdminAccount";
            btnNewAdminAccount.Size = new Size(227, 70);
            btnNewAdminAccount.TabIndex = 8;
            btnNewAdminAccount.Text = "Администратори";
            btnNewAdminAccount.UseVisualStyleBackColor = false;
            btnNewAdminAccount.Click += btnNewAdminAccount_Click;
            // 
            // chkStartDate
            // 
            chkStartDate.AutoSize = true;
            chkStartDate.BackColor = Color.Green;
            chkStartDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chkStartDate.ForeColor = Color.White;
            chkStartDate.Location = new Point(71, 122);
            chkStartDate.Name = "chkStartDate";
            chkStartDate.Size = new Size(178, 32);
            chkStartDate.TabIndex = 10;
            chkStartDate.Text = "начална дата";
            chkStartDate.UseVisualStyleBackColor = false;
            chkStartDate.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chkEndDate
            // 
            chkEndDate.AutoSize = true;
            chkEndDate.BackColor = Color.Green;
            chkEndDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chkEndDate.ForeColor = Color.White;
            chkEndDate.Location = new Point(379, 122);
            chkEndDate.Name = "chkEndDate";
            chkEndDate.Size = new Size(165, 32);
            chkEndDate.TabIndex = 11;
            chkEndDate.Text = "крайна дата";
            chkEndDate.UseVisualStyleBackColor = false;
            chkEndDate.CheckedChanged += chkEndDate_CheckedChanged;
            // 
            // chkExactDate
            // 
            chkExactDate.AutoSize = true;
            chkExactDate.BackColor = Color.Green;
            chkExactDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chkExactDate.ForeColor = Color.White;
            chkExactDate.Location = new Point(686, 122);
            chkExactDate.Name = "chkExactDate";
            chkExactDate.Size = new Size(160, 32);
            chkExactDate.TabIndex = 12;
            chkExactDate.Text = "точна дата";
            chkExactDate.UseVisualStyleBackColor = false;
            chkExactDate.CheckedChanged += chkExactDate_CheckedChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(36, 162);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 13;
            dtpStartDate.Visible = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(331, 162);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 14;
            dtpEndDate.Visible = false;
            // 
            // dtpExactDate
            // 
            dtpExactDate.Format = DateTimePickerFormat.Short;
            dtpExactDate.Location = new Point(630, 162);
            dtpExactDate.Name = "dtpExactDate";
            dtpExactDate.Size = new Size(250, 27);
            dtpExactDate.TabIndex = 15;
            dtpExactDate.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(806, 202);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(107, 49);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "търси";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chkIsVerified
            // 
            chkIsVerified.AutoSize = true;
            chkIsVerified.BackColor = Color.Transparent;
            chkIsVerified.Font = new Font("Segoe UI", 12F);
            chkIsVerified.Location = new Point(538, 14);
            chkIsVerified.Name = "chkIsVerified";
            chkIsVerified.Size = new Size(263, 32);
            chkIsVerified.TabIndex = 17;
            chkIsVerified.Text = "Потвърдени резервации";
            chkIsVerified.UseVisualStyleBackColor = false;
            chkIsVerified.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // chkIncludeCancelled
            // 
            chkIncludeCancelled.AutoSize = true;
            chkIncludeCancelled.BackColor = Color.Transparent;
            chkIncludeCancelled.Font = new Font("Segoe UI", 12F);
            chkIncludeCancelled.Location = new Point(538, 44);
            chkIncludeCancelled.Name = "chkIncludeCancelled";
            chkIncludeCancelled.Size = new Size(308, 32);
            chkIncludeCancelled.TabIndex = 18;
            chkIncludeCancelled.Text = "Включи отказани резервации";
            chkIncludeCancelled.UseVisualStyleBackColor = false;
            chkIncludeCancelled.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // chkIncludePassed
            // 
            chkIncludePassed.AutoSize = true;
            chkIncludePassed.BackColor = Color.Transparent;
            chkIncludePassed.Font = new Font("Segoe UI", 12F);
            chkIncludePassed.Location = new Point(538, 74);
            chkIncludePassed.Name = "chkIncludePassed";
            chkIncludePassed.Size = new Size(316, 32);
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
            btnAddTable.Location = new Point(179, 416);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(163, 70);
            btnAddTable.TabIndex = 20;
            btnAddTable.Text = "Маси";
            btnAddTable.UseVisualStyleBackColor = false;
            btnAddTable.Click += button1_Click;
            // 
            // btnOccasions
            // 
            btnOccasions.BackColor = Color.Transparent;
            btnOccasions.FlatStyle = FlatStyle.Flat;
            btnOccasions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOccasions.ForeColor = Color.Green;
            btnOccasions.Location = new Point(750, 416);
            btnOccasions.Name = "btnOccasions";
            btnOccasions.Size = new Size(163, 70);
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
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormAdmin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(923, 497);
            Controls.Add(btnBack);
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
            Controls.Add(btnAddReservation);
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
    }
}