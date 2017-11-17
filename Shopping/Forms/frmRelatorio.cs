using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shopping
{
    public partial class frmRelatorio : Form {
        public frmRelatorio() {
            InitializeComponent();
        }

        private void frmImpressos_Load(object sender, EventArgs e) {
            this.reportViewer1.RefreshReport();
        }

        public void SetReport<T>(List<T> items, string reportName, string reportDataSet) {
            var reportEngine = reportViewer1.LocalReport;
            reportEngine.ReportPath = $@"{AppDomain.CurrentDomain.BaseDirectory}Reports\{reportName}.rdlc";
            reportEngine.DataSources.Clear();
            reportEngine.DataSources.Add(new ReportDataSource(reportDataSet, items));
            this.Show();
        }
    }
}
