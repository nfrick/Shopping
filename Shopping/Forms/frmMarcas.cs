using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;


namespace Shopping {
    public partial class frmMarcas : Form {
        public clsProduto Produto { get; set; }

        public frmMarcas() {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e) {
            labelProduto.Text = Produto.Produto;
            PopulateLists();
        }

        private void PopulateLists() {
            listViewMarcasSim.Items.Clear();
            listViewMarcasCompradas.Items.Clear();
            var marcasSim = Produto.MarcasSim.Split(',').Select(marca => marca.Trim()).ToArray();
            var marcasCompradas = Produto.MarcasCompradas.Split(',').Select(marca => marca.Trim()).ToArray();
            foreach (var m in marcasCompradas.Where(m => !marcasSim.Contains(m))) {
                listViewMarcasCompradas.Items.Add(m);
            }
            foreach (var m in marcasSim.Where((m => m != string.Empty))) {
                listViewMarcasSim.Items.Add(m);
            }
        }

        #region DragAndDrop
        private void listView_ItemDrag(object sender, ItemDragEventArgs e) {
            var lvSource = (ListView)sender;
            lvSource.DoDragDrop(lvSource.SelectedItems, DragDropEffects.Move);
        }
        private void listView_DragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = e.AllowedEffect;
        }
        private void listView_DragDrop(object sender, DragEventArgs e) {
            var lvTarget = (ListView)sender;
            if (!e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection))) return;
            foreach (ListViewItem current in (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection))) {
                current.Remove();
                var lvi = lvTarget.Items.Add((ListViewItem)current);
            }
            lvTarget.Sort();
        }
        #endregion DragAndDrop

        private void buttonReset_Click(object sender, EventArgs e) {
            PopulateLists();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            Produto.MarcasSim = NewMarcasSim();
            Produto.Updated = true;
            this.Close();
        }

        private string NewMarcasSim() {
            var myArray = (from ListViewItem marca in listViewMarcasSim.Items select marca.Text).ToArray();
            return string.Join(", ", myArray);
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmMarcas_FormClosing(object sender, FormClosingEventArgs e) {
            var ms = NewMarcasSim();
            if (ms == Produto.MarcasSim)
                return;
            switch (
                MessageBox.Show(@"Salvar alterações?", @"Marcas",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    Produto.MarcasSim = ms;
                    Produto.Updated = true;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void listViewMarcas_MouseDoubleClick(object sender, MouseEventArgs e) {
            var lvSource = sender as ListView;
            if (lvSource == null) return;
            var item = lvSource.FocusedItem;
            var lvDestination = lvSource.Name.Contains("Sim") ? listViewMarcasCompradas : listViewMarcasSim;
            lvSource.Items.Remove(item);
            lvDestination.Items.Add(item);
        }
    }
}
