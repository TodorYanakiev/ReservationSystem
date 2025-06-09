namespace PresentationLayerForms
{
    partial class FormSpecialOccasion
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
            tabCreateOccasion = new TabControl();
            tabPage1 = new TabPage();
            btnAddOccasion = new Button();
            txtOccasionDescription = new TextBox();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            cmbTables = new ComboBox();
            lblDescription = new Label();
            lblEnd = new Label();
            lblStart = new Label();
            lblTable = new Label();
            tabPage2 = new TabPage();
            flowOccasions = new FlowLayoutPanel();
            btnHomeMenu = new Button();
            btnAdminMenu = new Button();
            label1 = new Label();
            tabCreateOccasion.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabCreateOccasion
            // 
            tabCreateOccasion.Controls.Add(tabPage1);
            tabCreateOccasion.Controls.Add(tabPage2);
            tabCreateOccasion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabCreateOccasion.Location = new Point(151, 79);
            tabCreateOccasion.Name = "tabCreateOccasion";
            tabCreateOccasion.SelectedIndex = 0;
            tabCreateOccasion.Size = new Size(1141, 352);
            tabCreateOccasion.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnAddOccasion);
            tabPage1.Controls.Add(txtOccasionDescription);
            tabPage1.Controls.Add(dtpEndTime);
            tabPage1.Controls.Add(dtpStartTime);
            tabPage1.Controls.Add(cmbTables);
            tabPage1.Controls.Add(lblDescription);
            tabPage1.Controls.Add(lblEnd);
            tabPage1.Controls.Add(lblStart);
            tabPage1.Controls.Add(lblTable);
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1133, 311);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Добави";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddOccasion
            // 
            btnAddOccasion.Font = new Font("Segoe UI Variable Text", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddOccasion.ForeColor = Color.Olive;
            btnAddOccasion.Location = new Point(932, 235);
            btnAddOccasion.Name = "btnAddOccasion";
            btnAddOccasion.Size = new Size(167, 58);
            btnAddOccasion.TabIndex = 8;
            btnAddOccasion.Text = "Добави";
            btnAddOccasion.UseVisualStyleBackColor = true;
            btnAddOccasion.Click += btnAddOccasion_Click;
            // 
            // txtOccasionDescription
            // 
            txtOccasionDescription.Location = new Point(728, 38);
            txtOccasionDescription.Multiline = true;
            txtOccasionDescription.Name = "txtOccasionDescription";
            txtOccasionDescription.Size = new Size(354, 146);
            txtOccasionDescription.TabIndex = 7;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(203, 238);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(250, 34);
            dtpEndTime.TabIndex = 6;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(203, 162);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(250, 34);
            dtpStartTime.TabIndex = 5;
            // 
            // cmbTables
            // 
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new Point(302, 45);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new Size(151, 36);
            cmbTables.TabIndex = 4;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(549, 41);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(159, 38);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Описание:";
            lblDescription.Click += lblDescription_Click;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnd.Location = new Point(58, 232);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(93, 38);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "Край:";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStart.Location = new Point(58, 156);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(127, 38);
            lblStart.TabIndex = 1;
            lblStart.Text = "Начало:";
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTable.Location = new Point(40, 41);
            lblTable.Name = "lblTable";
            lblTable.Size = new Size(225, 38);
            lblTable.TabIndex = 0;
            lblTable.Text = "Изберете маса:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flowOccasions);
            tabPage2.Location = new Point(4, 37);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1133, 311);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Всички";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowOccasions
            // 
            flowOccasions.AutoScroll = true;
            flowOccasions.FlowDirection = FlowDirection.TopDown;
            flowOccasions.Location = new Point(15, 6);
            flowOccasions.Name = "flowOccasions";
            flowOccasions.Size = new Size(1104, 299);
            flowOccasions.TabIndex = 0;
            flowOccasions.WrapContents = false;
            // 
            // btnHomeMenu
            // 
            btnHomeMenu.BackColor = Color.White;
            btnHomeMenu.FlatStyle = FlatStyle.Flat;
            btnHomeMenu.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHomeMenu.ForeColor = Color.Goldenrod;
            btnHomeMenu.Location = new Point(278, 461);
            btnHomeMenu.Name = "btnHomeMenu";
            btnHomeMenu.Size = new Size(347, 77);
            btnHomeMenu.TabIndex = 1;
            btnHomeMenu.Text = "Начално меню";
            btnHomeMenu.UseVisualStyleBackColor = false;
            btnHomeMenu.Click += btnHomeMenu_Click;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.BackColor = Color.White;
            btnAdminMenu.FlatStyle = FlatStyle.Flat;
            btnAdminMenu.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminMenu.ForeColor = Color.Goldenrod;
            btnAdminMenu.Location = new Point(822, 461);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(347, 77);
            btnAdminMenu.TabIndex = 2;
            btnAdminMenu.Text = "Администраторско меню";
            btnAdminMenu.UseVisualStyleBackColor = false;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(558, 26);
            label1.Name = "label1";
            label1.Size = new Size(359, 50);
            label1.TabIndex = 3;
            label1.Text = "Специални поводи";
            // 
            // FormSpecialOccasion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.FormSpecialOccasion;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1420, 572);
            Controls.Add(label1);
            Controls.Add(btnAdminMenu);
            Controls.Add(btnHomeMenu);
            Controls.Add(tabCreateOccasion);
            Name = "FormSpecialOccasion";
            Text = "FormSpecialOccasion";
            Load += FormSpecialOccasion_Load;
            tabCreateOccasion.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabCreateOccasion;
        private TabPage tabPage1;
        private Label lblDescription;
        private Label lblEnd;
        private Label lblStart;
        private Label lblTable;
        private TabPage tabPage2;
        private Button btnAddOccasion;
        private TextBox txtOccasionDescription;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private ComboBox cmbTables;
        private FlowLayoutPanel flowOccasions;
        private Button btnHomeMenu;
        private Button btnAdminMenu;
        private Label label1;
    }
}