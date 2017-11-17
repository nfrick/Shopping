namespace Shopping {
    partial class frmConfig {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.propertyGridConn = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.buttonLocalDB = new System.Windows.Forms.Button();
            this.comboBoxStrings = new System.Windows.Forms.ComboBox();
            this.buttonSQLExpress = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Enabled = false;
            this.buttonSave.Image = global::Shopping.Properties.Resources.dialog_ok_apply;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSave.Location = new System.Drawing.Point(3, 502);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(137, 54);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxString, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonSave, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.propertyGridConn, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(947, 559);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // textBoxString
            // 
            this.textBoxString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxString.Location = new System.Drawing.Point(146, 502);
            this.textBoxString.Multiline = true;
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.ReadOnly = true;
            this.textBoxString.Size = new System.Drawing.Size(798, 54);
            this.textBoxString.TabIndex = 11;
            // 
            // propertyGridConn
            // 
            this.propertyGridConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridConn.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGridConn.Location = new System.Drawing.Point(146, 43);
            this.propertyGridConn.Name = "propertyGridConn";
            this.propertyGridConn.Size = new System.Drawing.Size(798, 453);
            this.propertyGridConn.TabIndex = 10;
            this.propertyGridConn.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridConn_PropertyValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonTestConnection, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonLocalDB, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxStrings, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSQLExpress, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(137, 141);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTestConnection.Enabled = false;
            this.buttonTestConnection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTestConnection.Location = new System.Drawing.Point(3, 108);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(131, 30);
            this.buttonTestConnection.TabIndex = 7;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // buttonLocalDB
            // 
            this.buttonLocalDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLocalDB.Enabled = false;
            this.buttonLocalDB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLocalDB.Location = new System.Drawing.Point(3, 73);
            this.buttonLocalDB.Name = "buttonLocalDB";
            this.buttonLocalDB.Size = new System.Drawing.Size(131, 29);
            this.buttonLocalDB.TabIndex = 6;
            this.buttonLocalDB.Text = "Reset LocalDB";
            this.buttonLocalDB.UseVisualStyleBackColor = true;
            // 
            // comboBoxStrings
            // 
            this.comboBoxStrings.FormattingEnabled = true;
            this.comboBoxStrings.Location = new System.Drawing.Point(3, 3);
            this.comboBoxStrings.Name = "comboBoxStrings";
            this.comboBoxStrings.Size = new System.Drawing.Size(131, 36);
            this.comboBoxStrings.TabIndex = 4;
            this.comboBoxStrings.SelectedIndexChanged += new System.EventHandler(this.comboBoxStrings_SelectedIndexChanged);
            // 
            // buttonSQLExpress
            // 
            this.buttonSQLExpress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSQLExpress.Enabled = false;
            this.buttonSQLExpress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSQLExpress.Location = new System.Drawing.Point(3, 38);
            this.buttonSQLExpress.Name = "buttonSQLExpress";
            this.buttonSQLExpress.Size = new System.Drawing.Size(131, 29);
            this.buttonSQLExpress.TabIndex = 5;
            this.buttonSQLExpress.Text = "Reset SQLExpress";
            this.buttonSQLExpress.UseVisualStyleBackColor = true;
            this.buttonSQLExpress.Click += new System.EventHandler(this.buttonSQLExpress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel3.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(941, 40);
            this.label1.TabIndex = 19;
            this.label1.Text = "CONEXÕES COM BANCO DE DADOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 559);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.PropertyGrid propertyGridConn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBoxStrings;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.Button buttonLocalDB;
        private System.Windows.Forms.Button buttonSQLExpress;
    }
}