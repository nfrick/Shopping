using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Shopping {
    enum Edicao {
        Normal,
        Marcas
    }
    public partial class frmProdutos : Form {
        private ContextMenuStrip _contextMenuStripColunas;
        private SortableBindingList<clsProduto> _produtos;
        private readonly List<clsProduto> _deleted = new List<clsProduto>();
        private BindingSource _sourceProdutos;
        private readonly Dictionary<string, bool> _colunas = new Dictionary<string, bool>();

        public frmProdutos() {
            InitializeComponent();
        }

        #region Form

        private void frmProdutos_Load(object sender, EventArgs e) {
            _contextMenuStripColunas = new ContextMenuStrip();
            _contextMenuStripColunas.ItemClicked += contextMenuStripColunas_ItemClicked;

            foreach (DataGridViewColumn col in dataGridViewProdutos.Columns) {
                //_colunas.Add(col.Name, col.Visible);
                var item = (ToolStripMenuItem)_contextMenuStripColunas.Items.Add(col.HeaderText);
                item.Name = col.Name;
                item.CheckOnClick = true;
                if (col.Visible)
                    item.CheckState = CheckState.Checked;
            }
            LoadData();
        }

        private void frmProdutos_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !PromptSave();
        }

        private void frmProdutos_Activated(object sender, EventArgs e) {
            ((frmMain)MdiParent).toolStripDataBinding.Visible = true;
            ToolStripManager.Merge(bindingNavigatorProdutos, ((frmMain)MdiParent).toolStripDataBinding);
        }

        private void frmProdutos_Deactivate(object sender, EventArgs e) {
            try {
                ToolStripManager.RevertMerge(((frmMain)MdiParent).toolStripDataBinding);
                ((frmMain)MdiParent).toolStripDataBinding.Visible = false;
            }
            catch (Exception) {
                //throw;
            }
        }

        #endregion

        private void LoadData() {
            var categorias = Database.CategoriasGet();
            var sourceCategorias = new BindingSource { DataSource = categorias };

            var columnCategoria =
                (DataGridViewComboBoxColumn)dataGridViewProdutos.Columns["Categoria"];
            columnCategoria.ValueMember = "ID";
            columnCategoria.DisplayMember = "Categoria";
            columnCategoria.DataSource = sourceCategorias;

            var catList = new List<clsCategoria> { new clsCategoria("Todas") };
            catList.AddRange(categorias.ToList());
            if (toolStripComboBoxCategoria.ComboBox != null) {
                toolStripComboBoxCategoria.ComboBox.ValueMember = "ID";
                toolStripComboBoxCategoria.ComboBox.DisplayMember = "Categoria";
                toolStripComboBoxCategoria.ComboBox.DataSource = catList;
            }
            GetProducts();
        }

        private void GetProducts() {
            _produtos = Database.ProdutosGet(_colunas.Count == 0);
            _sourceProdutos = new BindingSource { DataSource = _produtos };
            bindingSourceProdutos.DataSource = _sourceProdutos;
        }

        private void produtoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (!_produtos.Any() || _produtos.Count <= e.RowIndex)
                return;
            if (_produtos[e.RowIndex].Updated)
                e.CellStyle.BackColor = Color.Bisque;
        }

        private void produtoDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            if (_produtos[e.Row.Index].Ocorrencias == 0)
                _deleted.Add(_produtos[e.Row.Index]);
            else
                e.Cancel = true;
        }

        private void produtoDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e) {
            bindingNavigatorDeleteItem.Enabled = _produtos[e.RowIndex].Ocorrencias == 0;
        }

        private void produtoDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            var column = dataGridViewProdutos.Columns[e.ColumnIndex];
            var cell = dataGridViewProdutos.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (!string.IsNullOrEmpty(cell.Value?.ToString())) {
                if (column.Name.Equals("Produto") || column.Name.Equals("Unidade")) {
                    cell.Value = cell.Value.ToString().Trim();
                }
                else if (column.Name.StartsWith("Marcas")) {
                    char[] seps = { ',', ';' };
                    var marcas = cell.Value.ToString().Split(seps);
                    for (var i = 0; i < marcas.Count(); i++)
                        marcas[i] = marcas[i].Trim();
                    cell.Value = string.Join(", ", marcas);
                }
            }
            _produtos[e.RowIndex].Updated = true;
            _sourceProdutos.ResetBindings(false);
            produtoBindingNavigatorSaveItem.Enabled = true;
        }

        private void produtoBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            SaveData();
        }

        private void SaveData() {
            var updated = _produtos.Where(m => m.Updated).ToList();
            if (!Database.ProdutosUpdate(updated, _deleted)) return;
            foreach (var prod in updated)
                prod.Updated = false;
            _deleted.Clear();
            produtoBindingNavigatorSaveItem.Enabled = false;
            bindingSourceProdutos.ResetBindings(false);
            foreach (var frm in this.ParentForm.MdiChildren) {
                if (frm is frmLojas)
                    ((frmLojas)frm).ProdutoDisponiveisLoad();
                else if (frm is frmListas)
                    ((frmListas)frm).ItensLoad();
            }
        }

        private void dataGridViewProdutos_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e) {
            var col = dataGridViewProdutos.CurrentCell.ColumnIndex;
            if (col == 0) return;
            var txt = e.Control as TextBox;
            if (dataGridViewProdutos.Columns[col].Name != "Unidade") return;
            var unidades = _produtos.Where(p => !string.IsNullOrEmpty(p.Unidade))
                .Select(p => p.Unidade).Distinct().OrderBy(u => u);
            txt.AutoCompleteCustomSource.AddRange(unidades.ToArray());
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void toolStripComboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e) {
            if (toolStripComboBoxCategoria.Text == @"Todas")
                bindingSourceProdutos.Filter = "";
            else {
                var cat = (clsCategoria)toolStripComboBoxCategoria.SelectedItem;
                bindingSourceProdutos.Filter = $"CategoriaID = {cat.ID}";
            }
            dataGridViewProdutos.Focus();
        }

        private void dataGridViewProdutos_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            MessageBox.Show($@"Linha {e.RowIndex}\nColuna {e.ColumnIndex}\nMensagem: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e) {
            if (PromptSave())
                LoadData();
        }

        private void contextMenuStripColunas_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            var item = (ToolStripMenuItem)e.ClickedItem;
            dataGridViewProdutos.Columns[item.Name].Visible = !item.Checked;
            SetFormWidth();
        }

        private void SetFormWidth() {
            var width = dataGridViewProdutos.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            ParentForm.ClientSize = new Size(0 + width, ParentForm.ClientSize.Height);
        }

        private void dataGridViewProdutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                _contextMenuStripColunas.Show(Cursor.Position);
            }
        }

        private bool PromptSave() {
            if (!_produtos.Any(m => m.Updated) && !_deleted.Any()) return true;
            switch (
                MessageBox.Show(@"Produtos foram alterados. Salvar?", @"Produtos", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    SaveData();
                    return true;
                case DialogResult.No:
                    return true;
                default:
                    return false;
            }
        }

        private void dataGridViewProdutos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            var column = dataGridViewProdutos.Columns[e.ColumnIndex];
            switch (column.Name) {
                case "Produto":
                    ValidateProduto(e);
                    break;
                case "Unidade":
                    ValidateUnidade(e);
                    break;
                case "QtdNormal":
                    ValidateQuantidade(e);
                    break;
                default:
                    e.Cancel = false;
                    break;
            }
        }

        private void ValidateProduto(DataGridViewCellValidatingEventArgs e) {
            var text = e.FormattedValue.ToString().Trim();
            if (string.IsNullOrEmpty(text)) {
                NotifyUserAndForceRedo(@"Informe o nome do produto!", e);
            }
            if (_produtos.Any(p => p.Produto.Equals(text) && p.ID != _produtos[e.RowIndex].ID)) {
                NotifyUserAndForceRedo($@"Produto '{text}' já está cadastrado!", e);
            }
        }

        private void ValidateUnidade(DataGridViewCellValidatingEventArgs e) {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString())) {
                NotifyUserAndForceRedo(@"Informe a unidade!", e);
            }
        }

        private void ValidateQuantidade(DataGridViewCellValidatingEventArgs e) {
            decimal value;
            var text = e.FormattedValue.ToString();
            var unidade = (string)dataGridViewProdutos.Rows[e.RowIndex].Cells["Unidade"].Value;
            if (string.IsNullOrEmpty(text))
                NotifyUserAndForceRedo(@"Informe a Quantidade Normal!", e);
            else if (!decimal.TryParse(text, out value))
                NotifyUserAndForceRedo($@"Quantidade Normal '{text}' não é um número válido!", e);
            else if (value == 0)
                AnnotateCell(@"Quantidade deve ser maior que zero!", e);
            else if (unidade.Equals("un") && value % 1 != 0) {
                NotifyUserAndForceRedo(@"Se Unidade for 'un', Quantidade Normal precisa ser número inteiro!", e);
            }
        }

        private static void NotifyUserAndForceRedo(string errorMessage, DataGridViewCellValidatingEventArgs newValue) {
            MessageBox.Show(errorMessage, @"Produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            newValue.Cancel = true;
        }

        private void AnnotateCell(string errorMessage, DataGridViewCellValidatingEventArgs editEvent) {
            var cell = dataGridViewProdutos.Rows[editEvent.RowIndex].Cells[editEvent.ColumnIndex];
            cell.ErrorText = errorMessage;
        }

        private void dataGridViewProdutos_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            // Clear the row error in case the user presses ESC.   
            dataGridViewProdutos.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dataGridViewProdutos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            var column = dataGridViewProdutos.Columns[e.ColumnIndex];
            if (column.Name != "QtdNormal" || !string.IsNullOrEmpty(
                dataGridViewProdutos.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString())) return;
            MessageBox.Show(@"Informe a Unidade antes de informar a Quantidade Normal!", @"Produtos", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
            dataGridViewProdutos.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Selected = true;
        }

        private void toolStripButtonCompras_Click(object sender, EventArgs e) {
            var frm = new frmProdutoGrafico {
                Produto = _produtos[dataGridViewProdutos.CurrentCell.RowIndex],
                MdiParent = MdiParent
            };
            frm.Show();
        }

        private void toolStripButtonQtdFilter_Click(object sender, EventArgs e) {
            bindingSourceProdutos.Filter = @"QtdDif = true";
        }

        private void toolStripButtonMarcas_Click(object sender, EventArgs e) {
            if (Edicao == Edicao.Normal) {
                toolStripButtonMarcas.Text = @"Modo edição normal (todas as colunas)";
                foreach (DataGridViewColumn col in dataGridViewProdutos.Columns) {
                    _colunas.Add(col.Name, col.Visible);
                    col.Visible = col.DataPropertyName == "Produto" ||
                                  col.DataPropertyName == "MarcasSim" ||
                                  col.DataPropertyName == "MarcasCompradas";

                }
            }
            else {
                toolStripButtonMarcas.Text = @"Modo edição de 'Marcas Sim'";
                foreach (DataGridViewColumn col in dataGridViewProdutos.Columns) {
                    col.Visible = _colunas[col.Name];
                }
                _colunas.Clear();
            }
            GetProducts();
        }

        private void dataGridViewProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            Form frm;
            if (Edicao == Edicao.Marcas) {
                frm = new frmMarcas {
                    Produto = _produtos[dataGridViewProdutos.CurrentCell.RowIndex]
                };
            }
            else {
                frm = new frmProduto {
                    Produto = _produtos[dataGridViewProdutos.CurrentCell.RowIndex]
                };
            }
            frm.ShowDialog();
            dataGridViewProdutos.Refresh();
            produtoBindingNavigatorSaveItem.Enabled = _produtos.OriginalList.Any(p => p.Updated);
        }

        private Edicao Edicao => _colunas.Count == 0 ? Edicao.Normal : Edicao.Marcas;
    }
}
