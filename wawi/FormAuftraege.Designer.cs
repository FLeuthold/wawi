namespace wawi
{
    partial class FormAuftraege
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
            this.lstbxArtikel = new System.Windows.Forms.ListBox();
            this.txtArtikel = new System.Windows.Forms.TextBox();
            this.lstbxDrucker = new System.Windows.Forms.ListBox();
            this.txtDrucker = new System.Windows.Forms.TextBox();
            this.dgvAuftraege = new System.Windows.Forms.DataGridView();
            this.btnErfassen = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErfDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrucker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErfUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuftraege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstbxArtikel
            // 
            this.lstbxArtikel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstbxArtikel.DisplayMember = "Name";
            this.lstbxArtikel.FormattingEnabled = true;
            this.lstbxArtikel.ItemHeight = 16;
            this.lstbxArtikel.Location = new System.Drawing.Point(39, 92);
            this.lstbxArtikel.Name = "lstbxArtikel";
            this.lstbxArtikel.Size = new System.Drawing.Size(195, 420);
            this.lstbxArtikel.TabIndex = 0;
            this.lstbxArtikel.ValueMember = "Id";
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
            this.lstbxDrucker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstbxDrucker.DisplayMember = "Bezeichnung";
            this.lstbxDrucker.FormattingEnabled = true;
            this.lstbxDrucker.ItemHeight = 16;
            this.lstbxDrucker.Location = new System.Drawing.Point(267, 92);
            this.lstbxDrucker.Name = "lstbxDrucker";
            this.lstbxDrucker.Size = new System.Drawing.Size(194, 420);
            this.lstbxDrucker.TabIndex = 2;
            this.lstbxDrucker.ValueMember = "Id";
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
            this.dgvAuftraege.AllowUserToResizeRows = false;
            this.dgvAuftraege.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuftraege.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAuftraege.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuftraege.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ErfDat,
            this.Id,
            this.colName,
            this.colDrucker,
            this.colStatus,
            this.colErfUser});
            this.dgvAuftraege.Location = new System.Drawing.Point(650, 75);
            this.dgvAuftraege.MultiSelect = false;
            this.dgvAuftraege.Name = "dgvAuftraege";
            this.dgvAuftraege.ReadOnly = true;
            this.dgvAuftraege.RowHeadersVisible = false;
            this.dgvAuftraege.RowHeadersWidth = 51;
            this.dgvAuftraege.RowTemplate.Height = 24;
            this.dgvAuftraege.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuftraege.Size = new System.Drawing.Size(628, 136);
            this.dgvAuftraege.TabIndex = 4;
            this.dgvAuftraege.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAuftraege_RowPrePaint);
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
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(650, 38);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(170, 31);
            this.btnStatus.TabIndex = 6;
            this.btnStatus.Text = "nächster Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(968, 217);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(310, 327);
            this.dataGridView2.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(650, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(310, 327);
            this.dataGridView1.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ErfDat";
            this.dataGridViewTextBoxColumn1.HeaderText = "ErfDat";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Bezeichnung";
            this.dataGridViewTextBoxColumn4.HeaderText = "Drucker";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ErfUser";
            this.dataGridViewTextBoxColumn6.HeaderText = "ErfUser";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // ErfDat
            // 
            this.ErfDat.DataPropertyName = "ErfDat";
            this.ErfDat.HeaderText = "ErfDat";
            this.ErfDat.MinimumWidth = 6;
            this.ErfDat.Name = "ErfDat";
            this.ErfDat.ReadOnly = true;
            this.ErfDat.Width = 125;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Artikel";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 125;
            // 
            // colDrucker
            // 
            this.colDrucker.DataPropertyName = "Bezeichnung";
            this.colDrucker.HeaderText = "Drucker";
            this.colDrucker.MinimumWidth = 6;
            this.colDrucker.Name = "colDrucker";
            this.colDrucker.ReadOnly = true;
            this.colDrucker.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 125;
            // 
            // colErfUser
            // 
            this.colErfUser.DataPropertyName = "ErfUser";
            this.colErfUser.HeaderText = "ErfUser";
            this.colErfUser.MinimumWidth = 6;
            this.colErfUser.Name = "colErfUser";
            this.colErfUser.ReadOnly = true;
            this.colErfUser.Width = 125;
            // 
            // FormAuftraege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 580);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnErfassen);
            this.Controls.Add(this.dgvAuftraege);
            this.Controls.Add(this.txtDrucker);
            this.Controls.Add(this.lstbxDrucker);
            this.Controls.Add(this.txtArtikel);
            this.Controls.Add(this.lstbxArtikel);
            this.Name = "FormAuftraege";
            this.Text = "Aufträge";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuftraege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxArtikel;
        private System.Windows.Forms.TextBox txtArtikel;
        private System.Windows.Forms.ListBox lstbxDrucker;
        private System.Windows.Forms.TextBox txtDrucker;
        private System.Windows.Forms.DataGridView dgvAuftraege;
        private System.Windows.Forms.Button btnErfassen;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErfDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrucker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErfUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

