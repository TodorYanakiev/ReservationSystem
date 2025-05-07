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
            flowLayoutPanel1.Location = new Point(100, 120);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(700, 250);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // btnNewAdminAccount
            // 
            btnNewAdminAccount.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewAdminAccount.ForeColor = SystemColors.HotTrack;
            btnNewAdminAccount.Location = new Point(100, 391);
            btnNewAdminAccount.Name = "btnNewAdminAccount";
            btnNewAdminAccount.Size = new Size(361, 70);
            btnNewAdminAccount.TabIndex = 8;
            btnNewAdminAccount.Text = "Добави нов администраторски профил";
            btnNewAdminAccount.UseVisualStyleBackColor = true;
            btnNewAdminAccount.Click += btnNewAdminAccount_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormAdmin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(923, 497);
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
    }
}