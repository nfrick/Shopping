namespace Shopping {
    partial class frmProdutosPicklist {
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutosPicklist));
            this.listViewProdutos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonOrdemAlfabetica = new System.Windows.Forms.RadioButton();
            this.radioButtonOrdemCategoria = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonExibirNaoSelecionados = new System.Windows.Forms.RadioButton();
            this.radioButtonExibirSelecionados = new System.Windows.Forms.RadioButton();
            this.radioButtonExibirEventuais = new System.Windows.Forms.RadioButton();
            this.radioButtonExibirPadrao = new System.Windows.Forms.RadioButton();
            this.radioButtonExibirTodos = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.buttonNenhum = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusPadraoSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusPadraoDisp = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusEventuaisSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusEventuaisDisp = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewProdutos
            // 
            this.listViewProdutos.CheckBoxes = true;
            this.listViewProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProdutos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listViewProdutos.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listViewProdutos.Location = new System.Drawing.Point(4, 4);
            this.listViewProdutos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewProdutos.Name = "listViewProdutos";
            this.listViewProdutos.Size = new System.Drawing.Size(525, 535);
            this.listViewProdutos.TabIndex = 0;
            this.listViewProdutos.UseCompatibleStateImageBehavior = false;
            this.listViewProdutos.View = System.Windows.Forms.View.Details;
            this.listViewProdutos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewProdutos_ItemChecked);
            this.listViewProdutos.SelectedIndexChanged += new System.EventHandler(this.listViewProdutos_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Produto";
            this.columnHeader1.Width = 360;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 533F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.listViewProdutos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(739, 543);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonAdicionar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonSair, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(537, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(198, 535);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdicionar.Enabled = false;
            this.buttonAdicionar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionar.Image = global::Shopping.Properties.Resources.ShopCartAdd_24x24;
            this.buttonAdicionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAdicionar.Location = new System.Drawing.Point(4, 4);
            this.buttonAdicionar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(190, 62);
            this.buttonAdicionar.TabIndex = 2;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonOrdemAlfabetica);
            this.groupBox1.Controls.Add(this.radioButtonOrdemCategoria);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 254);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(190, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordem";
            // 
            // radioButtonOrdemAlfabetica
            // 
            this.radioButtonOrdemAlfabetica.AutoSize = true;
            this.radioButtonOrdemAlfabetica.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOrdemAlfabetica.Location = new System.Drawing.Point(9, 53);
            this.radioButtonOrdemAlfabetica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonOrdemAlfabetica.Name = "radioButtonOrdemAlfabetica";
            this.radioButtonOrdemAlfabetica.Size = new System.Drawing.Size(106, 27);
            this.radioButtonOrdemAlfabetica.TabIndex = 1;
            this.radioButtonOrdemAlfabetica.Text = "Alfabética";
            this.radioButtonOrdemAlfabetica.UseVisualStyleBackColor = true;
            this.radioButtonOrdemAlfabetica.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonOrdemCategoria
            // 
            this.radioButtonOrdemCategoria.AutoSize = true;
            this.radioButtonOrdemCategoria.Checked = true;
            this.radioButtonOrdemCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOrdemCategoria.Location = new System.Drawing.Point(9, 25);
            this.radioButtonOrdemCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonOrdemCategoria.Name = "radioButtonOrdemCategoria";
            this.radioButtonOrdemCategoria.Size = new System.Drawing.Size(105, 27);
            this.radioButtonOrdemCategoria.TabIndex = 0;
            this.radioButtonOrdemCategoria.TabStop = true;
            this.radioButtonOrdemCategoria.Text = "Categoria";
            this.radioButtonOrdemCategoria.UseVisualStyleBackColor = true;
            this.radioButtonOrdemCategoria.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonExibirNaoSelecionados);
            this.groupBox2.Controls.Add(this.radioButtonExibirSelecionados);
            this.groupBox2.Controls.Add(this.radioButtonExibirEventuais);
            this.groupBox2.Controls.Add(this.radioButtonExibirPadrao);
            this.groupBox2.Controls.Add(this.radioButtonExibirTodos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 74);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(190, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exibir";
            // 
            // radioButtonExibirNaoSelecionados
            // 
            this.radioButtonExibirNaoSelecionados.AutoSize = true;
            this.radioButtonExibirNaoSelecionados.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExibirNaoSelecionados.Location = new System.Drawing.Point(8, 138);
            this.radioButtonExibirNaoSelecionados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonExibirNaoSelecionados.Name = "radioButtonExibirNaoSelecionados";
            this.radioButtonExibirNaoSelecionados.Size = new System.Drawing.Size(167, 27);
            this.radioButtonExibirNaoSelecionados.TabIndex = 3;
            this.radioButtonExibirNaoSelecionados.Text = "Não Selecionados";
            this.radioButtonExibirNaoSelecionados.UseVisualStyleBackColor = true;
            this.radioButtonExibirNaoSelecionados.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonExibirSelecionados
            // 
            this.radioButtonExibirSelecionados.AutoSize = true;
            this.radioButtonExibirSelecionados.Enabled = false;
            this.radioButtonExibirSelecionados.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExibirSelecionados.Location = new System.Drawing.Point(9, 110);
            this.radioButtonExibirSelecionados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonExibirSelecionados.Name = "radioButtonExibirSelecionados";
            this.radioButtonExibirSelecionados.Size = new System.Drawing.Size(130, 27);
            this.radioButtonExibirSelecionados.TabIndex = 2;
            this.radioButtonExibirSelecionados.Text = "Selecionados";
            this.radioButtonExibirSelecionados.UseVisualStyleBackColor = true;
            this.radioButtonExibirSelecionados.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonExibirEventuais
            // 
            this.radioButtonExibirEventuais.AutoSize = true;
            this.radioButtonExibirEventuais.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExibirEventuais.Location = new System.Drawing.Point(9, 81);
            this.radioButtonExibirEventuais.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonExibirEventuais.Name = "radioButtonExibirEventuais";
            this.radioButtonExibirEventuais.Size = new System.Drawing.Size(103, 27);
            this.radioButtonExibirEventuais.TabIndex = 1;
            this.radioButtonExibirEventuais.Text = "Eventuais";
            this.radioButtonExibirEventuais.UseVisualStyleBackColor = true;
            this.radioButtonExibirEventuais.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonExibirPadrao
            // 
            this.radioButtonExibirPadrao.AutoSize = true;
            this.radioButtonExibirPadrao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExibirPadrao.Location = new System.Drawing.Point(9, 53);
            this.radioButtonExibirPadrao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonExibirPadrao.Name = "radioButtonExibirPadrao";
            this.radioButtonExibirPadrao.Size = new System.Drawing.Size(84, 27);
            this.radioButtonExibirPadrao.TabIndex = 1;
            this.radioButtonExibirPadrao.Text = "Padrão";
            this.radioButtonExibirPadrao.UseVisualStyleBackColor = true;
            this.radioButtonExibirPadrao.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonExibirTodos
            // 
            this.radioButtonExibirTodos.AutoSize = true;
            this.radioButtonExibirTodos.Checked = true;
            this.radioButtonExibirTodos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExibirTodos.Location = new System.Drawing.Point(9, 25);
            this.radioButtonExibirTodos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonExibirTodos.Name = "radioButtonExibirTodos";
            this.radioButtonExibirTodos.Size = new System.Drawing.Size(75, 27);
            this.radioButtonExibirTodos.TabIndex = 0;
            this.radioButtonExibirTodos.TabStop = true;
            this.radioButtonExibirTodos.Text = "Todos";
            this.radioButtonExibirTodos.UseVisualStyleBackColor = true;
            this.radioButtonExibirTodos.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonTodos);
            this.groupBox3.Controls.Add(this.buttonNenhum);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 346);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(190, 108);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selecionar";
            // 
            // buttonTodos
            // 
            this.buttonTodos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.Location = new System.Drawing.Point(4, 30);
            this.buttonTodos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(186, 32);
            this.buttonTodos.TabIndex = 4;
            this.buttonTodos.Text = "Todos";
            this.buttonTodos.UseVisualStyleBackColor = true;
            this.buttonTodos.Click += new System.EventHandler(this.buttonSelecionar_Click);
            // 
            // buttonNenhum
            // 
            this.buttonNenhum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNenhum.Location = new System.Drawing.Point(4, 69);
            this.buttonNenhum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonNenhum.Name = "buttonNenhum";
            this.buttonNenhum.Size = new System.Drawing.Size(186, 34);
            this.buttonNenhum.TabIndex = 5;
            this.buttonNenhum.Text = "Nenhum";
            this.buttonNenhum.UseVisualStyleBackColor = true;
            this.buttonNenhum.Click += new System.EventHandler(this.buttonSelecionar_Click);
            // 
            // buttonSair
            // 
            this.buttonSair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSair.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSair.Image = global::Shopping.Properties.Resources.Log_Out_icon1;
            this.buttonSair.Location = new System.Drawing.Point(4, 496);
            this.buttonSair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(190, 49);
            this.buttonSair.TabIndex = 7;
            this.buttonSair.Text = "Sair";
            this.buttonSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(739, 543);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(739, 599);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusPadraoSel,
            this.toolStripStatusPadraoDisp,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusEventuaisSel,
            this.toolStripStatusEventuaisDisp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(739, 25);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 20);
            this.toolStripStatusLabel1.Text = "Lista Padrão";
            // 
            // toolStripStatusPadraoSel
            // 
            this.toolStripStatusPadraoSel.Name = "toolStripStatusPadraoSel";
            this.toolStripStatusPadraoSel.Size = new System.Drawing.Size(110, 20);
            this.toolStripStatusPadraoSel.Text = "selecionados: 0";
            // 
            // toolStripStatusPadraoDisp
            // 
            this.toolStripStatusPadraoDisp.Name = "toolStripStatusPadraoDisp";
            this.toolStripStatusPadraoDisp.Size = new System.Drawing.Size(98, 20);
            this.toolStripStatusPadraoDisp.Text = "disponíveis: 0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(134, 20);
            this.toolStripStatusLabel5.Text = "Produtos Eventuais";
            // 
            // toolStripStatusEventuaisSel
            // 
            this.toolStripStatusEventuaisSel.Name = "toolStripStatusEventuaisSel";
            this.toolStripStatusEventuaisSel.Size = new System.Drawing.Size(110, 20);
            this.toolStripStatusEventuaisSel.Text = "selecionados: 0";
            // 
            // toolStripStatusEventuaisDisp
            // 
            this.toolStripStatusEventuaisDisp.Name = "toolStripStatusEventuaisDisp";
            this.toolStripStatusEventuaisDisp.Size = new System.Drawing.Size(98, 20);
            this.toolStripStatusEventuaisDisp.Text = "disponíveis: 0";
            // 
            // frmProdutosPicklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 599);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmProdutosPicklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar à Lista";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProdutosPicklist_FormClosing);
            this.Load += new System.EventHandler(this.frmProdutosPicklist_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewProdutos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonOrdemAlfabetica;
        private System.Windows.Forms.RadioButton radioButtonOrdemCategoria;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonExibirEventuais;
        private System.Windows.Forms.RadioButton radioButtonExibirPadrao;
        private System.Windows.Forms.RadioButton radioButtonExibirTodos;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Button buttonNenhum;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.RadioButton radioButtonExibirSelecionados;
        private System.Windows.Forms.RadioButton radioButtonExibirNaoSelecionados;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPadraoSel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPadraoDisp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusEventuaisSel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusEventuaisDisp;
    }
}