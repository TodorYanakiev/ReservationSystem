namespace PresentationLayerForms
{
    partial class FormAddTable
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
            SuspendLayout();
            // 
            // labelTableNumber
            // 
            labelTableNumber.AutoSize = true;
            labelTableNumber.Location = new Point(42, 81);
            labelTableNumber.Name = "labelTableNumber";
            labelTableNumber.Size = new Size(133, 20);
            labelTableNumber.TabIndex = 0;
            labelTableNumber.Text = "Номер на масата:";
            // 
            // labelTableType
            // 
            labelTableType.AutoSize = true;
            labelTableType.Location = new Point(42, 131);
            labelTableType.Name = "labelTableType";
            labelTableType.Size = new Size(111, 20);
            labelTableType.TabIndex = 1;
            labelTableType.Text = "Вид на масата:";
            // 
            // lableTableDescription
            // 
            lableTableDescription.AutoSize = true;
            lableTableDescription.Location = new Point(42, 235);
            lableTableDescription.Name = "lableTableDescription";
            lableTableDescription.Size = new Size(82, 20);
            lableTableDescription.TabIndex = 2;
            lableTableDescription.Text = "Описание:";
            // 
            // textBoxTableNumber
            // 
            textBoxTableNumber.Location = new Point(189, 78);
            textBoxTableNumber.Name = "textBoxTableNumber";
            textBoxTableNumber.Size = new Size(125, 27);
            textBoxTableNumber.TabIndex = 3;
            // 
            // richTextBoxTableDescription
            // 
            richTextBoxTableDescription.Location = new Point(181, 203);
            richTextBoxTableDescription.Name = "richTextBoxTableDescription";
            richTextBoxTableDescription.Size = new Size(308, 89);
            richTextBoxTableDescription.TabIndex = 4;
            richTextBoxTableDescription.Text = "";
            // 
            // radioBtnStandart
            // 
            radioBtnStandart.AutoSize = true;
            radioBtnStandart.Location = new Point(189, 131);
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
            radioButtonVIP.Location = new Point(319, 131);
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
            radioButtonOutdoor.Location = new Point(388, 129);
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
            btnAddTable.Location = new Point(81, 366);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(242, 72);
            btnAddTable.TabIndex = 8;
            btnAddTable.Text = "Добави маса";
            btnAddTable.UseVisualStyleBackColor = true;
            btnAddTable.Click += btnAddTable_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F);
            labelTitle.Location = new Point(233, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(217, 32);
            labelTitle.TabIndex = 9;
            labelTitle.Text = "Добави нова маса";
            // 
            // FormAddTable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelTitle);
            Controls.Add(btnAddTable);
            Controls.Add(radioButtonOutdoor);
            Controls.Add(radioButtonVIP);
            Controls.Add(radioBtnStandart);
            Controls.Add(richTextBoxTableDescription);
            Controls.Add(textBoxTableNumber);
            Controls.Add(lableTableDescription);
            Controls.Add(labelTableType);
            Controls.Add(labelTableNumber);
            Name = "FormAddTable";
            Text = "FormAddTable";
            ResumeLayout(false);
            PerformLayout();
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
    }
}