namespace ListaDeEventos.Forms
{
    partial class CriarEvento_
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
            Name = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            Description = new TextBox();
            Create_button = new Button();
            cancel_button = new Button();
            end_date = new DateTimePicker();
            start_date = new DateTimePicker();
            start_date_h = new NumericUpDown();
            label4 = new Label();
            start_date_m = new NumericUpDown();
            end_date_m = new NumericUpDown();
            label5 = new Label();
            end_date_h = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)start_date_h).BeginInit();
            ((System.ComponentModel.ISupportInitialize)start_date_m).BeginInit();
            ((System.ComponentModel.ISupportInitialize)end_date_m).BeginInit();
            ((System.ComponentModel.ISupportInitialize)end_date_h).BeginInit();
            SuspendLayout();
            // 
            // Name
            // 
            Name.Location = new Point(12, 30);
            Name.Name = "Name";
            Name.Size = new Size(250, 23);
            Name.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 3;
            label2.Text = "Data de inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 103);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 5;
            label3.Text = "Data de termino:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 147);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 11;
            label6.Text = "Descricao";
            // 
            // Description
            // 
            Description.Location = new Point(12, 168);
            Description.Name = "Description";
            Description.Size = new Size(250, 23);
            Description.TabIndex = 10;
            // 
            // Create_button
            // 
            Create_button.Location = new Point(12, 197);
            Create_button.Name = "Create_button";
            Create_button.Size = new Size(75, 23);
            Create_button.TabIndex = 14;
            Create_button.Text = "Criar";
            Create_button.UseVisualStyleBackColor = true;
            Create_button.Click += Create_button_Click;
            // 
            // cancel_button
            // 
            cancel_button.Location = new Point(93, 197);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(75, 23);
            cancel_button.TabIndex = 15;
            cancel_button.Text = "Cancelar";
            cancel_button.UseVisualStyleBackColor = true;
            // 
            // end_date
            // 
            end_date.Format = DateTimePickerFormat.Short;
            end_date.Location = new Point(12, 121);
            end_date.Name = "end_date";
            end_date.Size = new Size(95, 23);
            end_date.TabIndex = 13;
            // 
            // start_date
            // 
            start_date.Format = DateTimePickerFormat.Short;
            start_date.Location = new Point(12, 74);
            start_date.Name = "start_date";
            start_date.Size = new Size(95, 23);
            start_date.TabIndex = 12;
            // 
            // start_date_h
            // 
            start_date_h.Location = new Point(113, 74);
            start_date_h.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            start_date_h.Name = "start_date_h";
            start_date_h.Size = new Size(36, 23);
            start_date_h.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(113, 56);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 18;
            label4.Text = "hora (h|m)";
            // 
            // start_date_m
            // 
            start_date_m.Location = new Point(155, 74);
            start_date_m.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            start_date_m.Name = "start_date_m";
            start_date_m.Size = new Size(36, 23);
            start_date_m.TabIndex = 19;
            // 
            // end_date_m
            // 
            end_date_m.Location = new Point(155, 121);
            end_date_m.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            end_date_m.Name = "end_date_m";
            end_date_m.Size = new Size(36, 23);
            end_date_m.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(113, 103);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 21;
            label5.Text = "hora (h|m)";
            // 
            // end_date_h
            // 
            end_date_h.Location = new Point(113, 121);
            end_date_h.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            end_date_h.Name = "end_date_h";
            end_date_h.Size = new Size(36, 23);
            end_date_h.TabIndex = 20;
            // 
            // CriarEvento_
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 239);
            Controls.Add(end_date_m);
            Controls.Add(label5);
            Controls.Add(end_date_h);
            Controls.Add(start_date_m);
            Controls.Add(label4);
            Controls.Add(start_date_h);
            Controls.Add(cancel_button);
            Controls.Add(Create_button);
            Controls.Add(end_date);
            Controls.Add(start_date);
            Controls.Add(label6);
            Controls.Add(Description);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Name);
            MaximizeBox = false;
            MaximumSize = new Size(290, 278);
            MinimumSize = new Size(290, 278);
            ShowInTaskbar = false;
            Text = "CriarEvento";
            Load += CriarEvento_Load;
            ((System.ComponentModel.ISupportInitialize)start_date_h).EndInit();
            ((System.ComponentModel.ISupportInitialize)start_date_m).EndInit();
            ((System.ComponentModel.ISupportInitialize)end_date_m).EndInit();
            ((System.ComponentModel.ISupportInitialize)end_date_h).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Name;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private TextBox Description;
        private Button Create_button;
        private Button cancel_button;
        private DateTimePicker end_date;
        private DateTimePicker start_date;
        private NumericUpDown start_date_h;
        private Label label4;
        private NumericUpDown start_date_m;
        private NumericUpDown end_date_m;
        private Label label5;
        private NumericUpDown end_date_h;
    }
}