namespace Shopping {
    partial class frmProdutos {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewProdutos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListaPadrao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MarcasSim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcasNao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcasCompradas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ocorrencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdMedia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdUlt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoMedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoUlt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataUlt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceProdutos = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.produtoBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxCategoria = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorProdutos = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButtonEstatistica = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonQtdFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMarcas = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorProdutos)).BeginInit();
            this.bindingNavigatorProdutos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProdutos
            // 
            this.dataGridViewProdutos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProdutos.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Produto,
            this.Categoria,
            this.Unidade,
            this.QtdNormal,
            this.ListaPadrao,
            this.MarcasSim,
            this.MarcasNao,
            this.MarcasCompradas,
            this.Ocorrencias,
            this.QtdMin,
            this.QtdMedia,
            this.QtdMax,
            this.QtdUlt,
            this.PrecoMin,
            this.PrecoMedio,
            this.PrecoMax,
            this.PrecoUlt,
            this.DataUlt});
            this.dataGridViewProdutos.DataSource = this.bindingSourceProdutos;
            this.dataGridViewProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProdutos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProdutos.MultiSelect = false;
            this.dataGridViewProdutos.Name = "dataGridViewProdutos";
            this.dataGridViewProdutos.RowHeadersWidth = 25;
            this.dataGridViewProdutos.RowTemplate.Height = 28;
            this.dataGridViewProdutos.Size = new System.Drawing.Size(1309, 596);
            this.dataGridViewProdutos.TabIndex = 1;
            this.dataGridViewProdutos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewProdutos_CellBeginEdit);
            this.dataGridViewProdutos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProdutos_CellEndEdit);
            this.dataGridViewProdutos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.produtoDataGridView_CellFormatting);
            this.dataGridViewProdutos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewProdutos_CellMouseDoubleClick);
            this.dataGridViewProdutos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewProdutos_CellValidating);
            this.dataGridViewProdutos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtoDataGridView_CellValueChanged);
            this.dataGridViewProdutos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewProdutos_ColumnHeaderMouseClick);
            this.dataGridViewProdutos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewProdutos_DataError);
            this.dataGridViewProdutos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewProdutos_EditingControlShowing);
            this.dataGridViewProdutos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtoDataGridView_RowEnter);
            this.dataGridViewProdutos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.produtoDataGridView_UserDeletingRow);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "CategoriaID";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Categoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Categoria.Width = 200;
            // 
            // Unidade
            // 
            this.Unidade.DataPropertyName = "Unidade";
            this.Unidade.HeaderText = "Unid.";
            this.Unidade.Name = "Unidade";
            this.Unidade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unidade.Width = 60;
            // 
            // QtdNormal
            // 
            this.QtdNormal.DataPropertyName = "QtdNormal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.QtdNormal.DefaultCellStyle = dataGridViewCellStyle3;
            this.QtdNormal.HeaderText = "Qtd Normal";
            this.QtdNormal.Name = "QtdNormal";
            this.QtdNormal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtdNormal.Width = 80;
            // 
            // ListaPadrao
            // 
            this.ListaPadrao.DataPropertyName = "ListaPadrao";
            this.ListaPadrao.HeaderText = "Lista Padrão";
            this.ListaPadrao.Name = "ListaPadrao";
            this.ListaPadrao.Width = 60;
            // 
            // MarcasSim
            // 
            this.MarcasSim.DataPropertyName = "MarcasSim";
            this.MarcasSim.HeaderText = "Marcas Boas";
            this.MarcasSim.Name = "MarcasSim";
            this.MarcasSim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MarcasSim.Width = 200;
            // 
            // MarcasNao
            // 
            this.MarcasNao.DataPropertyName = "MarcasNao";
            this.MarcasNao.HeaderText = "Evitar as Marcas";
            this.MarcasNao.Name = "MarcasNao";
            this.MarcasNao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MarcasNao.Width = 200;
            // 
            // MarcasCompradas
            // 
            this.MarcasCompradas.DataPropertyName = "MarcasCompradas";
            this.MarcasCompradas.HeaderText = "Marcas Compradas";
            this.MarcasCompradas.Name = "MarcasCompradas";
            this.MarcasCompradas.ReadOnly = true;
            this.MarcasCompradas.Visible = false;
            this.MarcasCompradas.Width = 200;
            // 
            // Ocorrencias
            // 
            this.Ocorrencias.DataPropertyName = "Ocorrencias";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.Ocorrencias.DefaultCellStyle = dataGridViewCellStyle4;
            this.Ocorrencias.HeaderText = "Ocorr.";
            this.Ocorrencias.Name = "Ocorrencias";
            this.Ocorrencias.ReadOnly = true;
            this.Ocorrencias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ocorrencias.Visible = false;
            this.Ocorrencias.Width = 80;
            // 
            // QtdMin
            // 
            this.QtdMin.DataPropertyName = "QtdMin";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            this.QtdMin.DefaultCellStyle = dataGridViewCellStyle5;
            this.QtdMin.HeaderText = "Qtd Min";
            this.QtdMin.Name = "QtdMin";
            this.QtdMin.ReadOnly = true;
            this.QtdMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtdMin.Visible = false;
            this.QtdMin.Width = 80;
            // 
            // QtdMedia
            // 
            this.QtdMedia.DataPropertyName = "QtdMed";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            this.QtdMedia.DefaultCellStyle = dataGridViewCellStyle6;
            this.QtdMedia.HeaderText = "Qtd Média";
            this.QtdMedia.Name = "QtdMedia";
            this.QtdMedia.ReadOnly = true;
            this.QtdMedia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtdMedia.Visible = false;
            this.QtdMedia.Width = 80;
            // 
            // QtdMax
            // 
            this.QtdMax.DataPropertyName = "QtdMax";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N3";
            this.QtdMax.DefaultCellStyle = dataGridViewCellStyle7;
            this.QtdMax.HeaderText = "Qtd Max";
            this.QtdMax.Name = "QtdMax";
            this.QtdMax.ReadOnly = true;
            this.QtdMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtdMax.Visible = false;
            this.QtdMax.Width = 80;
            // 
            // QtdUlt
            // 
            this.QtdUlt.DataPropertyName = "QtdUlt";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            this.QtdUlt.DefaultCellStyle = dataGridViewCellStyle8;
            this.QtdUlt.HeaderText = "Última Qtd";
            this.QtdUlt.Name = "QtdUlt";
            this.QtdUlt.ReadOnly = true;
            this.QtdUlt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtdUlt.Width = 80;
            // 
            // PrecoMin
            // 
            this.PrecoMin.DataPropertyName = "PrecoMin";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            this.PrecoMin.DefaultCellStyle = dataGridViewCellStyle9;
            this.PrecoMin.HeaderText = "Preço Min";
            this.PrecoMin.Name = "PrecoMin";
            this.PrecoMin.ReadOnly = true;
            this.PrecoMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PrecoMin.Visible = false;
            this.PrecoMin.Width = 80;
            // 
            // PrecoMedio
            // 
            this.PrecoMedio.DataPropertyName = "PrecoMed";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            this.PrecoMedio.DefaultCellStyle = dataGridViewCellStyle10;
            this.PrecoMedio.HeaderText = "Preço Médio";
            this.PrecoMedio.Name = "PrecoMedio";
            this.PrecoMedio.ReadOnly = true;
            this.PrecoMedio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PrecoMedio.Visible = false;
            this.PrecoMedio.Width = 80;
            // 
            // PrecoMax
            // 
            this.PrecoMax.DataPropertyName = "PrecoMax";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C2";
            this.PrecoMax.DefaultCellStyle = dataGridViewCellStyle11;
            this.PrecoMax.HeaderText = "Preço Max";
            this.PrecoMax.Name = "PrecoMax";
            this.PrecoMax.ReadOnly = true;
            this.PrecoMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PrecoMax.Visible = false;
            this.PrecoMax.Width = 80;
            // 
            // PrecoUlt
            // 
            this.PrecoUlt.DataPropertyName = "PrecoUlt";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            this.PrecoUlt.DefaultCellStyle = dataGridViewCellStyle12;
            this.PrecoUlt.HeaderText = "Último Preço";
            this.PrecoUlt.Name = "PrecoUlt";
            this.PrecoUlt.ReadOnly = true;
            this.PrecoUlt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PrecoUlt.Width = 80;
            // 
            // DataUlt
            // 
            this.DataUlt.DataPropertyName = "DataUlt";
            this.DataUlt.HeaderText = "Última Compra";
            this.DataUlt.Name = "DataUlt";
            this.DataUlt.ReadOnly = true;
            // 
            // bindingSourceProdutos
            // 
            this.bindingSourceProdutos.DataSource = typeof(Shopping.clsProduto);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = global::Shopping.Properties.Resources.ActionsGoFirstViewIcon;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro produto";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::Shopping.Properties.Resources.ActionsGoPreviousViewIcon;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Produto anterior";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(53, 28);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Númeor de produtos";
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
            this.bindingNavigatorMoveNextItem.Text = "Próximo produto";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::Shopping.Properties.Resources.ActionsGoLastViewIcon;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveLastItem.Text = "Último produto";
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
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = global::Shopping.Properties.Resources.ActionsListAddIcon;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorAddNewItem.Text = "Novo produto";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = global::Shopping.Properties.Resources.ActionsEditDeleteIcon;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorDeleteItem.Text = "Deletar produto";
            // 
            // produtoBindingNavigatorSaveItem
            // 
            this.produtoBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.produtoBindingNavigatorSaveItem.Enabled = false;
            this.produtoBindingNavigatorSaveItem.Image = global::Shopping.Properties.Resources.ActionsDocumentSaveIcon;
            this.produtoBindingNavigatorSaveItem.Name = "produtoBindingNavigatorSaveItem";
            this.produtoBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.produtoBindingNavigatorSaveItem.Text = "Gravar produto";
            this.produtoBindingNavigatorSaveItem.Click += new System.EventHandler(this.produtoBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 28);
            this.toolStripLabel1.Text = "Categoria";
            // 
            // toolStripComboBoxCategoria
            // 
            this.toolStripComboBoxCategoria.Name = "toolStripComboBoxCategoria";
            this.toolStripComboBoxCategoria.Size = new System.Drawing.Size(121, 31);
            this.toolStripComboBoxCategoria.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxCategoria_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorProdutos
            // 
            this.bindingNavigatorProdutos.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorProdutos.BindingSource = this.bindingSourceProdutos;
            this.bindingNavigatorProdutos.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorProdutos.CountItemFormat = "de {0}";
            this.bindingNavigatorProdutos.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorProdutos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigatorProdutos.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigatorProdutos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.produtoBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripComboBoxCategoria,
            this.toolStripSeparator2,
            this.toolStripButtonEstatistica,
            this.toolStripButtonQtdFilter,
            this.toolStripButtonMarcas});
            this.bindingNavigatorProdutos.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorProdutos.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorProdutos.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorProdutos.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorProdutos.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorProdutos.Name = "bindingNavigatorProdutos";
            this.bindingNavigatorProdutos.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorProdutos.Size = new System.Drawing.Size(1309, 31);
            this.bindingNavigatorProdutos.TabIndex = 0;
            this.bindingNavigatorProdutos.Text = "bindingNavigator1";
            this.bindingNavigatorProdutos.Visible = false;
            // 
            // toolStripButtonEstatistica
            // 
            this.toolStripButtonEstatistica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEstatistica.Image = global::Shopping.Properties.Resources.office_chart_bar;
            this.toolStripButtonEstatistica.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEstatistica.Name = "toolStripButtonEstatistica";
            this.toolStripButtonEstatistica.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonEstatistica.Text = "Estatística";
            this.toolStripButtonEstatistica.Click += new System.EventHandler(this.toolStripButtonCompras_Click);
            // 
            // toolStripButtonQtdFilter
            // 
            this.toolStripButtonQtdFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonQtdFilter.Image = global::Shopping.Properties.Resources.Filter_List_icon32;
            this.toolStripButtonQtdFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQtdFilter.Name = "toolStripButtonQtdFilter";
            this.toolStripButtonQtdFilter.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonQtdFilter.ToolTipText = "Diferença entre Qtd Média e Normal > 20%";
            this.toolStripButtonQtdFilter.Click += new System.EventHandler(this.toolStripButtonQtdFilter_Click);
            // 
            // toolStripButtonMarcas
            // 
            this.toolStripButtonMarcas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMarcas.Image = global::Shopping.Properties.Resources.Thumb_Up_icon;
            this.toolStripButtonMarcas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMarcas.Name = "toolStripButtonMarcas";
            this.toolStripButtonMarcas.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonMarcas.Text = "Modo edição de \'Marcas Sim\'";
            this.toolStripButtonMarcas.Click += new System.EventHandler(this.toolStripButtonMarcas_Click);
            // 
            // frmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 596);
            this.Controls.Add(this.dataGridViewProdutos);
            this.Controls.Add(this.bindingNavigatorProdutos);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos";
            this.Activated += new System.EventHandler(this.frmProdutos_Activated);
            this.Deactivate += new System.EventHandler(this.frmProdutos_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProdutos_FormClosing);
            this.Load += new System.EventHandler(this.frmProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorProdutos)).EndInit();
            this.bindingNavigatorProdutos.ResumeLayout(false);
            this.bindingNavigatorProdutos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceProdutos;
        private System.Windows.Forms.DataGridView dataGridViewProdutos;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton produtoBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCategoria;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.BindingNavigator bindingNavigatorProdutos;
        private System.Windows.Forms.ToolStripButton toolStripButtonEstatistica;
        private System.Windows.Forms.ToolStripButton toolStripButtonQtdFilter;
        private System.Windows.Forms.ToolStripButton toolStripButtonMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewComboBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdNormal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ListaPadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcasSim;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcasNao;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcasCompradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ocorrencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdMedia;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdUlt;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoMedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoUlt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataUlt;
    }
}