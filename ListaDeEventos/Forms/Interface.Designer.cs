namespace ListaDeEventos
{
    partial class Interface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            class_list = new ListBox();
            class_label = new Label();
            DescriptionLabel = new Label();
            EventsTable = new DataGridView();
            Nome = new DataGridViewTextBoxColumn();
            Data_Inicio = new DataGridViewTextBoxColumn();
            Data_Fim = new DataGridViewTextBoxColumn();
            Hora_Inicio = new DataGridViewTextBoxColumn();
            Hora_Fim = new DataGridViewTextBoxColumn();
            Desc = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            Delete_button = new Button();
            Create_button = new Button();
            userData = new Label();
            ((System.ComponentModel.ISupportInitialize)EventsTable).BeginInit();
            SuspendLayout();
            // 
            // class_list
            // 
            class_list.FormattingEnabled = true;
            class_list.ItemHeight = 15;
            class_list.Location = new Point(12, 27);
            class_list.Name = "class_list";
            class_list.Size = new Size(120, 409);
            class_list.TabIndex = 0;
            class_list.SelectedIndexChanged += class_list_SelectedIndexChanged;
            // 
            // class_label
            // 
            class_label.AutoSize = true;
            class_label.Location = new Point(12, 9);
            class_label.Name = "class_label";
            class_label.Size = new Size(49, 15);
            class_label.TabIndex = 1;
            class_label.Text = "Turmas:";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(138, 344);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(57, 15);
            DescriptionLabel.TabIndex = 4;
            DescriptionLabel.Text = "----------";
            // 
            // EventsTable
            // 
            EventsTable.AllowUserToAddRows = false;
            EventsTable.AllowUserToDeleteRows = false;
            EventsTable.AllowUserToResizeRows = false;
            EventsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EventsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EventsTable.Columns.AddRange(new DataGridViewColumn[] { Nome, Data_Inicio, Data_Fim, Hora_Inicio, Hora_Fim, Desc, ID });
            EventsTable.Location = new Point(138, 27);
            EventsTable.MultiSelect = false;
            EventsTable.Name = "EventsTable";
            EventsTable.ReadOnly = true;
            EventsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EventsTable.Size = new Size(595, 314);
            EventsTable.TabIndex = 6;
            EventsTable.CellClick += EventsTable_CellClick;
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            // 
            // Data_Inicio
            // 
            Data_Inicio.HeaderText = "Data_Inicio";
            Data_Inicio.Name = "Data_Inicio";
            Data_Inicio.ReadOnly = true;
            // 
            // Data_Fim
            // 
            Data_Fim.HeaderText = "Data_Fim";
            Data_Fim.Name = "Data_Fim";
            Data_Fim.ReadOnly = true;
            // 
            // Hora_Inicio
            // 
            Hora_Inicio.HeaderText = "Hora_Inicio";
            Hora_Inicio.Name = "Hora_Inicio";
            Hora_Inicio.ReadOnly = true;
            // 
            // Hora_Fim
            // 
            Hora_Fim.HeaderText = "Hora_Fim";
            Hora_Fim.Name = "Hora_Fim";
            Hora_Fim.ReadOnly = true;
            // 
            // Desc
            // 
            Desc.HeaderText = "Desc";
            Desc.Name = "Desc";
            Desc.ReadOnly = true;
            Desc.Visible = false;
            // 
            // ID
            // 
            ID.HeaderText = "Id";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // Delete_button
            // 
            Delete_button.Location = new Point(672, 378);
            Delete_button.Name = "Delete_button";
            Delete_button.Size = new Size(61, 25);
            Delete_button.TabIndex = 7;
            Delete_button.Text = "Delete";
            Delete_button.UseVisualStyleBackColor = true;
            Delete_button.Click += Delete_button_Click;
            // 
            // Create_button
            // 
            Create_button.Location = new Point(672, 347);
            Create_button.Name = "Create_button";
            Create_button.Size = new Size(61, 25);
            Create_button.TabIndex = 8;
            Create_button.Text = "Criar";
            Create_button.UseVisualStyleBackColor = true;
            Create_button.Click += Create_button_Click;
            // 
            // userData
            // 
            userData.AutoSize = true;
            userData.Location = new Point(138, 9);
            userData.Name = "userData";
            userData.Size = new Size(38, 15);
            userData.TabIndex = 9;
            userData.Text = "label1";
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 450);
            Controls.Add(userData);
            Controls.Add(Create_button);
            Controls.Add(Delete_button);
            Controls.Add(EventsTable);
            Controls.Add(DescriptionLabel);
            Controls.Add(class_label);
            Controls.Add(class_list);
            MaximizeBox = false;
            MaximumSize = new Size(761, 489);
            MinimumSize = new Size(761, 489);
            Name = "Interface";
            Text = "Eventos";
            Load += Interface_Load;
            ((System.ComponentModel.ISupportInitialize)EventsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox class_list;
        private Label class_label;
        private Label DescriptionLabel;
        private DataGridView EventsTable;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Data_Inicio;
        private DataGridViewTextBoxColumn Data_Fim;
        private DataGridViewTextBoxColumn Hora_Inicio;
        private DataGridViewTextBoxColumn Hora_Fim;
        private DataGridViewTextBoxColumn Desc;
        private Button Delete_button;
        private Button Create_button;
        private DataGridViewTextBoxColumn ID;
        private Label userData;
    }
}
