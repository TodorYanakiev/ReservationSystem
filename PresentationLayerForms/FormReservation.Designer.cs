namespace PresentationLayerForms
{
    partial class FormReservation
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
            btnMenu = new Button();
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
            label1 = new Label();
            SuspendLayout();
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.Transparent;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold);
            btnMenu.ForeColor = Color.Gold;
            btnMenu.Location = new Point(114, 308);
            btnMenu.Margin = new Padding(3, 2, 3, 2);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(174, 48);
            btnMenu.TabIndex = 1;
            btnMenu.Text = "Назад";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.BackColor = Color.Transparent;
            lblNotes.FlatStyle = FlatStyle.Flat;
            lblNotes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNotes.ForeColor = Color.White;
            lblNotes.Location = new Point(18, 202);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(85, 21);
            lblNotes.TabIndex = 27;
            lblNotes.Text = "Бележки:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.BackColor = Color.Transparent;
            lblPhone.FlatStyle = FlatStyle.Flat;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.White;
            lblPhone.Location = new Point(18, 150);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(83, 21);
            lblPhone.TabIndex = 26;
            lblPhone.Text = "Телефон:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.FlatStyle = FlatStyle.Flat;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(18, 112);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(68, 21);
            lblEmail.TabIndex = 25;
            lblEmail.Text = "Имейл:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.FlatStyle = FlatStyle.Flat;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(18, 75);
            lblName.Name = "lblName";
            lblName.Size = new Size(48, 21);
            lblName.TabIndex = 24;
            lblName.Text = "Име:";
            // 
            // buttonSubmitReservation
            // 
            buttonSubmitReservation.BackColor = Color.Transparent;
            buttonSubmitReservation.FlatStyle = FlatStyle.Flat;
            buttonSubmitReservation.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold);
            buttonSubmitReservation.ForeColor = Color.GreenYellow;
            buttonSubmitReservation.Location = new Point(520, 362);
            buttonSubmitReservation.Margin = new Padding(3, 2, 3, 2);
            buttonSubmitReservation.Name = "buttonSubmitReservation";
            buttonSubmitReservation.Size = new Size(174, 48);
            buttonSubmitReservation.TabIndex = 23;
            buttonSubmitReservation.Text = "Потвърди";
            buttonSubmitReservation.UseVisualStyleBackColor = false;
//            buttonSubmitReservation.Click += buttonSubmitReservation_Click;
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(111, 206);
            textBoxNotes.Margin = new Padding(3, 2, 3, 2);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.Size = new Size(251, 80);
            textBoxNotes.TabIndex = 22;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(111, 153);
            textBoxPhone.Margin = new Padding(3, 2, 3, 2);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(177, 23);
            textBoxPhone.TabIndex = 21;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(111, 116);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(177, 23);
            textBoxEmail.TabIndex = 20;
            textBoxEmail.TextChanged += textBoxEmail_TextChanged;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(111, 76);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(177, 23);
            textBoxName.TabIndex = 19;
            // 
            // flowLayoutCalendar
            // 
            flowLayoutCalendar.AutoScroll = true;
            flowLayoutCalendar.Location = new Point(419, 104);
            flowLayoutCalendar.Margin = new Padding(3, 2, 3, 2);
            flowLayoutCalendar.Name = "flowLayoutCalendar";
            flowLayoutCalendar.Size = new Size(680, 254);
            flowLayoutCalendar.TabIndex = 18;
            flowLayoutCalendar.Paint += flowLayoutCalendar_Paint;
            // 
            // buttonNextWeek
            // 
            buttonNextWeek.BackColor = Color.Transparent;
            buttonNextWeek.FlatStyle = FlatStyle.Flat;
            buttonNextWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonNextWeek.ForeColor = Color.White;
            buttonNextWeek.Location = new Point(312, 146);
            buttonNextWeek.Margin = new Padding(3, 2, 3, 2);
            buttonNextWeek.Name = "buttonNextWeek";
            buttonNextWeek.Size = new Size(96, 38);
            buttonNextWeek.TabIndex = 17;
            buttonNextWeek.Text = "Следваща седмица";
            buttonNextWeek.UseVisualStyleBackColor = false;
            // 
            // buttonPrevWeek
            // 
            buttonPrevWeek.BackColor = Color.Transparent;
            buttonPrevWeek.FlatStyle = FlatStyle.Flat;
            buttonPrevWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonPrevWeek.ForeColor = Color.White;
            buttonPrevWeek.Location = new Point(312, 104);
            buttonPrevWeek.Margin = new Padding(3, 2, 3, 2);
            buttonPrevWeek.Name = "buttonPrevWeek";
            buttonPrevWeek.Size = new Size(96, 38);
            buttonPrevWeek.TabIndex = 16;
            buttonPrevWeek.Text = "Предишна седмица";
            buttonPrevWeek.UseVisualStyleBackColor = false;
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(567, 75);
            comboBoxTables.Margin = new Padding(3, 2, 3, 2);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(193, 23);
            comboBoxTables.TabIndex = 15;
            // 
            // lblSelectTable
            // 
            lblSelectTable.AutoSize = true;
            lblSelectTable.BackColor = Color.Transparent;
            lblSelectTable.FlatStyle = FlatStyle.Flat;
            lblSelectTable.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectTable.ForeColor = Color.White;
            lblSelectTable.Location = new Point(431, 75);
            lblSelectTable.Name = "lblSelectTable";
            lblSelectTable.Size = new Size(116, 21);
            lblSelectTable.TabIndex = 14;
            lblSelectTable.Text = "Избери маса:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(219, 15);
            label1.Name = "label1";
            label1.Size = new Size(324, 30);
            label1.TabIndex = 28;
            label1.Text = "Направи своята резервация";
            // 
            // FormReservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.FormReservation;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1111, 455);
            Controls.Add(label1);
            Controls.Add(lblNotes);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(lblName);
            Controls.Add(buttonSubmitReservation);
            Controls.Add(textBoxNotes);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Controls.Add(flowLayoutCalendar);
            Controls.Add(buttonNextWeek);
            Controls.Add(buttonPrevWeek);
            Controls.Add(comboBoxTables);
            Controls.Add(lblSelectTable);
            Controls.Add(btnMenu);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormReservation";
            Text = "FormReservation";
            Load += ReservationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnMenu;
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
        private Button buttonNextWeek;
        private Button buttonPrevWeek;
        private ComboBox comboBoxTables;
        private Label lblSelectTable;
        private Label label1;
    }
}