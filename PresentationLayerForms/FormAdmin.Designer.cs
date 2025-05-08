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
            SuspendLayout();
            // 
            // btnAddReservation
            // 
            btnAddReservation.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddReservation.ForeColor = SystemColors.HotTrack;
            btnAddReservation.Location = new Point(549, 391);
            btnAddReservation.Name = "btnAddReservation";
            btnAddReservation.Size = new Size(251, 70);
            btnAddReservation.TabIndex = 6;
            btnAddReservation.Text = "Добави резервация";
            btnAddReservation.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(356, 67);
            label2.Name = "label2";
            label2.Size = new Size(225, 41);
            label2.TabIndex = 5;
            label2.Text = "Добре дошли!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(264, 18);
            label1.Name = "label1";
            label1.Size = new Size(418, 41);
            label1.TabIndex = 4;
            label1.Text = "Администраторски панел";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(100, 171);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(700, 199);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // btnNewAdminAccount
            // 
            btnNewAdminAccount.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewAdminAccount.ForeColor = SystemColors.HotTrack;
            btnNewAdminAccount.Location = new Point(157, 391);
            btnNewAdminAccount.Name = "btnNewAdminAccount";
            btnNewAdminAccount.Size = new Size(361, 70);
            btnNewAdminAccount.TabIndex = 8;
            btnNewAdminAccount.Text = "Добави нов администраторски профил";
            btnNewAdminAccount.UseVisualStyleBackColor = true;
            btnNewAdminAccount.Click += btnNewAdminAccount_Click;
            // 
            // chkStartDate
            // 
            chkStartDate.AutoSize = true;
            chkStartDate.Location = new Point(139, 100);
            chkStartDate.Name = "chkStartDate";
            chkStartDate.Size = new Size(123, 24);
            chkStartDate.TabIndex = 10;
            chkStartDate.Text = "начална дата";
            chkStartDate.UseVisualStyleBackColor = true;
            chkStartDate.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chkEndDate
            // 
            chkEndDate.AutoSize = true;
            chkEndDate.Location = new Point(403, 111);
            chkEndDate.Name = "chkEndDate";
            chkEndDate.Size = new Size(115, 24);
            chkEndDate.TabIndex = 11;
            chkEndDate.Text = "крайна дата";
            chkEndDate.UseVisualStyleBackColor = true;
            chkEndDate.CheckedChanged += chkEndDate_CheckedChanged;
            // 
            // chkExactDate
            // 
            chkExactDate.AutoSize = true;
            chkExactDate.Location = new Point(664, 100);
            chkExactDate.Name = "chkExactDate";
            chkExactDate.Size = new Size(105, 24);
            chkExactDate.TabIndex = 12;
            chkExactDate.Text = "точна дата";
            chkExactDate.UseVisualStyleBackColor = true;
            chkExactDate.CheckedChanged += chkExactDate_CheckedChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(33, 130);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 13;
            dtpStartDate.Visible = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(331, 141);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 14;
            dtpEndDate.Visible = false;
            // 
            // dtpExactDate
            // 
            dtpExactDate.Format = DateTimePickerFormat.Short;
            dtpExactDate.Location = new Point(608, 130);
            dtpExactDate.Name = "dtpExactDate";
            dtpExactDate.Size = new Size(250, 27);
            dtpExactDate.TabIndex = 15;
            dtpExactDate.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(817, 185);
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
            chkIsVerified.Location = new Point(12, 12);
            chkIsVerified.Name = "chkIsVerified";
            chkIsVerified.Size = new Size(201, 24);
            chkIsVerified.TabIndex = 17;
            chkIsVerified.Text = "потвърдена резервация";
            chkIsVerified.UseVisualStyleBackColor = true;
            chkIsVerified.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // chkIncludeCancelled
            // 
            chkIncludeCancelled.AutoSize = true;
            chkIncludeCancelled.Location = new Point(12, 42);
            chkIncludeCancelled.Name = "chkIncludeCancelled";
            chkIncludeCancelled.Size = new Size(239, 24);
            chkIncludeCancelled.TabIndex = 18;
            chkIncludeCancelled.Text = "Включи отказани резервации";
            chkIncludeCancelled.UseVisualStyleBackColor = true;
            chkIncludeCancelled.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // chkIncludePassed
            // 
            chkIncludePassed.AutoSize = true;
            chkIncludePassed.Location = new Point(12, 72);
            chkIncludePassed.Name = "chkIncludePassed";
            chkIncludePassed.Size = new Size(245, 24);
            chkIncludePassed.TabIndex = 19;
            chkIncludePassed.Text = "Включи отминали резервации";
            chkIncludePassed.UseVisualStyleBackColor = true;
            // 
            // btnAddTable
            // 
            btnAddTable.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnAddTable.ForeColor = SystemColors.HotTrack;
            btnAddTable.Location = new Point(12, 391);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(94, 70);
            btnAddTable.TabIndex = 20;
            btnAddTable.Text = "Добави маса";
            btnAddTable.UseVisualStyleBackColor = true;
            btnAddTable.Click += button1_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(923, 497);
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
    }
}