namespace Shopping {
    partial class frmMain {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLojas = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCategorias = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProdutos = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonListas = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonJanelas = new System.Windows.Forms.ToolStripDropDownButton();
            this.fecharTodasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMinimizar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFechar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemArrumar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDataBinding = new System.Windows.Forms.ToolStrip();
            this.toolStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLojas,
            this.toolStripButtonCategorias,
            this.toolStripButtonProdutos,
            this.toolStripButtonListas,
            this.toolStripButtonConfig,
            this.toolStripDropDownButtonJanelas});
            this.toolStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Size = new System.Drawing.Size(1150, 59);
            this.toolStripMainMenu.TabIndex = 1;
            this.toolStripMainMenu.Text = "toolStrip1";
            // 
            // toolStripButtonLojas
            // 
            this.toolStripButtonLojas.Image = global::Shopping.Properties.Resources.shop_icon32;
            this.toolStripButtonLojas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLojas.Name = "toolStripButtonLojas";
            this.toolStripButtonLojas.Size = new System.Drawing.Size(47, 56);
            this.toolStripButtonLojas.Text = "Lojas";
            this.toolStripButtonLojas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonLojas.Click += new System.EventHandler(this.toolStripButtonLojas_Click);
            // 
            // toolStripButtonCategorias
            // 
            this.toolStripButtonCategorias.Image = global::Shopping.Properties.Resources.organization_icon32;
            this.toolStripButtonCategorias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCategorias.Name = "toolStripButtonCategorias";
            this.toolStripButtonCategorias.Size = new System.Drawing.Size(84, 56);
            this.toolStripButtonCategorias.Text = "Categorias";
            this.toolStripButtonCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCategorias.Click += new System.EventHandler(this.toolStripButtonCategorias_Click);
            // 
            // toolStripButtonProdutos
            // 
            this.toolStripButtonProdutos.Image = global::Shopping.Properties.Resources.flour_icon32;
            this.toolStripButtonProdutos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProdutos.Name = "toolStripButtonProdutos";
            this.toolStripButtonProdutos.Size = new System.Drawing.Size(72, 56);
            this.toolStripButtonProdutos.Text = "Produtos";
            this.toolStripButtonProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonProdutos.Click += new System.EventHandler(this.toolStripButtonProdutos_Click);
            // 
            // toolStripButtonListas
            // 
            this.toolStripButtonListas.Image = global::Shopping.Properties.Resources.mail_mark_task;
            this.toolStripButtonListas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonListas.Name = "toolStripButtonListas";
            this.toolStripButtonListas.Size = new System.Drawing.Size(49, 56);
            this.toolStripButtonListas.Text = "Listas";
            this.toolStripButtonListas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonListas.Click += new System.EventHandler(this.toolStripButtonListas_Click);
            // 
            // toolStripButtonConfig
            // 
            this.toolStripButtonConfig.Image = global::Shopping.Properties.Resources.Document_config_icon;
            this.toolStripButtonConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConfig.Name = "toolStripButtonConfig";
            this.toolStripButtonConfig.Size = new System.Drawing.Size(102, 56);
            this.toolStripButtonConfig.Text = "Configuração";
            this.toolStripButtonConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonConfig.Click += new System.EventHandler(this.toolStripButtonConfig_Click);
            // 
            // toolStripDropDownButtonJanelas
            // 
            this.toolStripDropDownButtonJanelas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fecharTodasToolStripMenuItem,
            this.ToolStripMenuItemArrumar,
            this.ToolStripMenuItemVertical,
            this.ToolStripMenuItemHorizontal});
            this.toolStripDropDownButtonJanelas.Image = global::Shopping.Properties.Resources.window_duplicate;
            this.toolStripDropDownButtonJanelas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonJanelas.Name = "toolStripDropDownButtonJanelas";
            this.toolStripDropDownButtonJanelas.Size = new System.Drawing.Size(70, 56);
            this.toolStripDropDownButtonJanelas.Text = "Janelas";
            this.toolStripDropDownButtonJanelas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // fecharTodasToolStripMenuItem
            // 
            this.fecharTodasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMinimizar,
            this.ToolStripMenuItemFechar});
            this.fecharTodasToolStripMenuItem.Name = "fecharTodasToolStripMenuItem";
            this.fecharTodasToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.fecharTodasToolStripMenuItem.Text = "Todas";
            // 
            // ToolStripMenuItemMinimizar
            // 
            this.ToolStripMenuItemMinimizar.Name = "ToolStripMenuItemMinimizar";
            this.ToolStripMenuItemMinimizar.Size = new System.Drawing.Size(150, 26);
            this.ToolStripMenuItemMinimizar.Text = "Minimizar";
            this.ToolStripMenuItemMinimizar.Click += new System.EventHandler(this.ToolStripMenuItemMinimizar_Click);
            // 
            // ToolStripMenuItemFechar
            // 
            this.ToolStripMenuItemFechar.Name = "ToolStripMenuItemFechar";
            this.ToolStripMenuItemFechar.Size = new System.Drawing.Size(150, 26);
            this.ToolStripMenuItemFechar.Text = "Fechar";
            this.ToolStripMenuItemFechar.Click += new System.EventHandler(this.ToolStripMenuItemFechar_Click);
            // 
            // ToolStripMenuItemArrumar
            // 
            this.ToolStripMenuItemArrumar.Name = "ToolStripMenuItemArrumar";
            this.ToolStripMenuItemArrumar.Size = new System.Drawing.Size(154, 26);
            this.ToolStripMenuItemArrumar.Text = "Arrumar";
            this.ToolStripMenuItemArrumar.Click += new System.EventHandler(this.ToolStripMenuItemArrumar_Click);
            // 
            // ToolStripMenuItemVertical
            // 
            this.ToolStripMenuItemVertical.Name = "ToolStripMenuItemVertical";
            this.ToolStripMenuItemVertical.Size = new System.Drawing.Size(154, 26);
            this.ToolStripMenuItemVertical.Text = "Vertical";
            this.ToolStripMenuItemVertical.Click += new System.EventHandler(this.ToolStripMenuItemVertical_Click);
            // 
            // ToolStripMenuItemHorizontal
            // 
            this.ToolStripMenuItemHorizontal.Name = "ToolStripMenuItemHorizontal";
            this.ToolStripMenuItemHorizontal.Size = new System.Drawing.Size(154, 26);
            this.ToolStripMenuItemHorizontal.Text = "Horizontal";
            this.ToolStripMenuItemHorizontal.Click += new System.EventHandler(this.ToolStripMenuItemHorizontal_Click);
            // 
            // toolStripDataBinding
            // 
            this.toolStripDataBinding.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripDataBinding.Location = new System.Drawing.Point(0, 54);
            this.toolStripDataBinding.Name = "toolStripDataBinding";
            this.toolStripDataBinding.Size = new System.Drawing.Size(1150, 25);
            this.toolStripDataBinding.TabIndex = 3;
            this.toolStripDataBinding.Text = "toolStrip2";
            this.toolStripDataBinding.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 729);
            this.Controls.Add(this.toolStripDataBinding);
            this.Controls.Add(this.toolStripMainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "Shopping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButtonCategorias;
        private System.Windows.Forms.ToolStripButton toolStripButtonProdutos;
        private System.Windows.Forms.ToolStripButton toolStripButtonListas;
        private System.Windows.Forms.ToolStripButton toolStripButtonLojas;
        protected internal System.Windows.Forms.ToolStrip toolStripDataBinding;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonJanelas;
        private System.Windows.Forms.ToolStripMenuItem fecharTodasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMinimizar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFechar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemArrumar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemVertical;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHorizontal;
        private System.Windows.Forms.ToolStripButton toolStripButtonConfig;
    }
}

