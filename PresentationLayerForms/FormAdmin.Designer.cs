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
            btnUser = new Button();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // btnUser
            // 
            btnUser.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUser.ForeColor = SystemColors.HotTrack;
            btnUser.Location = new Point(116, 187);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(251, 70);
            btnUser.TabIndex = 6;
            btnUser.Text = "Добави резервация";
            btnUser.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(314, 84);
            label2.Name = "label2";
            label2.Size = new Size(212, 38);
            label2.TabIndex = 5;
            label2.Text = "Добре дошли!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(222, 35);
            label1.Name = "label1";
            label1.Size = new Size(395, 38);
            label1.TabIndex = 4;
            label1.Text = "Администраторски панел";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.HotTrack;
            button1.Location = new Point(106, 292);
            button1.Name = "button1";
            button1.Size = new Size(271, 70);
            button1.TabIndex = 7;
            button1.Text = "Редактирай резервация";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.HotTrack;
            button2.Location = new Point(474, 187);
            button2.Name = "button2";
            button2.Size = new Size(251, 70);
            button2.TabIndex = 8;
            button2.Text = "Изтрий резервация";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.HotTrack;
            button3.Location = new Point(460, 292);
            button3.Name = "button3";
            button3.Size = new Size(276, 70);
            button3.TabIndex = 9;
            button3.Text = "Виж всички резервации";
            button3.UseVisualStyleBackColor = true;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 483);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAdmin";
            Text = "FormAdmin";
            Load += FormAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnUser;
        private Label label2;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}