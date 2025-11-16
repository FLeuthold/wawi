namespace wawi
{
    partial class FormBestellvorschlag
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBestellvorschlag = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(889, 322);
            this.dataGridView1.TabIndex = 0;
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(267, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(126, 50);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormBestellvorschlag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBestellvorschlag);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormBestellvorschlag";
            this.Text = "Bestellvorschlag";
            this.Load += new System.EventHandler(this.frmBestellvorschlag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mindestbestandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bestellvorschlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnBestellvorschlag;
        private System.Windows.Forms.Button btnRefresh;
    }
}