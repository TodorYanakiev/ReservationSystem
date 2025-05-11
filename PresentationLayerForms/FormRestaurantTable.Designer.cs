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
            labelTableNumber.Location = new Point(18, 59);
            labelTableNumber.Name = "labelTableNumber";
            labelTableNumber.Size = new Size(133, 20);
            labelTableNumber.TabIndex = 0;
            labelTableNumber.Text = "Номер на масата:";
            // 
            // labelTableType
            // 
            labelTableType.AutoSize = true;
            labelTableType.Location = new Point(18, 108);
            labelTableType.Name = "labelTableType";
            labelTableType.Size = new Size(111, 20);
            labelTableType.TabIndex = 1;
            labelTableType.Text = "Вид на масата:";
            // 
            // lableTableDescription
            // 
            lableTableDescription.AutoSize = true;
            lableTableDescription.Location = new Point(18, 149);
            lableTableDescription.Name = "lableTableDescription";
            lableTableDescription.Size = new Size(82, 20);
            lableTableDescription.TabIndex = 2;
            lableTableDescription.Text = "Описание:";
            // 
            // textBoxTableNumber
            // 
            textBoxTableNumber.Location = new Point(165, 55);
            textBoxTableNumber.Name = "textBoxTableNumber";
            textBoxTableNumber.Size = new Size(125, 27);
            textBoxTableNumber.TabIndex = 3;
            // 
            // richTextBoxTableDescription
            // 
            richTextBoxTableDescription.Location = new Point(154, 149);
            richTextBoxTableDescription.Name = "richTextBoxTableDescription";
            richTextBoxTableDescription.Size = new Size(222, 65);
            richTextBoxTableDescription.TabIndex = 4;
            richTextBoxTableDescription.Text = "";
            // 
            // radioBtnStandart
            // 
            radioBtnStandart.AutoSize = true;
            radioBtnStandart.Location = new Point(165, 108);
            radioBtnStandart.Name = "radioBtnStandart";
            radioBtnStandart.Size = new Size(108, 24);
            radioBtnStandart.TabIndex = 5;
            radioBtnStandart.TabStop = true;
            radioBtnStandart.Text = "стандартна";
            radioBtnStandart.UseVisualStyleBackColor = true;
            // 
            // radioButtonVIP
            // 
            radioButtonVIP.AutoSize = true;
            radioButtonVIP.Location = new Point(295, 108);
            radioButtonVIP.Name = "radioButtonVIP";
            radioButtonVIP.Size = new Size(51, 24);
            radioButtonVIP.TabIndex = 6;
            radioButtonVIP.TabStop = true;
            radioButtonVIP.Text = "VIP";
            radioButtonVIP.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutdoor
            // 
            radioButtonOutdoor.AutoSize = true;
            radioButtonOutdoor.Location = new Point(363, 107);
            radioButtonOutdoor.Name = "radioButtonOutdoor";
            radioButtonOutdoor.Size = new Size(85, 24);
            radioButtonOutdoor.TabIndex = 7;
            radioButtonOutdoor.TabStop = true;
            radioButtonOutdoor.Text = "външна";
            radioButtonOutdoor.UseVisualStyleBackColor = true;
            radioButtonOutdoor.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // btnAddTable
            // 
            btnAddTable.Location = new Point(18, 220);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(358, 65);
            btnAddTable.TabIndex = 8;
            btnAddTable.Text = "Добави маса";
            btnAddTable.UseVisualStyleBackColor = true;
            btnAddTable.Click += btnAddTable_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F);
            labelTitle.Location = new Point(73, 19);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(217, 32);
            labelTitle.TabIndex = 9;
            labelTitle.Text = "Добави нова маса";
            labelTitle.Click += labelTitle_Click;
            // 
            // tabControlTables
            // 
            tabControlTables.Controls.Add(add);
            tabControlTables.Controls.Add(all);
            tabControlTables.Location = new Point(52, 12);
            tabControlTables.Name = "tabControlTables";
            tabControlTables.SelectedIndex = 0;
            tabControlTables.Size = new Size(830, 383);
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
            add.Location = new Point(4, 29);
            add.Name = "add";
            add.Padding = new Padding(3, 3, 3, 3);
            add.Size = new Size(822, 350);
            add.TabIndex = 0;
            add.Text = "Добави";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // all
            // 
            all.Controls.Add(flowTables);
            all.Location = new Point(4, 29);
            all.Name = "all";
            all.Padding = new Padding(3, 3, 3, 3);
            all.Size = new Size(822, 314);
            all.TabIndex = 1;
            all.Text = "Всички";
            all.UseVisualStyleBackColor = true;
            all.Click += tabPage2_Click;
            // 
            // flowTables
            // 
            flowTables.AutoScroll = true;
            flowTables.Location = new Point(6, 26);
            flowTables.Name = "flowTables";
            flowTables.Size = new Size(799, 265);
            flowTables.TabIndex = 0;
            flowTables.Paint += flowTables_Paint;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(104, 401);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(197, 51);
            btnHome.TabIndex = 11;
            btnHome.Text = "Начално меню";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Location = new Point(667, 401);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(138, 51);
            btnAdminMenu.TabIndex = 12;
            btnAdminMenu.Text = "Меню на администратор";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // FormRestaurantTable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 497);
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