using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Shopping {
    public partial class frmCategorias : Form {
        private SortableBindingList<clsCategoria> _categorias;
        private readonly List<clsCategoria> _deleted = new List<clsCategoria>();
        private BindingSource _sourceCategorias;
        public frmCategorias() {
            InitializeComponent();
        }

        #region Form
        private void frmCategorias_Load(object sender, EventArgs e) {
            LoadData();
        }
        private void frmCategorias_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !PromptSave();
        }

        private void frmCategorias_Activated(object sender, EventArgs e) {
            ((frmMain) this.MdiParent).toolStripDataBinding.Visible = true;
            ToolStripManager.Merge(this.bindingNavigatorCategorias, ((frmMain)this.MdiParent).toolStripDataBinding);
        }
        private void frmCategorias_Deactivate(object sender, EventArgs e) {
            try {
                ToolStripManager.RevertMerge(((frmMain)this.MdiParent).toolStripDataBinding);
                ((frmMain)this.MdiParent).toolStripDataBinding.Visible = false;
            }
            catch (Exception) {

                //throw;
            }
        }
        #endregion

        private void LoadData() {
            _categorias = Database.CategoriasGet();
            _sourceCategorias = new BindingSource();
            _sourceCategorias.DataSource = _categorias;
            bindingSourceCategorias.DataSource = _sourceCategorias;
        }

        private void categoriaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (!_categorias.Any() || _categorias.Count <= e.RowIndex)
                return;
            if (_categorias[e.RowIndex].Updated)
                e.CellStyle.BackColor = Color.Bisque;
        }

        private void categoriaDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            if (_categorias[e.Row.Index].Produtos == 0)
                _deleted.Add(_categorias[e.Row.Index]);
            else
                e.Cancel = true;
        }

        private void categoriaDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            _categorias[e.RowIndex].Updated = true;
            _sourceCategorias.ResetBindings(false);
            categoriaBindingNavigatorSaveItem.Enabled = true;
        }

        private void categoriaBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            SaveData();
        }

        private void SaveData() {
            var updated = _categorias.Where(m => m.Updated).ToList();
            if (!Database.CategoriasUpdate(updated, _deleted)) return;
            foreach (var cat in updated)
                cat.Updated = false;
            _deleted.Clear();
            categoriaBindingNavigatorSaveItem.Enabled = false;
            bindingSourceCategorias.ResetBindings(false);
        }

        private void categoriaDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e) {
            bindingNavigatorDeleteItem.Enabled = _categorias[e.RowIndex].Produtos == 0;
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e) {
            if (PromptSave())
                LoadData();
        }

        private bool PromptSave() {
            if (!_categorias.Any(m => m.Updated) && !_deleted.Any()) return true;
            switch (MessageBox.Show(@"Categorias foram alteradas. Salvar?", "Categorias", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    SaveData();
                    return true;
                case DialogResult.No:
                    return true;
                default:
                    return false;
            }
        }
    }
}
