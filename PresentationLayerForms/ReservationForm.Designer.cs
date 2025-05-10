namespace PresentationLayerForms
{
    partial class ReservationForm
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
            tabControlMain = new TabControl();
            tabMakeReservation = new TabPage();
            lblNotes = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblName = new Label();
            buttonSubmitReservation = new Button();
            textBoxNotes = new TextBox();
            textBoxPhone = new TextBox();
            textBoxEmail = new TextBox();
            textBoxName = new TextBox();
            flowLayoutCalendar = new FlowLayoutPanel();
            buttonNextWeek = new Button();
            buttonPrevWeek = new Button();
            comboBoxTables = new ComboBox();
            lblSelectTable = new Label();
            tabPage2 = new TabPage();
            btnMenu = new Button();
            tabControlMain.SuspendLayout();
            tabMakeReservation.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabMakeReservation);
            tabControlMain.Controls.Add(tabPage2);
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1117, 743);
            tabControlMain.TabIndex = 0;
            // 
            // tabMakeReservation
            // 
            tabMakeReservation.Controls.Add(lblNotes);
            tabMakeReservation.Controls.Add(lblPhone);
            tabMakeReservation.Controls.Add(lblEmail);
            tabMakeReservation.Controls.Add(lblName);
            tabMakeReservation.Controls.Add(buttonSubmitReservation);
            tabMakeReservation.Controls.Add(textBoxNotes);
            tabMakeReservation.Controls.Add(textBoxPhone);
            tabMakeReservation.Controls.Add(textBoxEmail);
            tabMakeReservation.Controls.Add(textBoxName);
            tabMakeReservation.Controls.Add(flowLayoutCalendar);
            tabMakeReservation.Controls.Add(buttonNextWeek);
            tabMakeReservation.Controls.Add(buttonPrevWeek);
            tabMakeReservation.Controls.Add(comboBoxTables);
            tabMakeReservation.Controls.Add(lblSelectTable);
            tabMakeReservation.Location = new Point(4, 29);
            tabMakeReservation.Name = "tabMakeReservation";
            tabMakeReservation.Padding = new Padding(3);
            tabMakeReservation.Size = new Size(1109, 710);
            tabMakeReservation.TabIndex = 0;
            tabMakeReservation.Text = "Make Reservation";
            tabMakeReservation.UseVisualStyleBackColor = true;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(603, 550);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(51, 20);
            lblNotes.TabIndex = 13;
            lblNotes.Text = "Notes:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(436, 550);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(53, 20);
            lblPhone.TabIndex = 12;
            lblPhone.Text = "Phone:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(272, 550);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(85, 550);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 10;
            lblName.Text = "Name:";
            // 
            // buttonSubmitReservation
            // 
            buttonSubmitReservation.Location = new Point(131, 658);
            buttonSubmitReservation.Name = "buttonSubmitReservation";
            buttonSubmitReservation.Size = new Size(326, 29);
            buttonSubmitReservation.TabIndex = 9;
            buttonSubmitReservation.Text = "Submit";
            buttonSubmitReservation.UseVisualStyleBackColor = true;
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(571, 596);
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.Size = new Size(125, 27);
            textBoxNotes.TabIndex = 8;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(403, 596);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(125, 27);
            textBoxPhone.TabIndex = 7;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(237, 596);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(125, 27);
            textBoxEmail.TabIndex = 6;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(49, 596);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(125, 27);
            textBoxName.TabIndex = 5;
            // 
            // flowLayoutCalendar
            // 
            flowLayoutCalendar.AutoScroll = true;
            flowLayoutCalendar.Location = new Point(120, 92);
            flowLayoutCalendar.Name = "flowLayoutCalendar";
            flowLayoutCalendar.Size = new Size(964, 436);
            flowLayoutCalendar.TabIndex = 4;
            // 
            // buttonNextWeek
            // 
            buttonNextWeek.Location = new Point(20, 136);
            buttonNextWeek.Name = "buttonNextWeek";
            buttonNextWeek.Size = new Size(94, 29);
            buttonNextWeek.TabIndex = 3;
            buttonNextWeek.Text = "Next week";
            buttonNextWeek.UseVisualStyleBackColor = true;
            // 
            // buttonPrevWeek
            // 
            buttonPrevWeek.Location = new Point(20, 92);
            buttonPrevWeek.Name = "buttonPrevWeek";
            buttonPrevWeek.Size = new Size(94, 29);
            buttonPrevWeek.TabIndex = 2;
            buttonPrevWeek.Text = "Prev week";
            buttonPrevWeek.UseVisualStyleBackColor = true;
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(147, 25);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(444, 28);
            comboBoxTables.TabIndex = 1;
            // 
            // lblSelectTable
            // 
            lblSelectTable.AutoSize = true;
            lblSelectTable.Location = new Point(24, 28);
            lblSelectTable.Name = "lblSelectTable";
            lblSelectTable.Size = new Size(90, 20);
            lblSelectTable.TabIndex = 0;
            lblSelectTable.Text = "Select table:";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1109, 710);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            btnMenu.Location = new Point(1123, 69);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(94, 155);
            btnMenu.TabIndex = 1;
            btnMenu.Text = "To menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1299, 755);
            Controls.Add(btnMenu);
            Controls.Add(tabControlMain);
            Name = "ReservationForm";
            Text = "Form1";
            Load += ReservationForm_Load;
            tabControlMain.ResumeLayout(false);
            tabMakeReservation.ResumeLayout(false);
            tabMakeReservation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabMakeReservation;
        private TabPage tabPage2;
        private ComboBox comboBoxTables;
        private Label lblSelectTable;
        private Button buttonNextWeek;
        private Button buttonPrevWeek;
        private Label lblNotes;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblName;
        private Button buttonSubmitReservation;
        private TextBox textBoxNotes;
        private TextBox textBoxPhone;
        private TextBox textBoxEmail;
        private TextBox textBoxName;
        private FlowLayoutPanel flowLayoutCalendar;
        private Button btnMenu;
    }
}