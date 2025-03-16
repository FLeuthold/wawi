namespace wawi
{
    partial class frmBestellvorschlag
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.database1DataSetBestellvorschlag = new wawi.Database1DataSetBestellvorschlag();
            this.viewBestellvorschlagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewBestellvorschlagTableAdapter = new wawi.Database1DataSetBestellvorschlagTableAdapters.ViewBestellvorschlagTableAdapter();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mindestbestandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bestellvorschlagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBestellvorschlag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBestellvorschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBestellvorschlagBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.mindestbestandDataGridViewTextBoxColumn,
            this.bestellvorschlagDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.viewBestellvorschlagBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(18, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(889, 322);
            this.dataGridView1.TabIndex = 0;
            // 
            // database1DataSetBestellvorschlag
            // 
            this.database1DataSetBestellvorschlag.DataSetName = "Database1DataSetBestellvorschlag";
            this.database1DataSetBestellvorschlag.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewBestellvorschlagBindingSource
            // 
            this.viewBestellvorschlagBindingSource.DataMember = "ViewBestellvorschlag";
            this.viewBestellvorschlagBindingSource.DataSource = this.database1DataSetBestellvorschlag;
            // 
            // viewBestellvorschlagTableAdapter
            // 
            this.viewBestellvorschlagTableAdapter.ClearBeforeFill = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // mindestbestandDataGridViewTextBoxColumn
            // 
            this.mindestbestandDataGridViewTextBoxColumn.DataPropertyName = "Mindestbestand";
            this.mindestbestandDataGridViewTextBoxColumn.HeaderText = "Mindestbestand";
            this.mindestbestandDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mindestbestandDataGridViewTextBoxColumn.Name = "mindestbestandDataGridViewTextBoxColumn";
            this.mindestbestandDataGridViewTextBoxColumn.Width = 125;
            // 
            // bestellvorschlagDataGridViewTextBoxColumn
            // 
            this.bestellvorschlagDataGridViewTextBoxColumn.DataPropertyName = "Bestellvorschlag";
            this.bestellvorschlagDataGridViewTextBoxColumn.HeaderText = "Bestellvorschlag";
            this.bestellvorschlagDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bestellvorschlagDataGridViewTextBoxColumn.Name = "bestellvorschlagDataGridViewTextBoxColumn";
            this.bestellvorschlagDataGridViewTextBoxColumn.ReadOnly = true;
            this.bestellvorschlagDataGridViewTextBoxColumn.Width = 125;
            // 
            // btnBestellvorschlag
            // 
            this.btnBestellvorschlag.Location = new System.Drawing.Point(36, 23);
            this.btnBestellvorschlag.Name = "btnBestellvorschlag";
            this.btnBestellvorschlag.Size = new System.Drawing.Size(206, 50);
            this.btnBestellvorschlag.TabIndex = 1;
            this.btnBestellvorschlag.Text = "Bestellvorschlag bestellen";
            this.btnBestellvorschlag.UseVisualStyleBackColor = true;
            this.btnBestellvorschlag.Click += new System.EventHandler(this.btnBestellvorschlag_Click);
            // 
            // frmBestellvorschlag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 450);
            this.Controls.Add(this.btnBestellvorschlag);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmBestellvorschlag";
            this.Text = "Bestellvorschlag";
            this.Load += new System.EventHandler(this.frmBestellvorschlag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBestellvorschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBestellvorschlagBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Database1DataSetBestellvorschlag database1DataSetBestellvorschlag;
        private System.Windows.Forms.BindingSource viewBestellvorschlagBindingSource;
        private Database1DataSetBestellvorschlagTableAdapters.ViewBestellvorschlagTableAdapter viewBestellvorschlagTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mindestbestandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bestellvorschlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnBestellvorschlag;
    }
}