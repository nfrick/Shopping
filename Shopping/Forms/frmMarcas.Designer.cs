namespace Shopping {
    partial class frmMarcas {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewMarcasSim = new System.Windows.Forms.ListView();
            this.listViewMarcasCompradas = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelProduto = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(246, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Marcas Boas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Marcas Compradas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listViewMarcasSim, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listViewMarcasCompradas, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelProduto, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 274);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listViewMarcasSim
            // 
            this.listViewMarcasSim.AllowDrop = true;
            this.listViewMarcasSim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMarcasSim.Location = new System.Drawing.Point(246, 64);
            this.listViewMarcasSim.Name = "listViewMarcasSim";
            this.listViewMarcasSim.Size = new System.Drawing.Size(238, 167);
            this.listViewMarcasSim.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewMarcasSim.TabIndex = 5;
            this.listViewMarcasSim.UseCompatibleStateImageBehavior = false;
            this.listViewMarcasSim.View = System.Windows.Forms.View.List;
            this.listViewMarcasSim.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.listViewMarcasSim.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listViewMarcasSim.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_DragOver);
            this.listViewMarcasSim.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMarcas_MouseDoubleClick);
            // 
            // listViewMarcasCompradas
            // 
            this.listViewMarcasCompradas.AllowDrop = true;
            this.listViewMarcasCompradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMarcasCompradas.Location = new System.Drawing.Point(3, 64);
            this.listViewMarcasCompradas.Name = "listViewMarcasCompradas";
            this.listViewMarcasCompradas.Size = new System.Drawing.Size(237, 167);
            this.listViewMarcasCompradas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewMarcasCompradas.TabIndex = 4;
            this.listViewMarcasCompradas.UseCompatibleStateImageBehavior = false;
            this.listViewMarcasCompradas.View = System.Windows.Forms.View.List;
            this.listViewMarcasCompradas.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.listViewMarcasCompradas.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listViewMarcasCompradas.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_DragOver);
            this.listViewMarcasCompradas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMarcas_MouseDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Controls.Add(this.buttonReset, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSave, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCancel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(246, 237);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(238, 34);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // buttonReset
            // 
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(3, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(72, 28);
            this.buttonReset.TabIndex = 0;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(81, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(72, 28);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(159, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 28);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelProduto
            // 
            this.labelProduto.AutoSize = true;
            this.labelProduto.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.SetColumnSpan(this.labelProduto, 2);
            this.labelProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProduto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto.Location = new System.Drawing.Point(3, 0);
            this.labelProduto.Name = "labelProduto";
            this.labelProduto.Size = new System.Drawing.Size(481, 33);
            this.labelProduto.TabIndex = 7;
            this.labelProduto.Text = "Produto";
            this.labelProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 274);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marcas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMarcas_FormClosing);
            this.Load += new System.EventHandler(this.frmMarcas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewMarcasSim;
        private System.Windows.Forms.ListView listViewMarcasCompradas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelProduto;
    }
}