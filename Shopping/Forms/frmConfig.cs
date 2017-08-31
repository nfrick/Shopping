using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Shopping {
    public partial class frmConfig : Form {
        private SqlConnectionStringBuilder _sqlConnSb;
        private OleDbConnectionStringBuilder _oleConnSb;

        public frmConfig() {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e) {
            var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            foreach (ConnectionStringSettings str in config.ConnectionStrings.ConnectionStrings) {
                comboBoxStrings.Items.Add(str.Name);
            }
            textBoxReportPath.Text = config.AppSettings.Settings[@"reportpath"].Value;
            buttonSave.Enabled = false;
        }

        private void comboBoxStrings_SelectedIndexChanged(object sender, EventArgs e) {
            var connName = comboBoxStrings.SelectedItem.ToString();
            var str = ConfigurationManager.ConnectionStrings[connName].ToString();
            textBoxString.Text = str;
            if (connName == "CSV") {
                _oleConnSb = new OleDbConnectionStringBuilder(str);
                propertyGridConn.SelectedObject = _oleConnSb;
            }
            else {
                _sqlConnSb = new SqlConnectionStringBuilder(str);
                propertyGridConn.SelectedObject = _sqlConnSb;
            }
            buttonSQLExpress.Enabled = connName == "Shopping";
            buttonLocalDB.Enabled = connName == "Shopping";
            buttonTestConnection.Enabled = connName == "Shopping";
        }

        private void propertyGridConn_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            var connectionStringBuilder = (DbConnectionStringBuilder) propertyGridConn.SelectedObject;
            textBoxString.Text = connectionStringBuilder.ConnectionString;
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            Save();
        }

        private void Save() {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (comboBoxStrings.SelectedItem != null) {
                var connName = comboBoxStrings.SelectedItem.ToString();
                var connectionStringsSection = (ConnectionStringsSection) config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings[connName].ConnectionString = textBoxString.Text;
            }
            config.AppSettings.Settings[@"reportpath"].Value = textBoxReportPath.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            ConfigurationManager.RefreshSection("appSettings");
            buttonSave.Enabled = false;
        }

        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e) {
            if (!buttonSave.Enabled)
                return;
            switch (MessageBox.Show(@"Salvar alterações?", @"Configuração", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question)) {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
            }
        }

        private void buttonReports_Click(object sender, EventArgs e) {
            FBD.SelectedPath = textBoxReportPath.Text;
            if (FBD.ShowDialog() != DialogResult.OK || textBoxReportPath.Text == FBD.SelectedPath) return;

            if (Directory.EnumerateFileSystemEntries(FBD.SelectedPath, "*.rdlc").Any())
                textBoxReportPath.Text = FBD.SelectedPath;
            else {
                MessageBox.Show(@"Diretório não contém arquivos de relatório (*.rdlc)",
                    @"Configuração", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBoxReportPath_TextChanged(object sender, EventArgs e) {
            buttonSave.Enabled = true;
        }

        private void buttonSQLExpress_Click(object sender, EventArgs e) {
            var connectionStringBuilder = (DbConnectionStringBuilder) propertyGridConn.SelectedObject;
            connectionStringBuilder.ConnectionString =
                @"Data Source=localhost\sqlExpress;Initial Catalog=Shopping;Integrated Security=True;";
            propertyGridConn.Refresh();
            buttonSave.Enabled = true;
        }

        private void buttonTestConnection_Click(object sender, EventArgs e) {
            var connectionStringBuilder = (DbConnectionStringBuilder) propertyGridConn.SelectedObject;
            try {
                var conn = new SqlConnection(connectionStringBuilder.ConnectionString);
                conn.Open();
                if (conn.State == ConnectionState.Open) {
                    MessageBox.Show(@"Conexão completada com sucesso!", @"Configuração", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    conn.Close();
                }
                else
                    MessageBox.Show(@"Conexão não completada. Verifique os parâmetros.", @"Configuração",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
            catch (Exception ex) {
                MessageBox.Show(@"Conexão não completada. Verifique os parâmetros.\n\n" +
                    connectionStringBuilder.ConnectionString + "\n\n" + ex.Message, @"Configuração",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }
}
