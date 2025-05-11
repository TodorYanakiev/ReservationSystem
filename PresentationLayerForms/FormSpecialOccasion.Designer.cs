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
            tabCreateOccasion.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabCreateOccasion
            // 
            tabCreateOccasion.Controls.Add(tabPage1);
            tabCreateOccasion.Controls.Add(tabPage2);
            tabCreateOccasion.Location = new Point(12, 12);
            tabCreateOccasion.Name = "tabCreateOccasion";
            tabCreateOccasion.SelectedIndex = 0;
            tabCreateOccasion.Size = new Size(598, 424);
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
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(590, 391);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Добави";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddOccasion
            // 
            btnAddOccasion.Location = new Point(104, 323);
            btnAddOccasion.Name = "btnAddOccasion";
            btnAddOccasion.Size = new Size(94, 29);
            btnAddOccasion.TabIndex = 8;
            btnAddOccasion.Text = "Добави";
            btnAddOccasion.UseVisualStyleBackColor = true;
            btnAddOccasion.Click += btnAddOccasion_Click;
            // 
            // txtOccasionDescription
            // 
            txtOccasionDescription.Location = new Point(122, 260);
            txtOccasionDescription.Name = "txtOccasionDescription";
            txtOccasionDescription.Size = new Size(125, 27);
            txtOccasionDescription.TabIndex = 7;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(104, 180);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(250, 27);
            dtpEndTime.TabIndex = 6;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(104, 94);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(250, 27);
            dtpStartTime.TabIndex = 5;
            // 
            // cmbTables
            // 
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new Point(142, 26);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new Size(151, 28);
            cmbTables.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(24, 263);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(82, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Описание:";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(24, 187);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(47, 20);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "Край:";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(24, 101);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(64, 20);
            lblStart.TabIndex = 1;
            lblStart.Text = "Начало:";
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.Location = new Point(24, 34);
            lblTable.Name = "lblTable";
            lblTable.Size = new Size(116, 20);
            lblTable.TabIndex = 0;
            lblTable.Text = "Изберете маса:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flowOccasions);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(590, 391);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Всички";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowOccasions
            // 
            flowOccasions.AutoScroll = true;
            flowOccasions.FlowDirection = FlowDirection.TopDown;
            flowOccasions.Location = new Point(6, 16);
            flowOccasions.Name = "flowOccasions";
            flowOccasions.Size = new Size(448, 318);
            flowOccasions.TabIndex = 0;
            flowOccasions.WrapContents = false;
            // 
            // btnHomeMenu
            // 
            btnHomeMenu.Location = new Point(88, 446);
            btnHomeMenu.Name = "btnHomeMenu";
            btnHomeMenu.Size = new Size(189, 74);
            btnHomeMenu.TabIndex = 1;
            btnHomeMenu.Text = "Начално меню";
            btnHomeMenu.UseVisualStyleBackColor = true;
            btnHomeMenu.Click += btnHomeMenu_Click;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Location = new Point(336, 446);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(201, 74);
            btnAdminMenu.TabIndex = 2;
            btnAdminMenu.Text = "Администраторско меню";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // FormSpecialOccasion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 536);
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
    }
}