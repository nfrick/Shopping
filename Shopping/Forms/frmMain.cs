using System;
using System.Windows.Forms;

namespace Shopping {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        private void toolStripButtonCategorias_Click(object sender, EventArgs e) {
            var frm = new frmCategorias {MdiParent = this};
            frm.Show();
        }

        private void toolStripButtonProdutos_Click(object sender, EventArgs e) {
            var result = Database.HasRecords();
            if ((result & 1) > 0) {
                var frm = new frmProdutos {MdiParent = this};
                frm.Show();
            }
            else
                MessageBox.Show(@"Antes de cadastrar Produtos é necessário cadastrar Categorias.", @"Shopping", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonListas_Click(object sender, EventArgs e) {
            var result = Database.HasRecords();
            if (((result & 2) > 0) && ((result & 4) > 0)) {
                var frm = new frmListas {MdiParent = this};
                frm.Show();
            }
            else
                MessageBox.Show(@"Antes de criar Listas é necessário cadastrar Lojas e Produtos.", @"Shopping", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonLojas_Click(object sender, EventArgs e) {
            var frm = new frmLojas {MdiParent = this};
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (var frm in this.MdiChildren) {
                frm.Close();
            }
        }

        private void ToolStripMenuItemMinimizar_Click(object sender, EventArgs e) {
            foreach (var frm in this.MdiChildren) {
                frm.WindowState = FormWindowState.Minimized;
            }
        }

        private void ToolStripMenuItemFechar_Click(object sender, EventArgs e) {
            foreach (var frm in this.MdiChildren) {
                frm.Close();
            }
        }

        private void ToolStripMenuItemArrumar_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void ToolStripMenuItemVertical_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void ToolStripMenuItemHorizontal_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void toolStripButtonConfig_Click(object sender, EventArgs e) {
            var frm = new frmConfig { MdiParent = this };
            frm.Show();
        }
    }
}
