namespace wawi
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstbxArtikel = new System.Windows.Forms.ListBox();
            this.artikelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new wawi.Database1DataSet();
            this.artikelTableAdapter = new wawi.Database1DataSetTableAdapters.ArtikelTableAdapter();
            this.txtArtikel = new System.Windows.Forms.TextBox();
            this.lstbxDrucker = new System.Windows.Forms.ListBox();
            this.druckerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSetDrucker = new wawi.Database1DataSetDrucker();
            this.druckerTableAdapter = new wawi.Database1DataSetDruckerTableAdapters.DruckerTableAdapter();
            this.txtDrucker = new System.Windows.Forms.TextBox();
            this.dgvAuftraege = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erfDatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bezeichnungDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erfUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet1 = new wawi.Database1DataSet1();
            this.btnErfassen = new System.Windows.Forms.Button();
            this.viewTableAdapter = new wawi.Database1DataSet1TableAdapters.ViewTableAdapter();
            this.btnStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.artikelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.druckerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetDrucker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuftraege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstbxArtikel
            // 
            this.lstbxArtikel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.artikelBindingSource, "Id", true));
            this.lstbxArtikel.DataSource = this.artikelBindingSource;
            this.lstbxArtikel.DisplayMember = "Name";
            this.lstbxArtikel.FormattingEnabled = true;
            this.lstbxArtikel.ItemHeight = 16;
            this.lstbxArtikel.Location = new System.Drawing.Point(39, 92);
            this.lstbxArtikel.Name = "lstbxArtikel";
            this.lstbxArtikel.Size = new System.Drawing.Size(195, 308);
            this.lstbxArtikel.TabIndex = 0;
            this.lstbxArtikel.ValueMember = "Id";
            // 
            // artikelBindingSource
            // 
            this.artikelBindingSource.DataMember = "Artikel";
            this.artikelBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // artikelTableAdapter
            // 
            this.artikelTableAdapter.ClearBeforeFill = true;
            // 
            // txtArtikel
            // 
            this.txtArtikel.Location = new System.Drawing.Point(37, 42);
            this.txtArtikel.Name = "txtArtikel";
            this.txtArtikel.Size = new System.Drawing.Size(197, 22);
            this.txtArtikel.TabIndex = 1;
            this.txtArtikel.TextChanged += new System.EventHandler(this.txtArtikel_TextChanged);
            // 
            // lstbxDrucker
            // 
            this.lstbxDrucker.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.druckerBindingSource, "Id", true));
            this.lstbxDrucker.DataSource = this.druckerBindingSource;
            this.lstbxDrucker.DisplayMember = "Bezeichnung";
            this.lstbxDrucker.FormattingEnabled = true;
            this.lstbxDrucker.ItemHeight = 16;
            this.lstbxDrucker.Location = new System.Drawing.Point(267, 92);
            this.lstbxDrucker.Name = "lstbxDrucker";
            this.lstbxDrucker.Size = new System.Drawing.Size(194, 308);
            this.lstbxDrucker.TabIndex = 2;
            this.lstbxDrucker.ValueMember = "Id";
            // 
            // druckerBindingSource
            // 
            this.druckerBindingSource.DataMember = "Drucker";
            this.druckerBindingSource.DataSource = this.database1DataSetDrucker;
            // 
            // database1DataSetDrucker
            // 
            this.database1DataSetDrucker.DataSetName = "Database1DataSetDrucker";
            this.database1DataSetDrucker.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // druckerTableAdapter
            // 
            this.druckerTableAdapter.ClearBeforeFill = true;
            // 
            // txtDrucker
            // 
            this.txtDrucker.Location = new System.Drawing.Point(267, 42);
            this.txtDrucker.Name = "txtDrucker";
            this.txtDrucker.Size = new System.Drawing.Size(194, 22);
            this.txtDrucker.TabIndex = 3;
            this.txtDrucker.TextChanged += new System.EventHandler(this.txtDrucker_TextChanged);
            // 
            // dgvAuftraege
            // 
            this.dgvAuftraege.AllowUserToAddRows = false;
            this.dgvAuftraege.AllowUserToDeleteRows = false;
            this.dgvAuftraege.AutoGenerateColumns = false;
            this.dgvAuftraege.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuftraege.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.erfDatDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.bezeichnungDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.erfUserDataGridViewTextBoxColumn});
            this.dgvAuftraege.DataSource = this.viewBindingSource;
            this.dgvAuftraege.Location = new System.Drawing.Point(650, 92);
            this.dgvAuftraege.MultiSelect = false;
            this.dgvAuftraege.Name = "dgvAuftraege";
            this.dgvAuftraege.ReadOnly = true;
            this.dgvAuftraege.RowHeadersVisible = false;
            this.dgvAuftraege.RowHeadersWidth = 51;
            this.dgvAuftraege.RowTemplate.Height = 24;
            this.dgvAuftraege.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuftraege.Size = new System.Drawing.Size(887, 308);
            this.dgvAuftraege.TabIndex = 4;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // erfDatDataGridViewTextBoxColumn
            // 
            this.erfDatDataGridViewTextBoxColumn.DataPropertyName = "ErfDat";
            this.erfDatDataGridViewTextBoxColumn.HeaderText = "ErfDat";
            this.erfDatDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.erfDatDataGridViewTextBoxColumn.Name = "erfDatDataGridViewTextBoxColumn";
            this.erfDatDataGridViewTextBoxColumn.ReadOnly = true;
            this.erfDatDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // bezeichnungDataGridViewTextBoxColumn
            // 
            this.bezeichnungDataGridViewTextBoxColumn.DataPropertyName = "Bezeichnung";
            this.bezeichnungDataGridViewTextBoxColumn.HeaderText = "Bezeichnung";
            this.bezeichnungDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bezeichnungDataGridViewTextBoxColumn.Name = "bezeichnungDataGridViewTextBoxColumn";
            this.bezeichnungDataGridViewTextBoxColumn.ReadOnly = true;
            this.bezeichnungDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // erfUserDataGridViewTextBoxColumn
            // 
            this.erfUserDataGridViewTextBoxColumn.DataPropertyName = "ErfUser";
            this.erfUserDataGridViewTextBoxColumn.HeaderText = "ErfUser";
            this.erfUserDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.erfUserDataGridViewTextBoxColumn.Name = "erfUserDataGridViewTextBoxColumn";
            this.erfUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.erfUserDataGridViewTextBoxColumn.Width = 125;
            // 
            // viewBindingSource
            // 
            this.viewBindingSource.DataMember = "View";
            this.viewBindingSource.DataSource = this.database1DataSet1;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet1";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnErfassen
            // 
            this.btnErfassen.Location = new System.Drawing.Point(496, 195);
            this.btnErfassen.Name = "btnErfassen";
            this.btnErfassen.Size = new System.Drawing.Size(127, 49);
            this.btnErfassen.TabIndex = 5;
            this.btnErfassen.Text = "Erfassen >>";
            this.btnErfassen.UseVisualStyleBackColor = true;
            this.btnErfassen.Click += new System.EventHandler(this.btnErfassen_Click);
            // 
            // viewTableAdapter
            // 
            this.viewTableAdapter.ClearBeforeFill = true;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(648, 11);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(170, 31);
            this.btnStatus.TabIndex = 6;
            this.btnStatus.Text = "nächster Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 462);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnErfassen);
            this.Controls.Add(this.dgvAuftraege);
            this.Controls.Add(this.txtDrucker);
            this.Controls.Add(this.lstbxDrucker);
            this.Controls.Add(this.txtArtikel);
            this.Controls.Add(this.lstbxArtikel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.artikelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.druckerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetDrucker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuftraege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxArtikel;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource artikelBindingSource;
        private Database1DataSetTableAdapters.ArtikelTableAdapter artikelTableAdapter;
        private System.Windows.Forms.TextBox txtArtikel;
        private System.Windows.Forms.ListBox lstbxDrucker;
        private Database1DataSetDrucker database1DataSetDrucker;
        private System.Windows.Forms.BindingSource druckerBindingSource;
        private Database1DataSetDruckerTableAdapters.DruckerTableAdapter druckerTableAdapter;
        private System.Windows.Forms.TextBox txtDrucker;
        private System.Windows.Forms.DataGridView dgvAuftraege;
        private System.Windows.Forms.Button btnErfassen;
        private Database1DataSet1 database1DataSet1;
        private System.Windows.Forms.BindingSource viewBindingSource;
        private Database1DataSet1TableAdapters.ViewTableAdapter viewTableAdapter;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn erfDatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bezeichnungDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn erfUserDataGridViewTextBoxColumn;
    }
}

