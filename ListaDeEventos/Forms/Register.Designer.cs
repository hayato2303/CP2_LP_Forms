namespace ListaDeEventos
{
    partial class Register
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
            R_email = new TextBox();
            label2 = new Label();
            label3 = new Label();
            R_senha = new TextBox();
            label4 = new Label();
            R_turma = new TextBox();
            Registrar = new Button();
            Cancelar = new Button();
            label5 = new Label();
            R_Nome = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Criar conta";
            // 
            // R_email
            // 
            R_email.Location = new Point(9, 56);
            R_email.Name = "R_email";
            R_email.Size = new Size(210, 23);
            R_email.TabIndex = 1;
            R_email.TextChanged += R_email_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 38);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 82);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Senha";
            // 
            // R_senha
            // 
            R_senha.Location = new Point(9, 100);
            R_senha.Name = "R_senha";
            R_senha.Size = new Size(210, 23);
            R_senha.TabIndex = 4;
            R_senha.TextChanged += R_senha_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 170);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 7;
            label4.Text = "Turma";
            // 
            // R_turma
            // 
            R_turma.Location = new Point(9, 188);
            R_turma.Name = "R_turma";
            R_turma.Size = new Size(210, 23);
            R_turma.TabIndex = 6;
            R_turma.TextChanged += R_turma_TextChanged;
            // 
            // Registrar
            // 
            Registrar.Location = new Point(9, 227);
            Registrar.Name = "Registrar";
            Registrar.Size = new Size(75, 23);
            Registrar.TabIndex = 8;
            Registrar.Text = "Registrar";
            Registrar.UseVisualStyleBackColor = true;
            Registrar.Click += Registrar_Click;
            // 
            // Cancelar
            // 
            Cancelar.Location = new Point(90, 227);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(75, 23);
            Cancelar.TabIndex = 9;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = true;
            Cancelar.Click += Cancelar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 126);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 11;
            label5.Text = "Nome";
            // 
            // R_Nome
            // 
            R_Nome.Location = new Point(9, 144);
            R_Nome.Name = "R_Nome";
            R_Nome.Size = new Size(210, 23);
            R_Nome.TabIndex = 10;
            R_Nome.TextChanged += R_Nome_TextChanged;
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 262);
            Controls.Add(label5);
            Controls.Add(R_Nome);
            Controls.Add(Cancelar);
            Controls.Add(Registrar);
            Controls.Add(label4);
            Controls.Add(R_turma);
            Controls.Add(label3);
            Controls.Add(R_senha);
            Controls.Add(label2);
            Controls.Add(R_email);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(257, 301);
            MinimumSize = new Size(257, 301);
            Name = "Registro";
            Text = "Registro";
            Load += Registro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox R_email;
        private Label label2;
        private Label label3;
        private TextBox R_senha;
        private Label label4;
        private TextBox R_turma;
        private Button Registrar;
        private Button Cancelar;
        private Label label5;
        private TextBox R_Nome;
    }
}