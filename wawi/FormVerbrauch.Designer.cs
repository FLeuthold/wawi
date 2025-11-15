namespace wawi
{
    partial class FormVerbrauch
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.viewVerbrauchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.verbrauchDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.verbrauchDS = new wawi.verbrauchDS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.viewVerbrauchTableAdapter = new wawi.verbrauchDSTableAdapters.ViewVerbrauchTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.viewVerbrauchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verbrauchDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verbrauchDS)).BeginInit();
            this.SuspendLayout();
            // 
            // viewVerbrauchBindingSource
            // 
            this.viewVerbrauchBindingSource.DataMember = "ViewVerbrauch";
            this.viewVerbrauchBindingSource.DataSource = this.verbrauchDSBindingSource;
            // 
            // verbrauchDSBindingSource
            // 
            this.verbrauchDSBindingSource.DataSource = this.verbrauchDS;
            this.verbrauchDSBindingSource.Position = 0;
            // 
            // verbrauchDS
            // 
            this.verbrauchDS.DataSetName = "verbrauchDS";
            this.verbrauchDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.viewVerbrauchBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "wawi.Verbrauch.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            // 
            // viewVerbrauchTableAdapter
            // 
            this.viewVerbrauchTableAdapter.ClearBeforeFill = true;
            // 
            // FormVerbrauch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormVerbrauch";
            this.Text = "Verbrauch";
            this.Load += new System.EventHandler(this.FormVerbrauch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewVerbrauchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verbrauchDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verbrauchDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private verbrauchDS verbrauchDS;
        private System.Windows.Forms.BindingSource verbrauchDSBindingSource;
        private System.Windows.Forms.BindingSource viewVerbrauchBindingSource;
        private verbrauchDSTableAdapters.ViewVerbrauchTableAdapter viewVerbrauchTableAdapter;
    }
}