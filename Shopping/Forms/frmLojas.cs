using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Shopping {
    public partial class frmLojas : Form {
        private enum DragDropSource {
            Mapas,
            ProdutosDisponiveis,
            ProdutosNoCorredor
        }

        private SortableBindingList<clsLoja> _lojas;
        private SortableBindingList<clsMapa> _mapas;
        private BindingSource _sourceLojas;
        private BindingSource _sourceMapas;
        private DragDropSource _ddSource;
        public frmLojas() {
            InitializeComponent();
        }

        #region Form
        private void frmLojas_Load(object sender, EventArgs e) {
            _lojas = Database.LojasGet();
            _sourceLojas = new BindingSource {DataSource = _lojas};
            bindingSourceLojas.DataSource = _sourceLojas;
        }

        private void frmLojas_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !PromptSave();
        }

        private bool PromptSave() {
            if (!_lojas.Any(m => m.Updated) && !_mapas.Any(m => m.Updated)) return true;
            {
                switch (MessageBox.Show(@"Salvar alterações?", @"Lojas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
                    case DialogResult.Yes:
                        Database.LojaUpdate(_lojas.Where(m => m.Updated).ToList(),
                            _mapas.Where(m => m.Updated).ToList());
                        return true;
                    case DialogResult.No:
                        return true;
                    default:
                        return false;
                }
            }
        }

        private void frmLojas_Activated(object sender, EventArgs e) {
            ((frmMain)this.MdiParent).toolStripDataBinding.Visible = true;
            ToolStripManager.Merge(this.bindingNavigatorLojas, ((frmMain)this.MdiParent).toolStripDataBinding);
        }

        private void frmLojas_Deactivate(object sender, EventArgs e) {
            try {
                ToolStripManager.RevertMerge(((frmMain)this.MdiParent).toolStripDataBinding);
                ((frmMain)this.MdiParent).toolStripDataBinding.Visible = false;
            }
            catch (Exception) {
                //throw;
            }
        }
        #endregion Form

        #region DatagridViewLojas
        private void DataGridViewLojas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (_lojas.Count == 0 || _lojas.Count <= e.RowIndex)
                return;
            if (_lojas[e.RowIndex].Updated)
                e.CellStyle.BackColor = Color.Bisque;
        }

        private void DataGridViewLojas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            e.Cancel = !LojaDelete();
        }

        private void DataGridViewLojas_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            _lojas[e.RowIndex].Updated = true;
            _sourceLojas.ResetBindings(false);
            LojaBindingNavigatorSaveItem.Enabled = true;
        }

        private void DataGridViewLojas_RowLeave(object sender, DataGridViewCellEventArgs e) {
            if (!_mapas.Any(i => i.Updated)) return;
            if (MessageBox.Show(@"Deseja salvar alterações nos Mapas?", "Lojas",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                LojaSave();
        }
        #endregion DatagridViewLojas

        #region ToolStrip
        private void LojaBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            LojaSave();
        }
        #endregion ToolStrip

        #region Database
        private void LojaSave() {
            var loja = _lojas[DataGridViewLojas.CurrentCell.RowIndex];
            var mapasUpdated = _mapas.Where(m => m.Updated).ToList();
            if (!Database.LojaUpdate(loja, mapasUpdated)) return;
            foreach (clsMapa item in mapasUpdated)
                item.Updated = false;
            bindingSourceMapas.ResetBindings(false);
            loja.Updated = false;
            bindingSourceLojas.ResetBindings(false);
            LojaBindingNavigatorSaveItem.Enabled = false;
        }

        private bool LojaDelete() {
            var row = DataGridViewLojas.CurrentCell.RowIndex;
            var deletar = true;
            if (_mapas.Any())
                deletar = MessageBox.Show($@"Loja contém {_mapas.Count} Mapas. Deletar?",
                @"Deletar Loja", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
            return deletar && Database.LojaDelete(_lojas[row].ID);
        }

        private void MapasLoad() {
            if (_lojas[0].ID == 0 || bindingSourceLojas.Position == -1)
                _mapas = new SortableBindingList<clsMapa>();
            else
                _mapas = Database.MapasGet(_lojas[bindingSourceLojas.Position].ID);
            _sourceMapas = new BindingSource {DataSource = _mapas};
            bindingSourceMapas.DataSource = _sourceMapas;
        }
        #endregion Database

        #region Binding
        private void bindingSourceLojas_PositionChanged(object sender, EventArgs e) {
            MapasLoad();
            ProdutoDisponiveisLoad();
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
            if (LojaDelete())
                bindingNavigatorLojas.BindingSource.RemoveCurrent();
        }
        #endregion Binding

        #region DataGridViewMapas
        private void DataGridViewMapas_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            _mapas[e.RowIndex].Updated = true;
            _sourceMapas.ResetBindings(false);
            LojaBindingNavigatorSaveItem.Enabled = true;
        }

        private void DataGridViewMapas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (_mapas == null || _mapas.Count == 0 || _mapas.Count <= e.RowIndex)
                return;
            if (_mapas[e.RowIndex].Updated)
                e.CellStyle.BackColor = Color.Bisque;
        }

        private void DataGridViewMapas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            e.Cancel = !Database.ItemDelete(_mapas[e.Row.Index].ID);
            if (e.Cancel)
                return;
            _mapas.RemoveAt(e.Row.Index);
            _sourceMapas.ResetBindings(false);
        }

        private void bindingSourceMapas_PositionChanged(object sender, EventArgs e) {
            ProdutoMapeadosLoad();
        }

        private void DataGridViewMapas_RowEnter(object sender, DataGridViewCellEventArgs e) {
            listViewProdutosMapeados.Columns[0].Text = @"Produtos no Corredor " +
                                                       _mapas[e.RowIndex].Corredor;
        }

        #region DragAndDrop
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        //private int rowIndexOfItemUnderMouseToDrop;

        private void DataGridViewMapas_MouseMove(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y)) {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = DataGridViewMapas.DoDragDrop(
                        DataGridViewMapas.Rows[rowIndexFromMouseDown],
                        DragDropEffects.Move);
                    _ddSource = DragDropSource.Mapas;
                }
            }
        }
        private void DataGridViewMapas_MouseDown(object sender, MouseEventArgs e) {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = DataGridViewMapas.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1) {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void DataGridViewMapas_DragOver(object sender, DragEventArgs e) {
            if (_ddSource == DragDropSource.ProdutosNoCorredor &&
                GetRowIndexOfItemUnderMouseToDrop(e) == bindingSourceMapas.Position)
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Move;
        }

        private int GetRowIndexOfItemUnderMouseToDrop(DragEventArgs e) {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = DataGridViewMapas.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            return DataGridViewMapas.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
        }
        private void DataGridViewMapas_DragDrop(object sender, DragEventArgs e) {
            int rowIndexOfItemUnderMouseToDrop = GetRowIndexOfItemUnderMouseToDrop(e);

            // If the drag operation was a move then remove and insert the row.
            //          if (e.Effect == DragDropEffects.Move) {
            if (_ddSource == DragDropSource.Mapas) {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                if (rowToMove.Index == rowIndexOfItemUnderMouseToDrop)
                    return;
                _mapas[rowToMove.Index].Updated = true;
                if (rowToMove.Index > rowIndexOfItemUnderMouseToDrop) {
                    // Moving UP
                    _mapas[rowToMove.Index].Corredor = _mapas[rowIndexOfItemUnderMouseToDrop].Corredor;
                    for (int r = rowIndexOfItemUnderMouseToDrop; r < rowToMove.Index; r++) {
                        _mapas[r].Corredor = _mapas[r].Corredor + 1;
                        _mapas[r].Updated = true;
                    }
                }
                else {
                    // Moving DOWN
                    _mapas[rowToMove.Index].Corredor = _mapas[rowIndexOfItemUnderMouseToDrop].Corredor - 1;
                    for (int r = rowToMove.Index + 1; r < rowIndexOfItemUnderMouseToDrop; r++) {
                        _mapas[r].Corredor = _mapas[r].Corredor - 1;
                        _mapas[r].Updated = true;
                    }
                }
                var SortedList = _mapas.OriginalList.OrderBy(o => o.Corredor);
                _mapas = new SortableBindingList<clsMapa>();
                foreach (clsMapa mapa in SortedList)
                    _mapas.Add(mapa);
                _sourceMapas.DataSource = _mapas;
                bindingSourceMapas.DataSource = _sourceMapas;
                LojaBindingNavigatorSaveItem.Enabled = _mapas.Any(m => m.Updated);
            }
            else {
                if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection))) {
                    foreach (ListViewItem current in (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection))) {
                        if (_ddSource == DragDropSource.ProdutosNoCorredor) {
                            if (bindingSourceMapas.Position == rowIndexOfItemUnderMouseToDrop)
                                return;
                            _mapas[bindingSourceMapas.Position].ProdutoRemove(current);
                        }
                        _mapas[rowIndexOfItemUnderMouseToDrop].ProdutoAdd(current);
                        current.Remove();
                    }
                    DataGridViewMapas.Refresh();
                    LojaBindingNavigatorSaveItem.Enabled = true;
                }
            }
        }
        #endregion DragAndDrop
        #endregion DataGridViewMapas

        #region Produtos ListViews
        public void ProdutoDisponiveisLoad() {
            if (bindingSourceLojas.Position != -1)
                PopulateListView(listViewProdutosNaoMapeados,
                    Database.ProdutosDisponiveisGet(_lojas[bindingSourceLojas.Position].ID));
        }

        private void ProdutoMapeadosLoad() {
            if (bindingSourceMapas.Position == -1)
                listViewProdutosMapeados.Items.Clear();
            else
                PopulateListView(listViewProdutosMapeados, _mapas[bindingSourceMapas.Position].Produtos);
        }

        private void PopulateListView(ListView lv, List<clsProdutoPicklist> produtos) {
            var categorias = produtos.GroupBy(
                p => p.Categoria,
                (key, g) => new { Categoria = key, Produtos = g.ToList() });


            lv.BeginUpdate();
            lv.Groups.Clear();
            lv.Items.Clear();
            foreach (var cat in categorias) {
                var lvg = lv.Groups.Add(cat.Categoria, cat.Categoria);
                foreach (var prod in cat.Produtos) {
                    var lvi = lv.Items.Add(prod.Produto);
                    lvi.Tag = prod.ID;
                    lvi.Group = lvg;
                }
            }
            lv.EndUpdate();
        }

        #region DragAndDrop
        private void listViewProdutos_ItemDrag(object sender, ItemDragEventArgs e) {
            ListView lvSource = (ListView)sender;
            if (lvSource.Name.Equals("listViewProdutosDisponiveis"))
                _ddSource = DragDropSource.ProdutosDisponiveis;
            else
                _ddSource = DragDropSource.ProdutosNoCorredor;
            //listViewProdutosDisponiveis.DoDragDrop(lvSource.SelectedItems, DragDropEffects.Move);
            lvSource.DoDragDrop(lvSource.SelectedItems, DragDropEffects.Move);
        }
        private void listViewProdutos_DragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = e.AllowedEffect;
        }
        private void listViewProdutos_DragDrop(object sender, DragEventArgs e) {
            ListView lvTarget = (ListView)sender;
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection))) {
                foreach (ListViewItem current in (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection))) {
                    string cat = current.Group.Name;
                    current.Remove();

                    ListViewGroup LVG = null;
                    foreach (ListViewGroup lvg in lvTarget.Groups) {
                        if (lvg.Name == cat) {
                            LVG = lvg;
                            break;
                        }
                    }
                    if (LVG == null)
                        LVG = lvTarget.Groups.Add(cat, cat);
                    ListViewGroup[] oGroups = new ListViewGroup[lvTarget.Groups.Count];
                    lvTarget.Groups.CopyTo(oGroups, 0);
                    lvTarget.Groups.Clear();
                    lvTarget.Groups.AddRange(oGroups.OrderBy(x => x.Name).ToArray());
                    ListViewItem lvi = lvTarget.Items.Add((ListViewItem)current);
                    lvi.Group = LVG;
                }
                lvTarget.Sort();
                _mapas[bindingSourceMapas.Position].ProdutosUpdate(listViewProdutosMapeados);
                LojaBindingNavigatorSaveItem.Enabled = true;
            }
        }
        #endregion DragAndDrop

        #endregion Produtos ListViews

    }
}