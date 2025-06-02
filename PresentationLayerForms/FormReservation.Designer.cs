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
            btnMenu.Location = new Point(130, 410);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(199, 64);
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
            lblNotes.Location = new Point(20, 270);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(105, 28);
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
            lblPhone.Location = new Point(20, 200);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(101, 28);
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
            lblEmail.Location = new Point(20, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(85, 28);
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
            lblName.Location = new Point(20, 100);
            lblName.Name = "lblName";
            lblName.Size = new Size(60, 28);
            lblName.TabIndex = 24;
            lblName.Text = "Име:";
            // 
            // buttonSubmitReservation
            // 
            buttonSubmitReservation.BackColor = Color.Transparent;
            buttonSubmitReservation.FlatStyle = FlatStyle.Flat;
            buttonSubmitReservation.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold);
            buttonSubmitReservation.ForeColor = Color.GreenYellow;
            buttonSubmitReservation.Location = new Point(596, 410);
            buttonSubmitReservation.Name = "buttonSubmitReservation";
            buttonSubmitReservation.Size = new Size(199, 64);
            buttonSubmitReservation.TabIndex = 23;
            buttonSubmitReservation.Text = "Потвърди";
            buttonSubmitReservation.UseVisualStyleBackColor = false;
            buttonSubmitReservation.Click += buttonSubmitReservation_Click;
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(127, 275);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.Size = new Size(286, 105);
            textBoxNotes.TabIndex = 22;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(127, 204);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(202, 27);
            textBoxPhone.TabIndex = 21;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(127, 154);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(202, 27);
            textBoxEmail.TabIndex = 20;
            textBoxEmail.TextChanged += textBoxEmail_TextChanged;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(127, 101);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(202, 27);
            textBoxName.TabIndex = 19;
            // 
            // flowLayoutCalendar
            // 
            flowLayoutCalendar.AutoScroll = true;
            flowLayoutCalendar.Location = new Point(479, 139);
            flowLayoutCalendar.Name = "flowLayoutCalendar";
            flowLayoutCalendar.Size = new Size(919, 241);
            flowLayoutCalendar.TabIndex = 18;
            flowLayoutCalendar.Paint += flowLayoutCalendar_Paint;
            // 
            // buttonNextWeek
            // 
            buttonNextWeek.BackColor = Color.Transparent;
            buttonNextWeek.FlatStyle = FlatStyle.Flat;
            buttonNextWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonNextWeek.ForeColor = Color.White;
            buttonNextWeek.Location = new Point(356, 194);
            buttonNextWeek.Name = "buttonNextWeek";
            buttonNextWeek.Size = new Size(110, 50);
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
            buttonPrevWeek.Location = new Point(356, 138);
            buttonPrevWeek.Name = "buttonPrevWeek";
            buttonPrevWeek.Size = new Size(110, 50);
            buttonPrevWeek.TabIndex = 16;
            buttonPrevWeek.Text = "Предишна седмица";
            buttonPrevWeek.UseVisualStyleBackColor = false;
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(648, 100);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(220, 28);
            comboBoxTables.TabIndex = 15;
            // 
            // lblSelectTable
            // 
            lblSelectTable.AutoSize = true;
            lblSelectTable.BackColor = Color.Transparent;
            lblSelectTable.FlatStyle = FlatStyle.Flat;
            lblSelectTable.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectTable.ForeColor = Color.White;
            lblSelectTable.Location = new Point(493, 100);
            lblSelectTable.Name = "lblSelectTable";
            lblSelectTable.Size = new Size(145, 28);
            lblSelectTable.TabIndex = 14;
            lblSelectTable.Text = "Избери маса:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(250, 20);
            label1.Name = "label1";
            label1.Size = new Size(417, 38);
            label1.TabIndex = 28;
            label1.Text = "Направи своята резервация";
            // 
            // FormReservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.FormReservation;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1416, 497);
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