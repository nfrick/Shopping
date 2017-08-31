using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Shopping {

    public enum PicklistMode {
        Add,
        Replace
    }

    

    public partial class frmProdutosPicklist : Form {

        private class CategoriaProdutos {
            public string Categoria { get; set; }
            public List<clsProdutoPicklist> Produtos { get; set; }
        }

        public int ListaID { get; set; }
        public PicklistMode Mode { get; set; }
        public clsItem Target { get; set; }

        private List<clsProdutoPicklist> _produtos;
        public frmProdutosPicklist() {
            InitializeComponent();
        }

        private void frmProdutosPicklist_Load(object sender, EventArgs e) {
            LoadData();
            var padrao = _produtos.Count(p => p.ListaPadrao);
            var eventuais = _produtos.Count(p => !p.ListaPadrao);
            radioButtonExibirPadrao.Enabled = padrao > 0;
            radioButtonExibirEventuais.Enabled = eventuais > 0;
            if (Mode == PicklistMode.Replace) {
                listViewProdutos.CheckBoxes = false;
                listViewProdutos.MultiSelect = false;
                this.Text = $@"Substituir '{Target.Produto}' por:";
                buttonAdicionar.Text = @"Substituir";
                radioButtonExibirSelecionados.Visible = false;
                radioButtonExibirNaoSelecionados.Visible = false;
                toolStripStatusEventuaisDisp.Visible = false;
                toolStripStatusEventuaisSel.Visible = false;
                toolStripStatusPadraoDisp.Visible = false;
                toolStripStatusPadraoSel.Visible = false;
                toolStripStatusLabel1.Text = $@"Lista Padrão: {padrao}";
                toolStripStatusLabel5.Text = $@"Produtos Eventuais: {eventuais}";
                groupBox3.Visible = false;
            }
            else
                UpdateToolStrip();

        }

        private void LoadData() {
            _produtos = Database.ProdutoPicklistGet(ListaID);
            LoadLista();
        }

        private void LoadLista() {
            CategoriaProdutos[] categorias;
            List<clsProdutoPicklist> produtosAExibir;
            if (radioButtonExibirTodos.Checked)
                produtosAExibir = _produtos;
            else if (radioButtonExibirPadrao.Checked)
                produtosAExibir = _produtos.Where(p => p.ListaPadrao).ToList();
            else if (radioButtonExibirEventuais.Checked)
                produtosAExibir = _produtos.Where(p => !p.ListaPadrao).ToList();
            else if (radioButtonExibirSelecionados.Checked)
                produtosAExibir = _produtos.Where(p => p.Checked).ToList();
            else
                produtosAExibir = _produtos.Where(p => !p.Checked).ToList();


            if (radioButtonOrdemCategoria.Checked)
                categorias = produtosAExibir
                    .GroupBy(p => p.Categoria, p => p,
                        (k, g) => new CategoriaProdutos { Categoria = k, Produtos = g.OrderBy(p => p.Produto).ToList() })
                    .OrderBy(c => c.Categoria)
                    .ToArray();
            else
                categorias = produtosAExibir
                    .GroupBy(p => clsDiversos.TiraAcento(p.Produto.ElementAt(0).ToString().ToUpper()), p => p, (k, g) => new CategoriaProdutos { Categoria = k, Produtos = g.OrderBy(p => p.Produto).ToList() })
                    .OrderBy(c => c.Categoria)
                    .ToArray();

            listViewProdutos.BeginUpdate();
            listViewProdutos.Items.Clear();
            foreach (var cat in categorias) {
                var lvg = listViewProdutos.Groups.Add(cat.Categoria, cat.Categoria);
                foreach (var prod in cat.Produtos) {
                    var lvi = listViewProdutos.Items.Add(prod.Produto);
                    lvi.Tag = prod.ID;
                    lvi.Group = lvg;
                    lvi.Checked = prod.Checked;
                }
            }
            listViewProdutos.EndUpdate();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e) {
            if (Mode == PicklistMode.Replace) {
                if (Database.ItemReplace(listViewProdutos.SelectedItems, Target.ID)) {
                    this.Close();
                }
            }
            else
                AdicionarALista();
        }

        private void AdicionarALista() {
            if (Database.ItemInsert(_produtos.Where(p => p.Checked).ToList(), ListaID)) {
                LoadData();
            }
        }

        private void listViewProdutos_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (e.Item.Tag == null) return;
            _produtos.Find(p => p.ID == (int)e.Item.Tag).Checked = e.Item.Checked;
            buttonAdicionar.Enabled = _produtos.Any(p => p.Checked);
            radioButtonExibirSelecionados.Enabled = _produtos.Any(p => p.Checked);
            radioButtonExibirNaoSelecionados.Enabled = _produtos.Any(p => !p.Checked);
            UpdateToolStrip();
        }

        private void UpdateToolStrip() {
            toolStripStatusEventuaisDisp.Text = @"disponíveis: " +
                                                _produtos.Count(p => !p.Checked && !p.ListaPadrao);
            toolStripStatusEventuaisSel.Text = @"selecionados: " + _produtos.Count(p => p.Checked && !p.ListaPadrao);
            toolStripStatusPadraoDisp.Text = @"disponíveis: " +
                                                _produtos.Count(p => !p.Checked && p.ListaPadrao);
            toolStripStatusPadraoSel.Text = @"selecionados: " + _produtos.Count(p => p.Checked && p.ListaPadrao);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            var rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;
            LoadLista();
        }

        private void listViewProdutos_SelectedIndexChanged(object sender, EventArgs e) {
            buttonAdicionar.Enabled = Mode == PicklistMode.Replace && listViewProdutos.SelectedItems.Count > 0;
        }

        private void buttonSelecionar_Click(object sender, EventArgs e) {
            var btn = sender as Button;
            var chk = btn.Name == "buttonTodos";
            foreach (ListViewItem lvi in listViewProdutos.Items) {
                lvi.Checked = chk;
            }
        }

        private void buttonSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmProdutosPicklist_FormClosing(object sender, FormClosingEventArgs e) {
            if (Mode == PicklistMode.Replace || !_produtos.Any(p => p.Checked)) return;
            var Checked = _produtos.Count(p => p.Checked);
            var prompt = Checked == 1
                ? "Há 1 item selecionado que não foi adicionado."
                : $"Há {Checked} itens selecionados que não foram adicionados.";
            switch (MessageBox.Show(prompt + "\n\nAdicionar?",
                "Adicionar à Lista", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question)) {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
                case DialogResult.Yes:
                    AdicionarALista();
                    break;
                default:
                    break;

            }
        }
    }
}
