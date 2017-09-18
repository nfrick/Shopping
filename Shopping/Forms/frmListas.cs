using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Shopping {
    public partial class frmListas : Form {
        private enum Colunas {
            Corredor,
            Produto,
            Categoria,
            Unidade,
            QtdNormal,
            QtdPrevista,
            QtdReal,
            Marca,
            Preco,
            SubTotal,
            Porcentagem
        }

        private SortableBindingList<clsLista> _listas;
        private SortableBindingList<clsItem> _itens;
        private BindingSource _sourceListas;
        private BindingSource _sourceItens;
        private decimal? _total;
        public frmListas() {
            InitializeComponent();
        }

        #region Form
        private void frmListas_Load(object sender, EventArgs e) {
            var Lojas = Database.LojasGet();
            var sourceLojas = new BindingSource { DataSource = Lojas };

            DataGridViewComboBoxColumn columnLoja = (DataGridViewComboBoxColumn)this.DataGridViewListas.Columns["LojaID"];
            columnLoja.ValueMember = "ID";
            columnLoja.DisplayMember = "Loja";
            columnLoja.DataSource = sourceLojas;

            _listas = Database.ListasGet();
            _sourceListas = new BindingSource { DataSource = _listas };
            bindingSourceListas.DataSource = _sourceListas;
        }

        private void SetTotals() {
            _total = _itens.Where(i => i.SubTotal != null).Sum(i => i.SubTotal);
            var previsto = _itens.Where(i => i.PrecoUlt != null).Sum(i => i.PrecoUlt * i.QtdPrevista);
            toolStripStatusLabelItens.Text = $@"Itens: {_itens.Count()}";
            toolStripStatusTotalPrevisto.Text = $@"Total Previsto: {previsto:C2}";
            toolStripStatusLabelTotalReal.Text = $@"Total Real: {_total:C2}";
        }

        private void frmListas_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !PromptSave();
            DataGridViewItens.DataSource = null;
        }

        private bool PromptSave() {
            if (!_listas.Any(m => m.Updated) && !_itens.Any(m => m.Updated)) return true;
            switch (MessageBox.Show(@"Salvar alterações?", @"Listas de Compras", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    Database.ListaUpdate(_listas.Where(m => m.Updated).ToList(),
                        _itens.Where(m => m.Updated).ToList());
                    return true;
                case DialogResult.No:
                    return true;
                default:
                    return false;
            }
        }

        private void frmListas_Activated(object sender, EventArgs e) {
            ((frmMain)this.MdiParent).toolStripDataBinding.Visible = true;
            ToolStripManager.Merge(this.BindingNavigatorListas, ((frmMain)this.MdiParent).toolStripDataBinding);
        }

        private void frmListas_Deactivate(object sender, EventArgs e) {
            try {
                ToolStripManager.RevertMerge(((frmMain)this.MdiParent).toolStripDataBinding);
                ((frmMain)this.MdiParent).toolStripDataBinding.Visible = false;
            }
            catch (Exception) {

                //throw;
            }
        }
        #endregion Form

        #region DatagridViewListas
        private void listaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (_listas.Count == 0 || _listas.Count <= e.RowIndex)
                return;
            if (_listas[e.RowIndex].Updated)
                e.CellStyle.BackColor = Color.Bisque;
        }

        private void listaDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            e.Cancel = !ListaDelete();
        }

        private void listaDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            _listas[e.RowIndex].Updated = true;
            _sourceListas.ResetBindings(false);
            listaBindingNavigatorSaveItem.Enabled = true;
        }

        private void listaDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e) {
            if (!_itens.Where(i => i.Updated).Any()) return;
            if (MessageBox.Show(@"Deseja salvar alterações nos itens?", @"Lista de Compras",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ListaSave();
        }
        #endregion

        #region ToolStrip
        private void listaBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            ListaSave();
        }

        private void toolStripButtonItensAdd_Click(object sender, EventArgs e) {
            ListaSave();
            var frm = new frmProdutosPicklist {ListaID = _listas[DataGridViewListas.CurrentCell.RowIndex].ID};
            frm.ShowDialog();
            ItensLoad();
        }

        private void toolStripButtonReplace_Click(object sender, EventArgs e) {
            if (DataGridViewItens.SelectedRows.Count != 1) {
                MessageBox.Show(@"Selecione o item a ser substituído.", @"Substituir item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ListaSave();
            var frm =
                new frmProdutosPicklist {
                    ListaID = _listas[DataGridViewListas.CurrentCell.RowIndex].ID,
                    Mode = PicklistMode.Replace,
                    Target = _itens[DataGridViewItens.CurrentCell.RowIndex]
                };
            frm.ShowDialog();
            ItensLoad();
        }

        private void toolStripButtonItensDel_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in DataGridViewItens.SelectedRows) {
                if (Database.ItemDelete(_itens[row.Index].ID))
                    _itens.RemoveAt(row.Index);
            }
            _sourceItens.ResetBindings(false);
            SetTotals();
        }

        private void toolStripButtonCalculadora_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void ToolStripMenuItemImportar_Click(object sender, EventArgs e) {
            openFileDialog1.AddExtension = true;
            openFileDialog1.DefaultExt = "*.xml";
            openFileDialog1.Filter = @"Arquivo XML (*.xml)|*.xml";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Title = @"Lista para Importação";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            var xmlFile = new FileInfo(openFileDialog1.FileName);
            if (!xmlFile.Exists) return;

            var writer = new XmlSerializer(typeof(List<clsItem>));
            using (var file = xmlFile.OpenRead()) {
                var updatedItems = (List<clsItem>)writer.Deserialize(file);
                var listAandB = _itens.OriginalList.Zip(updatedItems, (a, b) => new { a, b });
                foreach (var item in listAandB) {
                    if (item.a.ID != item.b.ID || item.a.Updated || !item.b.Updated) continue;
                    item.a.QtdReal = item.b.QtdReal;
                    item.a.Preco = item.b.Preco;
                    item.a.Marca = item.b.Marca;
                    item.a.CorredorNum = item.b.CorredorNum;
                    item.a.Updated = true;
                }
            }
            if (_itens.Any(i => i.Updated)) {
                listaBindingNavigatorSaveItem.Enabled = true;
                _listas[DataGridViewListas.CurrentCell.RowIndex].Updated = true;
                bindingSourceItens.ResetBindings(false);
                bindingSourceListas.ResetBindings(true);
            }
            MessageBox.Show(@"Lista importada de " + xmlFile.FullName, @"Listas de Compras",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Database
        private void ListaSave() {
            var lista = _listas[DataGridViewListas.CurrentCell.RowIndex];
            var itensUpdated = _itens.Where(m => m.Updated).ToList();
            if (!Database.ListaUpdate(lista, itensUpdated)) return;
            foreach (var item in itensUpdated)
                item.Updated = false;
            bindingSourceItens.ResetBindings(false);
            lista.Updated = false;
            bindingSourceListas.ResetBindings(false);
            listaBindingNavigatorSaveItem.Enabled = false;
        }

        private bool ListaDelete() {
            var row = DataGridViewListas.CurrentCell.RowIndex;
            var deletar = true;
            if (_itens.Any())
                deletar = MessageBox.Show($@"Lista contém {_itens.Count} itens. Deletar?",
                @"Deletar Lista", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
            return deletar && Database.ListaDelete(_listas[row].ID);
        }

        public void ItensLoad() {
            _itens = bindingSourceListas.Position == -1 ? new SortableBindingList<clsItem>() : Database.ItensGet(_listas[bindingSourceListas.Position].ID);
            _sourceItens = new BindingSource {DataSource = _itens};
            bindingSourceItens.DataSource = _sourceItens;
            SetTotals();
        }
        #endregion

        #region Binding
        private void bindingSourceListas_PositionChanged(object sender, EventArgs e) {
            ItensLoad();
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
            if (ListaDelete())
                BindingNavigatorListas.BindingSource.RemoveCurrent();
        }
        #endregion

        #region DataGridViewItem
        private void DataGridViewItens_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1) return;
            _itens[e.RowIndex].Updated = true;
            _sourceItens.ResetBindings(false);
            listaBindingNavigatorSaveItem.Enabled = true;
            SetTotals();
        }

        private void DataGridViewItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (_itens.Count == 0 || _itens.Count <= e.RowIndex)
                return;
            if (_itens[e.RowIndex].Updated)
                e.CellStyle.BackColor = Color.Bisque;
            if (e.ColumnIndex == (int)Colunas.QtdPrevista &&
                _itens[e.RowIndex].QtdNormal != null &&
                _itens[e.RowIndex].QtdPrevista != null &&
                _itens[e.RowIndex].QtdNormal != _itens[e.RowIndex].QtdPrevista) {
                var font = new Font(e.CellStyle.Font, FontStyle.Bold);
                e.CellStyle.Font = font;
                e.CellStyle.ForeColor = _itens[e.RowIndex].QtdNormal > _itens[e.RowIndex].QtdPrevista ? 
                    Color.DarkRed : Color.DarkGreen;
            }
            if (e.ColumnIndex == (int)Colunas.QtdReal &&
                _itens[e.RowIndex].QtdPrevista != null &&
                _itens[e.RowIndex].QtdReal != null &&
                _itens[e.RowIndex].QtdReal != _itens[e.RowIndex].QtdPrevista) {
                var font = new Font(e.CellStyle.Font, FontStyle.Bold);
                e.CellStyle.Font = font;
                e.CellStyle.ForeColor = _itens[e.RowIndex].QtdPrevista > _itens[e.RowIndex].QtdReal ? 
                    Color.DarkRed : Color.DarkGreen;
            }
            if (e.ColumnIndex != (int) Colunas.Porcentagem) return;
            e.FormattingApplied = true;
            e.Value = $"{_itens[e.RowIndex].SubTotal / _total:P1}";
        }

        private void DataGridViewItens_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            e.Cancel = !Database.ItemDelete(_itens[e.Row.Index].ID);
            if (e.Cancel)
                return;
            _itens.RemoveAt(e.Row.Index);
            _sourceItens.ResetBindings(false);
            SetTotals();
        }

        private void DataGridViewItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            var item = _itens[e.RowIndex];
            switch (e.ColumnIndex) {
                case (int)Colunas.QtdPrevista:
                    if (item.QtdNormal != null && item.QtdPrevista != item.QtdNormal) {
                        item.QtdPrevista = item.QtdNormal;
                        item.Updated = true;
                    }
                    break;
                case (int)Colunas.QtdReal:
                    if (item.QtdPrevista != null && item.QtdReal != item.QtdPrevista) {
                        item.QtdReal = item.QtdPrevista;
                        item.Updated = true;
                        SetTotals();
                    }
                    break;
                default:
                    break;
            }
            if (!item.Updated) return;
            _sourceItens.ResetBindings(false);
            listaBindingNavigatorSaveItem.Enabled = true;
        }

        private void DataGridViewItens_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            var col = DataGridViewItens.CurrentCell.ColumnIndex;
            var row = DataGridViewItens.CurrentCell.RowIndex;
            var item = _itens[row];
            var txt = e.Control as TextBox;
            if (col == (int)Colunas.Marca && item.MarcasSim != "") {
                string[] sep = { ", ", ",", "; ", ";" };
                var marcas = item.MarcasSim.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                var source = new AutoCompleteStringCollection();
                source.AddRange(marcas);
                txt.AutoCompleteCustomSource = source;
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else {
                txt.AutoCompleteMode = AutoCompleteMode.None;
            }
        }
        #endregion

        #region Export
        private FileInfo ExportFile(string title, string defaultExt, string filter) {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = defaultExt;
            saveFileDialog1.Filter = filter;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Title = title;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return null;
            var newFile = new FileInfo(saveFileDialog1.FileName);
            if (!newFile.Exists) return newFile;
            newFile.Delete();  // ensures we create a new workbook
            newFile = new FileInfo(saveFileDialog1.FileName);
            return newFile;
        }

        private void ToolStripMenuItemExportExcel_Click(object sender, EventArgs e) {
            var newFile = ExportFile(@"Lista para Excel", "xlsx", "Arquivo Excel (*.xlsx)|*.xlsx");
            if (newFile == null)
                return;

            var frm = new frmExport {Classe = "Lista"};
            //frm.MdiParent = this.MdiParent;
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;


            using (var package = new ExcelPackage(newFile)) {
                // add a new worksheet to the empty workbook
                var worksheet = package.Workbook.Worksheets.Add("Lista");

                var row = 0;
                if (frm.Cabecalhos) {
                    var col = 1; row++;
                    foreach (var kvp in frm.CamposSelecionados) {
                        if (!kvp.Value || (!frm.FlatTable && kvp.Key == "Produto")) continue;
                        worksheet.Cells[row, col++].Value = kvp.Key;
                    }
                }
                if (frm.FlatTable) {
                    ItensToWorksheet(worksheet,
                            _itens.OrderBy(i => i.Produto).ToList(), frm, row);
                }
                else {
                    var categorias = _itens.Select(i => i.Categoria).Distinct().OrderBy(c => c);
                    foreach (var cat in categorias) {
                        //row++;
                        worksheet.Cells[++row, 1].Value = cat;
                        using (var range = worksheet.Cells[row, 1]) {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.LightCyan);
                            range.Style.Font.Color.SetColor(Color.Black);
                        }
                        row = ItensToWorksheet(worksheet,
                            _itens.Where(i => i.Categoria == cat).OrderBy(i => i.Produto).ToList(),
                            frm, row);
                    }
                }
                worksheet.Cells.AutoFitColumns(0);us  //Autofit columns for all cells

                // lets set the header text 
                worksheet.HeaderFooter.OddHeader.CenteredText = "&16&\"Segoe UI,Regular Bold\" Lista de Compras";
                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText =
                    $"Página {ExcelHeaderFooter.PageNumber} de {ExcelHeaderFooter.NumberOfPages}";
                // add the sheet name to the footer
                worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;
                // add the file path to the footer
                worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;

                //worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:2"];
                //worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:G"];

                // Change the sheet view to show it in page layout mode
                //worksheet.View.PageLayoutView = true;

                // set some document properties
                package.Workbook.Properties.Title = "Lista de Compras";
                package.Workbook.Properties.Author = "Nelson Frick";
                package.Workbook.Properties.Comments = "";

                // set some extended property values
                package.Workbook.Properties.Company = "Tyger Systems";

                // set some custom property values
                package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Nelson Frick");
                package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");
                // save our new workbook and we are done!
                package.Save();
            }
        }

        private int ItensToWorksheet(ExcelWorksheet worksheet, 
            IEnumerable<clsItem> itens2Export, frmExport frm, int row) {
            foreach (var item in itens2Export) {
                var col = 1; row++;
                if (frm.FlatTable && frm.CamposSelecionados["Categoria"])
                    worksheet.Cells[row, col++].Value = item.Categoria;
                if (frm.CamposSelecionados["Produto"])
                    worksheet.Cells[row, col++].Value = item.Produto;
                if (frm.CamposSelecionados["Nº Corredor"])
                    worksheet.Cells[row, col++].Value = item.CorredorNum;
                if (frm.CamposSelecionados["Corredor"])
                    worksheet.Cells[row, col++].Value = item.CorredorDescricao;
                if (frm.CamposSelecionados["Qtd Prevista"]) {
                    worksheet.Cells[row, col].Value = item.QtdPrevista;
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#0.000";
                }
                if (frm.CamposSelecionados["Unidade"])
                    worksheet.Cells[row, col++].Value = item.Unidade;
                if (frm.CamposSelecionados["Último Preço"]) {
                    worksheet.Cells[row, col].Value = item.PrecoUlt;
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "R$ #,##0.00";
                }
                if (frm.CamposSelecionados["Marcas Sim"])
                    worksheet.Cells[row, col++].Value = item.MarcasSim;
                if (frm.CamposSelecionados["Marcas Não"])
                    worksheet.Cells[row, col++].Value = item.MarcasNao;
                if (frm.CamposSelecionados["Qtd Real"]) {
                    worksheet.Cells[row, col].Value = item.QtdReal;
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#0.000";
                }
                if (frm.CamposSelecionados["Marca"])
                    worksheet.Cells[row, col++].Value = item.Marca;
                if (frm.CamposSelecionados["Preço"]) {
                    worksheet.Cells[row, col].Value = item.Preco;
                    worksheet.Cells[row, col].Style.Numberformat.Format = "R$ #,##0.00";
                }
            }
            return row;
        }
        private void ToolStripMenuItemExportShop_Click(object sender, EventArgs e) {
            var newFile = ExportFile(@"Lista para Exportação", "shop", @"Arquivo Shop (*.shop)|*.shop");
            if (newFile == null)
                return;

            var lista = new clsListaCompleta(_listas[DataGridViewListas.CurrentCell.RowIndex], _itens);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(newFile.FullName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, lista);
            stream.Close();
            MessageBox.Show(@"Lista exportada para " + newFile.FullName, @"Listas de Compras", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripMenuItemExportXML_Click(object sender, EventArgs e) {
            var newFile = ExportFile(@"Lista para Exportação", "xml", @"Arquivo XML (*.xml)|*.xml");
            if (newFile == null)
                return;
            var writer = new XmlSerializer(typeof(List<clsItem>));
            using (var file = newFile.OpenWrite()) {
                writer.Serialize(file, _itens.OriginalList);
            }
            MessageBox.Show(@"Lista exportada para " + newFile.FullName, @"Listas de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ToolStripMenuItemPrintCompleteCategoria_Click(object sender, EventArgs e) {
            Report("rptListaCompletaCategoria");
        }
        private void ToolStripMenuItemPrintCompleteMapa_Click(object sender, EventArgs e) {
            Report("rptListaCompletaMapa");
        }
        private void ToolStripMenuItemPrintAbbreviatedCategoria_Click(object sender, EventArgs e) {
            Report("rptListaResumidaCategoria");
        }
        private void ToolStripMenuItemPrintAbbreviatedMapa_Click(object sender, EventArgs e) {
            Report("rptListaResumidaMapa");
        }
        private void Report(string reportName) {
            var frm = new frmRelatorio {MdiParent = this.MdiParent};
            frm.SetReport(_itens.ToList(), reportName, "DataSetListaCompras");
            frm.Show();
        }
        #endregion

        #region DragAndDrop
        private Rectangle _dragBoxFromMouseDown;
        private clsItem _itemFromMouseDown;

        private void DataGridViewItens_MouseMove(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            // If the mouse moves outside the rectangle, start the drag.
            if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y)) {
                // Proceed with the drag and drop, passing in the list item.                    
                var dropEffect = DataGridViewItens.DoDragDrop(_itemFromMouseDown, DragDropEffects.Move);
            }
        }

        private void DataGridViewItens_MouseDown(object sender, MouseEventArgs e) {
            // Get the index of the item the mouse is below.
            var hittestInfo = DataGridViewItens.HitTest(e.X, e.Y);

            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1) {
                _itemFromMouseDown = _itens[hittestInfo.RowIndex];
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                var dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                _dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                _dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DataGridViewListas_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void DataGridViewListas_DragOver(object sender, DragEventArgs e) {
            var clientPoint = DataGridViewListas.PointToClient(new Point(e.X, e.Y));
            var hittest = DataGridViewListas.HitTest(clientPoint.X, clientPoint.Y);
            if (hittest.RowIndex == DataGridViewListas.CurrentRow.Index ||
                hittest.RowIndex == DataGridViewListas.Rows.Count - 1)
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Move;
        }

        private void DataGridViewListas_DragDrop(object sender, DragEventArgs e) {
            int NovaLista;
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            var clientPoint = DataGridViewListas.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect != DragDropEffects.Move) return;
            var hittest = DataGridViewListas.HitTest(clientPoint.X, clientPoint.Y);
            if (hittest.RowIndex == -1) return;
            NovaLista = _listas[hittest.RowIndex].ID;
            if (Database.ItemMove(_itemFromMouseDown.ID, NovaLista)) {
                ItensLoad();
            }
        }

        #endregion

        private void DataGridViewItens_DataError(object sender, DataGridViewDataErrorEventArgs e) {

        }
    }
}
