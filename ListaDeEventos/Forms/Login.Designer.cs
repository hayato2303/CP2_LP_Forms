namespace ListaDeEventos
{
    partial class Login
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
            label1 = new Label();
            Email = new TextBox();
            Password = new TextBox();
            label2 = new Label();
            login_button = new Button();
            cancel_button = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            label1.Click += label1_Click;
            // 
            // Email
            // 
            Email.Location = new Point(12, 27);
            Email.Name = "Email";
            Email.Size = new Size(211, 23);
            Email.TabIndex = 1;
            // 
            // Password
            // 
            Password.Location = new Point(12, 71);
            Password.Name = "Password";
            Password.Size = new Size(211, 23);
            Password.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Senha:";
            // 
            // login_button
            // 
            login_button.Location = new Point(12, 100);
            login_button.Name = "login_button";
            login_button.Size = new Size(75, 23);
            login_button.TabIndex = 4;
            login_button.Text = "Entrar";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += login_button_Click;
            // 
            // cancel_button
            // 
            cancel_button.Location = new Point(93, 100);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(75, 23);
            cancel_button.TabIndex = 5;
            cancel_button.Text = "Cancelar";
            cancel_button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 6;
            label3.Text = "Registrar";
            label3.Click += label3_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(235, 156);
            Controls.Add(label3);
            Controls.Add(cancel_button);
            Controls.Add(login_button);
            Controls.Add(Password);
            Controls.Add(label2);
            Controls.Add(Email);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(251, 195);
            MinimumSize = new Size(251, 195);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Email;
        private TextBox Password;
        private Label label2;
        private Button login_button;
        private Button cancel_button;
        private Label label3;
    }
}