namespace PresentationLayerForms
{
    partial class FormOperatingHours
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
            tabControlOperatingHour = new TabControl();
            tabPageCreate = new TabPage();
            buttonCreateOH = new Button();
            buttonAddTimeSlot = new Button();
            dataGridTimeSlots = new DataGridView();
            StartTime = new DataGridViewTextBoxColumn();
            EndTime = new DataGridViewTextBoxColumn();
            checkedListBoxTables = new CheckedListBox();
            checkedListBoxDays = new CheckedListBox();
            tabPageManage = new TabPage();
            buttonDeleteOH = new Button();
            buttonEditOH = new Button();
            dataGridOperatingHours = new DataGridView();
            btnHome = new Button();
            btnAdminMenu = new Button();
            tabControlOperatingHour.SuspendLayout();
            tabPageCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTimeSlots).BeginInit();
            tabPageManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridOperatingHours).BeginInit();
            SuspendLayout();
            // 
            // tabControlOperatingHour
            // 
            tabControlOperatingHour.Controls.Add(tabPageCreate);
            tabControlOperatingHour.Controls.Add(tabPageManage);
            tabControlOperatingHour.Location = new Point(0, 0);
            tabControlOperatingHour.Name = "tabControlOperatingHour";
            tabControlOperatingHour.SelectedIndex = 0;
            tabControlOperatingHour.Size = new Size(788, 438);
            tabControlOperatingHour.TabIndex = 0;
            // 
            // tabPageCreate
            // 
            tabPageCreate.Controls.Add(buttonCreateOH);
            tabPageCreate.Controls.Add(buttonAddTimeSlot);
            tabPageCreate.Controls.Add(dataGridTimeSlots);
            tabPageCreate.Controls.Add(checkedListBoxTables);
            tabPageCreate.Controls.Add(checkedListBoxDays);
            tabPageCreate.Location = new Point(4, 29);
            tabPageCreate.Name = "tabPageCreate";
            tabPageCreate.Padding = new Padding(3);
            tabPageCreate.Size = new Size(780, 405);
            tabPageCreate.TabIndex = 0;
            tabPageCreate.Text = "Create";
            tabPageCreate.UseVisualStyleBackColor = true;
            // 
            // buttonCreateOH
            // 
            buttonCreateOH.Location = new Point(238, 329);
            buttonCreateOH.Name = "buttonCreateOH";
            buttonCreateOH.Size = new Size(94, 56);
            buttonCreateOH.TabIndex = 4;
            buttonCreateOH.Text = "operating hour create";
            buttonCreateOH.UseVisualStyleBackColor = true;
            buttonCreateOH.Click += buttonCreateOH_Click;
            // 
            // buttonAddTimeSlot
            // 
            buttonAddTimeSlot.Location = new Point(8, 329);
            buttonAddTimeSlot.Name = "buttonAddTimeSlot";
            buttonAddTimeSlot.Size = new Size(94, 56);
            buttonAddTimeSlot.TabIndex = 3;
            buttonAddTimeSlot.Text = "add time slot";
            buttonAddTimeSlot.UseVisualStyleBackColor = true;
            buttonAddTimeSlot.Click += buttonAddTimeSlot_Click;
            // 
            // dataGridTimeSlots
            // 
            dataGridTimeSlots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTimeSlots.Columns.AddRange(new DataGridViewColumn[] { StartTime, EndTime });
            dataGridTimeSlots.Location = new Point(386, 88);
            dataGridTimeSlots.Name = "dataGridTimeSlots";
            dataGridTimeSlots.RowHeadersWidth = 51;
            dataGridTimeSlots.Size = new Size(373, 297);
            dataGridTimeSlots.TabIndex = 2;
            // 
            // StartTime
            // 
            StartTime.HeaderText = "Start Time";
            StartTime.MinimumWidth = 6;
            StartTime.Name = "StartTime";
            StartTime.Width = 125;
            // 
            // EndTime
            // 
            EndTime.HeaderText = "End Time";
            EndTime.MinimumWidth = 6;
            EndTime.Name = "EndTime";
            EndTime.Width = 125;
            // 
            // checkedListBoxTables
            // 
            checkedListBoxTables.FormattingEnabled = true;
            checkedListBoxTables.Location = new Point(3, 173);
            checkedListBoxTables.Name = "checkedListBoxTables";
            checkedListBoxTables.Size = new Size(372, 136);
            checkedListBoxTables.TabIndex = 1;
            // 
            // checkedListBoxDays
            // 
            checkedListBoxDays.FormattingEnabled = true;
            checkedListBoxDays.Location = new Point(8, 8);
            checkedListBoxDays.Name = "checkedListBoxDays";
            checkedListBoxDays.Size = new Size(372, 158);
            checkedListBoxDays.TabIndex = 0;
            // 
            // tabPageManage
            // 
            tabPageManage.Controls.Add(buttonDeleteOH);
            tabPageManage.Controls.Add(buttonEditOH);
            tabPageManage.Controls.Add(dataGridOperatingHours);
            tabPageManage.Location = new Point(4, 29);
            tabPageManage.Name = "tabPageManage";
            tabPageManage.Padding = new Padding(3);
            tabPageManage.Size = new Size(780, 405);
            tabPageManage.TabIndex = 1;
            tabPageManage.Text = "Manage";
            tabPageManage.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteOH
            // 
            buttonDeleteOH.Location = new Point(683, 370);
            buttonDeleteOH.Name = "buttonDeleteOH";
            buttonDeleteOH.Size = new Size(94, 29);
            buttonDeleteOH.TabIndex = 2;
            buttonDeleteOH.Text = "Delete";
            buttonDeleteOH.UseVisualStyleBackColor = true;
            buttonDeleteOH.Click += buttonDeleteOH_Click;
            // 
            // buttonEditOH
            // 
            buttonEditOH.Location = new Point(573, 372);
            buttonEditOH.Name = "buttonEditOH";
            buttonEditOH.Size = new Size(94, 27);
            buttonEditOH.TabIndex = 1;
            buttonEditOH.Text = "Edit";
            buttonEditOH.UseVisualStyleBackColor = true;
            buttonEditOH.Click += buttonEditOH_Click;
            // 
            // dataGridOperatingHours
            // 
            dataGridOperatingHours.AllowUserToAddRows = false;
            dataGridOperatingHours.AllowUserToDeleteRows = false;
            dataGridOperatingHours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOperatingHours.Location = new Point(8, 6);
            dataGridOperatingHours.Name = "dataGridOperatingHours";
            dataGridOperatingHours.ReadOnly = true;
            dataGridOperatingHours.RowHeadersWidth = 51;
            dataGridOperatingHours.Size = new Size(745, 360);
            dataGridOperatingHours.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnHome.Location = new Point(790, 33);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(222, 81);
            btnHome.TabIndex = 14;
            btnHome.Text = "Начално меню";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAdminMenu.Location = new Point(790, 137);
            btnAdminMenu.Margin = new Padding(3, 4, 3, 4);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(222, 81);
            btnAdminMenu.TabIndex = 15;
            btnAdminMenu.Text = "Меню на администратор";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // FormOperatingHours
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 450);
            Controls.Add(btnAdminMenu);
            Controls.Add(btnHome);
            Controls.Add(tabControlOperatingHour);
            Name = "FormOperatingHours";
            Text = "FormOperatingHours";
            Load += FormOperatingHours_Load;
            tabControlOperatingHour.ResumeLayout(false);
            tabPageCreate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridTimeSlots).EndInit();
            tabPageManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridOperatingHours).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlOperatingHour;
        private TabPage tabPageCreate;
        private TabPage tabPageManage;
        private CheckedListBox checkedListBoxDays;
        private Button buttonCreateOH;
        private Button buttonAddTimeSlot;
        private DataGridView dataGridTimeSlots;
        private CheckedListBox checkedListBoxTables;
        private Button buttonDeleteOH;
        private Button buttonEditOH;
        private DataGridView dataGridOperatingHours;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
        private Button btnHome;
        private Button btnAdminMenu;
    }
}