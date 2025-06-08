namespace PresentationLayerForms
{
    partial class FormRestaurantTable
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
            labelTableNumber = new Label();
            labelTableType = new Label();
            lableTableDescription = new Label();
            textBoxTableNumber = new TextBox();
            richTextBoxTableDescription = new RichTextBox();
            radioBtnStandart = new RadioButton();
            radioButtonVIP = new RadioButton();
            radioButtonOutdoor = new RadioButton();
            btnAddTable = new Button();
            labelTitle = new Label();
            tabControlTables = new TabControl();
            add = new TabPage();
            all = new TabPage();
            flowTables = new FlowLayoutPanel();
            btnHome = new Button();
            btnAdminMenu = new Button();
            tabControlTables.SuspendLayout();
            add.SuspendLayout();
            all.SuspendLayout();
            SuspendLayout();
            // 
            // labelTableNumber
            // 
            labelTableNumber.AutoSize = true;
            labelTableNumber.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            labelTableNumber.Location = new Point(40, 105);
            labelTableNumber.Name = "labelTableNumber";
            labelTableNumber.Size = new Size(258, 38);
            labelTableNumber.TabIndex = 0;
            labelTableNumber.Text = "Номер на масата:";
            // 
            // labelTableType
            // 
            labelTableType.AutoSize = true;
            labelTableType.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            labelTableType.Location = new Point(40, 195);
            labelTableType.Name = "labelTableType";
            labelTableType.Size = new Size(219, 38);
            labelTableType.TabIndex = 1;
            labelTableType.Text = "Вид на масата:";
            // 
            // lableTableDescription
            // 
            lableTableDescription.AutoSize = true;
            lableTableDescription.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lableTableDescription.Location = new Point(632, 98);
            lableTableDescription.Name = "lableTableDescription";
            lableTableDescription.Size = new Size(159, 38);
            lableTableDescription.TabIndex = 2;
            lableTableDescription.Text = "Описание:";
            // 
            // textBoxTableNumber
            // 
            textBoxTableNumber.Location = new Point(331, 109);
            textBoxTableNumber.Name = "textBoxTableNumber";
            textBoxTableNumber.Size = new Size(125, 34);
            textBoxTableNumber.TabIndex = 3;
            // 
            // richTextBoxTableDescription
            // 
            richTextBoxTableDescription.Location = new Point(815, 109);
            richTextBoxTableDescription.Name = "richTextBoxTableDescription";
            richTextBoxTableDescription.Size = new Size(283, 158);
            richTextBoxTableDescription.TabIndex = 4;
            richTextBoxTableDescription.Text = "";
            // 
            // radioBtnStandart
            // 
            radioBtnStandart.AutoSize = true;
            radioBtnStandart.Font = new Font("Segoe UI", 16.2F);
            radioBtnStandart.Location = new Point(274, 192);
            radioBtnStandart.Name = "radioBtnStandart";
            radioBtnStandart.Size = new Size(178, 42);
            radioBtnStandart.TabIndex = 5;
            radioBtnStandart.TabStop = true;
            radioBtnStandart.Text = "стандартна";
            radioBtnStandart.UseVisualStyleBackColor = true;
            // 
            // radioButtonVIP
            // 
            radioButtonVIP.AutoSize = true;
            radioButtonVIP.Font = new Font("Segoe UI", 16.2F);
            radioButtonVIP.Location = new Point(458, 192);
            radioButtonVIP.Name = "radioButtonVIP";
            radioButtonVIP.Size = new Size(78, 42);
            radioButtonVIP.TabIndex = 6;
            radioButtonVIP.TabStop = true;
            radioButtonVIP.Text = "VIP";
            radioButtonVIP.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutdoor
            // 
            radioButtonOutdoor.AutoSize = true;
            radioButtonOutdoor.Font = new Font("Segoe UI", 16.2F);
            radioButtonOutdoor.Location = new Point(542, 192);
            radioButtonOutdoor.Name = "radioButtonOutdoor";
            radioButtonOutdoor.Size = new Size(138, 42);
            radioButtonOutdoor.TabIndex = 7;
            radioButtonOutdoor.TabStop = true;
            radioButtonOutdoor.Text = "външна";
            radioButtonOutdoor.UseVisualStyleBackColor = true;
            radioButtonOutdoor.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // btnAddTable
            // 
            btnAddTable.Font = new Font("Segoe UI Variable Text", 16.2F, FontStyle.Bold);
            btnAddTable.ForeColor = Color.IndianRed;
            btnAddTable.Location = new Point(440, 304);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(327, 62);
            btnAddTable.TabIndex = 8;
            btnAddTable.Text = "Добави";
            btnAddTable.UseVisualStyleBackColor = true;
            btnAddTable.Click += btnAddTable_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic);
            labelTitle.Location = new Point(440, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(325, 46);
            labelTitle.TabIndex = 9;
            labelTitle.Text = "Добави нова маса";
            labelTitle.Click += labelTitle_Click;
            // 
            // tabControlTables
            // 
            tabControlTables.Controls.Add(add);
            tabControlTables.Controls.Add(all);
            tabControlTables.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tabControlTables.Location = new Point(128, 25);
            tabControlTables.Name = "tabControlTables";
            tabControlTables.SelectedIndex = 0;
            tabControlTables.Size = new Size(1161, 437);
            tabControlTables.TabIndex = 10;
            // 
            // add
            // 
            add.Controls.Add(labelTitle);
            add.Controls.Add(labelTableNumber);
            add.Controls.Add(btnAddTable);
            add.Controls.Add(labelTableType);
            add.Controls.Add(radioButtonOutdoor);
            add.Controls.Add(lableTableDescription);
            add.Controls.Add(radioButtonVIP);
            add.Controls.Add(textBoxTableNumber);
            add.Controls.Add(radioBtnStandart);
            add.Controls.Add(richTextBoxTableDescription);
            add.Location = new Point(4, 37);
            add.Name = "add";
            add.Padding = new Padding(3);
            add.Size = new Size(1153, 396);
            add.TabIndex = 0;
            add.Text = "Добави";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // all
            // 
            all.Controls.Add(flowTables);
            all.Location = new Point(4, 37);
            all.Name = "all";
            all.Padding = new Padding(3);
            all.Size = new Size(1153, 396);
            all.TabIndex = 1;
            all.Text = "Всички";
            all.UseVisualStyleBackColor = true;
            all.Click += tabPage2_Click;
            // 
            // flowTables
            // 
            flowTables.AutoScroll = true;
            flowTables.Location = new Point(28, 19);
            flowTables.Name = "flowTables";
            flowTables.Size = new Size(1091, 357);
            flowTables.TabIndex = 0;
            flowTables.Paint += flowTables_Paint;
            // 
            // btnHome
            // 
            btnHome.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold);
            btnHome.ForeColor = Color.Maroon;
            btnHome.Location = new Point(224, 471);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(347, 77);
            btnHome.TabIndex = 11;
            btnHome.Text = "Начално меню";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold);
            btnAdminMenu.ForeColor = Color.Maroon;
            btnAdminMenu.Location = new Point(853, 471);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(347, 77);
            btnAdminMenu.TabIndex = 12;
            btnAdminMenu.Text = "Администраторско меню";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // FormRestaurantTable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormRestaurantTable;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1420, 572);
            Controls.Add(btnAdminMenu);
            Controls.Add(btnHome);
            Controls.Add(tabControlTables);
            Name = "FormRestaurantTable";
            Text = "FormRestaurantTable";
            Load += FormRestaurantTable_Load;
            tabControlTables.ResumeLayout(false);
            add.ResumeLayout(false);
            add.PerformLayout();
            all.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label labelTableNumber;
        private Label labelTableType;
        private Label lableTableDescription;
        private TextBox textBoxTableNumber;
        private RichTextBox richTextBoxTableDescription;
        private RadioButton radioBtnStandart;
        private RadioButton radioButtonVIP;
        private RadioButton radioButtonOutdoor;
        private Button btnAddTable;
        private Label labelTitle;
        private TabControl tabControlTables;
        private TabPage add;
        private TabPage all;
        private FlowLayoutPanel flowTables;
        private Button btnHome;
        private Button btnAdminMenu;
    }
}