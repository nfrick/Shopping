namespace Shopping {
    partial class frmCategorias {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNavigatorCategorias = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.categoriaBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.categoriaDataGridView = new System.Windows.Forms.DataGridView();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocorrenciasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceCategorias = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCategorias)).BeginInit();
            this.bindingNavigatorCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigatorCategorias
            // 
            this.bindingNavigatorCategorias.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorCategorias.BindingSource = this.bindingSourceCategorias;
            this.bindingNavigatorCategorias.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorCategorias.CountItemFormat = "de {0}";
            this.bindingNavigatorCategorias.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorCategorias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigatorCategorias.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigatorCategorias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButtonReload,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.categoriaBindingNavigatorSaveItem});
            this.bindingNavigatorCategorias.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorCategorias.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorCategorias.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorCategorias.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorCategorias.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorCategorias.Name = "bindingNavigatorCategorias";
            this.bindingNavigatorCategorias.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorCategorias.Size = new System.Drawing.Size(374, 31);
            this.bindingNavigatorCategorias.TabIndex = 0;
            this.bindingNavigatorCategorias.Text = "bindingNavigator1";
            this.bindingNavigatorCategorias.Visible = false;
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = global::Shopping.Properties.Resources.ActionsListAddIcon;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorAddNewItem.Text = "Nova categoria";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(42, 28);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número de categorias";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = global::Shopping.Properties.Resources.ActionsEditDeleteIcon;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorDeleteItem.Text = "Deletar categoria";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = global::Shopping.Properties.Resources.ActionsGoFirstViewIcon;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Primeira categoria";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::Shopping.Properties.Resources.ActionsGoPreviousViewIcon;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMovePreviousItem.Text = "categoria anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posição atual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::Shopping.Properties.Resources.ActionsGoNexViewIcon;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveNextItem.Text = "Próxima categoria";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::Shopping.Properties.Resources.ActionsGoLastViewIcon;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveLastItem.Text = "Última categoria";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReload.Image = global::Shopping.Properties.Resources.ActionsViewRefreshicon;
            this.toolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonReload.Text = "Recarregar";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            // 
            // categoriaBindingNavigatorSaveItem
            // 
            this.categoriaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.categoriaBindingNavigatorSaveItem.Enabled = false;
            this.categoriaBindingNavigatorSaveItem.Image = global::Shopping.Properties.Resources.ActionsDocumentSaveIcon;
            this.categoriaBindingNavigatorSaveItem.Name = "categoriaBindingNavigatorSaveItem";
            this.categoriaBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.categoriaBindingNavigatorSaveItem.Text = "Gravar categoria";
            this.categoriaBindingNavigatorSaveItem.Click += new System.EventHandler(this.categoriaBindingNavigatorSaveItem_Click);
            // 
            // categoriaDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.categoriaDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.categoriaDataGridView.AutoGenerateColumns = false;
            this.categoriaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoriaDataGridViewTextBoxColumn,
            this.ocorrenciasDataGridViewTextBoxColumn});
            this.categoriaDataGridView.DataSource = this.bindingSourceCategorias;
            this.categoriaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriaDataGridView.Location = new System.Drawing.Point(0, 0);
            this.categoriaDataGridView.Name = "categoriaDataGridView";
            this.categoriaDataGridView.RowHeadersWidth = 25;
            this.categoriaDataGridView.RowTemplate.Height = 26;
            this.categoriaDataGridView.Size = new System.Drawing.Size(374, 353);
            this.categoriaDataGridView.TabIndex = 1;
            this.categoriaDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.categoriaDataGridView_CellFormatting);
            this.categoriaDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.categoriaDataGridView_CellValueChanged);
            this.categoriaDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.categoriaDataGridView_RowEnter);
            this.categoriaDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.categoriaDataGridView_UserDeletingRow);
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            // 
            // ocorrenciasDataGridViewTextBoxColumn
            // 
            this.ocorrenciasDataGridViewTextBoxColumn.DataPropertyName = "Produtos";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ocorrenciasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ocorrenciasDataGridViewTextBoxColumn.HeaderText = "Produtos";
            this.ocorrenciasDataGridViewTextBoxColumn.Name = "ocorrenciasDataGridViewTextBoxColumn";
            this.ocorrenciasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceCategorias
            // 
            this.bindingSourceCategorias.DataSource = typeof(Shopping.clsCategoria);
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 353);
            this.Controls.Add(this.categoriaDataGridView);
            this.Controls.Add(this.bindingNavigatorCategorias);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.Activated += new System.EventHandler(this.frmCategorias_Activated);
            this.Deactivate += new System.EventHandler(this.frmCategorias_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCategorias_FormClosing);
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCategorias)).EndInit();
            this.bindingNavigatorCategorias.ResumeLayout(false);
            this.bindingNavigatorCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceCategorias;
        private System.Windows.Forms.BindingNavigator bindingNavigatorCategorias;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton categoriaBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView categoriaDataGridView;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocorrenciasDataGridViewTextBoxColumn;
    }
}