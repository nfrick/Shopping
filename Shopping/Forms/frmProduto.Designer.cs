namespace Shopping {
    partial class frmProduto {
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
            this.propGridProduto = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // propGridProduto
            // 
            this.propGridProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGridProduto.LargeButtons = true;
            this.propGridProduto.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propGridProduto.Location = new System.Drawing.Point(0, 0);
            this.propGridProduto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.propGridProduto.Name = "propGridProduto";
            this.propGridProduto.Size = new System.Drawing.Size(736, 584);
            this.propGridProduto.TabIndex = 0;
            this.propGridProduto.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGridProduto_PropertyValueChanged);
            // 
            // frmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 584);
            this.Controls.Add(this.propGridProduto);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProduto";
            this.Text = "Produto";
            this.Load += new System.EventHandler(this.frmProduto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propGridProduto;
    }
}