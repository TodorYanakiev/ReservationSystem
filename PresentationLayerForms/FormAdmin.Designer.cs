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
            SuspendLayout();
            // 
            // btnAddReservation
            // 
            btnAddReservation.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddReservation.ForeColor = SystemColors.HotTrack;
            btnAddReservation.Location = new Point(357, 293);
            btnAddReservation.Margin = new Padding(3, 2, 3, 2);
            btnAddReservation.Name = "btnAddReservation";
            btnAddReservation.Size = new Size(220, 52);
            btnAddReservation.TabIndex = 6;
            btnAddReservation.Text = "Добави резервация";
            btnAddReservation.UseVisualStyleBackColor = true;
            btnAddReservation.Click += btnAddReservation_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(312, 50);
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
            label1.ForeColor = Color.White;
            label1.Location = new Point(231, 14);
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
            flowLayoutPanel1.Location = new Point(88, 128);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(612, 149);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // btnNewAdminAccount
            // 
            btnNewAdminAccount.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewAdminAccount.ForeColor = SystemColors.HotTrack;
            btnNewAdminAccount.Location = new Point(137, 293);
            btnNewAdminAccount.Margin = new Padding(3, 2, 3, 2);
            btnNewAdminAccount.Name = "btnNewAdminAccount";
            btnNewAdminAccount.Size = new Size(214, 52);
            btnNewAdminAccount.TabIndex = 8;
            btnNewAdminAccount.Text = "Администратори";
            btnNewAdminAccount.UseVisualStyleBackColor = true;
            btnNewAdminAccount.Click += btnNewAdminAccount_Click;
            // 
            // chkStartDate
            // 
            chkStartDate.AutoSize = true;
            chkStartDate.Location = new Point(122, 75);
            chkStartDate.Margin = new Padding(3, 2, 3, 2);
            chkStartDate.Name = "chkStartDate";
            chkStartDate.Size = new Size(98, 19);
            chkStartDate.TabIndex = 10;
            chkStartDate.Text = "начална дата";
            chkStartDate.UseVisualStyleBackColor = true;
            chkStartDate.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chkEndDate
            // 
            chkEndDate.AutoSize = true;
            chkEndDate.Location = new Point(353, 83);
            chkEndDate.Margin = new Padding(3, 2, 3, 2);
            chkEndDate.Name = "chkEndDate";
            chkEndDate.Size = new Size(91, 19);
            chkEndDate.TabIndex = 11;
            chkEndDate.Text = "крайна дата";
            chkEndDate.UseVisualStyleBackColor = true;
            chkEndDate.CheckedChanged += chkEndDate_CheckedChanged;
            // 
            // chkExactDate
            // 
            chkExactDate.AutoSize = true;
            chkExactDate.Location = new Point(581, 75);
            chkExactDate.Margin = new Padding(3, 2, 3, 2);
            chkExactDate.Name = "chkExactDate";
            chkExactDate.Size = new Size(84, 19);
            chkExactDate.TabIndex = 12;
            chkExactDate.Text = "точна дата";
            chkExactDate.UseVisualStyleBackColor = true;
            chkExactDate.CheckedChanged += chkExactDate_CheckedChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(29, 98);
            dtpStartDate.Margin = new Padding(3, 2, 3, 2);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(219, 23);
            dtpStartDate.TabIndex = 13;
            dtpStartDate.Visible = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(290, 106);
            dtpEndDate.Margin = new Padding(3, 2, 3, 2);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(219, 23);
            dtpEndDate.TabIndex = 14;
            dtpEndDate.Visible = false;
            // 
            // dtpExactDate
            // 
            dtpExactDate.Format = DateTimePickerFormat.Short;
            dtpExactDate.Location = new Point(532, 98);
            dtpExactDate.Margin = new Padding(3, 2, 3, 2);
            dtpExactDate.Name = "dtpExactDate";
            dtpExactDate.Size = new Size(219, 23);
            dtpExactDate.TabIndex = 15;
            dtpExactDate.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(715, 139);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(82, 22);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "търси";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chkIsVerified
            // 
            chkIsVerified.AutoSize = true;
            chkIsVerified.Location = new Point(10, 9);
            chkIsVerified.Margin = new Padding(3, 2, 3, 2);
            chkIsVerified.Name = "chkIsVerified";
            chkIsVerified.Size = new Size(156, 19);
            chkIsVerified.TabIndex = 17;
            chkIsVerified.Text = "потвърдена резервация";
            chkIsVerified.UseVisualStyleBackColor = true;
            chkIsVerified.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // chkIncludeCancelled
            // 
            chkIncludeCancelled.AutoSize = true;
            chkIncludeCancelled.Location = new Point(10, 32);
            chkIncludeCancelled.Margin = new Padding(3, 2, 3, 2);
            chkIncludeCancelled.Name = "chkIncludeCancelled";
            chkIncludeCancelled.Size = new Size(189, 19);
            chkIncludeCancelled.TabIndex = 18;
            chkIncludeCancelled.Text = "Включи отказани резервации";
            chkIncludeCancelled.UseVisualStyleBackColor = true;
            chkIncludeCancelled.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // chkIncludePassed
            // 
            chkIncludePassed.AutoSize = true;
            chkIncludePassed.Location = new Point(10, 54);
            chkIncludePassed.Margin = new Padding(3, 2, 3, 2);
            chkIncludePassed.Name = "chkIncludePassed";
            chkIncludePassed.Size = new Size(195, 19);
            chkIncludePassed.TabIndex = 19;
            chkIncludePassed.Text = "Включи отминали резервации";
            chkIncludePassed.UseVisualStyleBackColor = true;
            // 
            // btnAddTable
            // 
            btnAddTable.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnAddTable.ForeColor = SystemColors.HotTrack;
            btnAddTable.Location = new Point(10, 293);
            btnAddTable.Margin = new Padding(3, 2, 3, 2);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(122, 52);
            btnAddTable.TabIndex = 20;
            btnAddTable.Text = "Маси";
            btnAddTable.UseVisualStyleBackColor = true;
            btnAddTable.Click += button1_Click;
            // 
            // btnOccasions
            // 
            btnOccasions.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOccasions.ForeColor = SystemColors.HotTrack;
            btnOccasions.Location = new Point(581, 293);
            btnOccasions.Margin = new Padding(3, 2, 3, 2);
            btnOccasions.Name = "btnOccasions";
            btnOccasions.Size = new Size(119, 52);
            btnOccasions.TabIndex = 21;
            btnOccasions.Text = "Неработни дни";
            btnOccasions.UseVisualStyleBackColor = true;
            btnOccasions.Click += btnOccasions_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(808, 373);
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
    }
}