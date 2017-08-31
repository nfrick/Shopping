using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shopping {
    public partial class frmExport : Form {
        public string Classe { get; set; }
        public Dictionary<string, bool> CamposSelecionados { get; set; }
        public bool Cabecalhos => checkBoxCabecalhos.Checked;
        public bool FlatTable => radioButtonFlat.Checked;

        public frmExport() {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e) {
            this.Text = @"Exportar " + Classe;
            string[] campos = null;
            switch (Classe) {
                case "Categoria":
                    campos = new[] { "Categoria", "Ocorrências" };
                    break;
                case "Produto":
                    campos = new[] { "Produto", "Unidade", "Qtd Normal", "Marcas Sim", "Marcas Não", 
                                        "Ocorrências", "Menor Qtd", "Médio Qtd", "Maior Qtd", "Última Qtd",
                                        "Menor Preço", "Médio Preço", "Maior Preço", "Último Preço" };
                    break;
                case "Lista":
                    campos = new[] { "Categoria", "Produto", "Nº Corredor", "Corredor", "Qtd Prevista", "Unidade", "Último Preço", 
                                        "Marcas Sim", "Marcas Não", "Qtd Real", "Marca", "Preço" };
                    break;
            }
            checkedListBoxCampos.Items.AddRange(campos);
            for (var i = 0; i < checkedListBoxCampos.Items.Count; i++) {
                checkedListBoxCampos.SetItemChecked(i, true);
            }
            CamposSelecionados = new Dictionary<string, bool>();
            foreach (var campo in campos)
                CamposSelecionados.Add(campo, false);
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            foreach (string campo in checkedListBoxCampos.CheckedItems)
                CamposSelecionados[campo] = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            CamposSelecionados = null;
            this.Close();
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e) {
            var checkAll = ((CheckBox)sender).Checked;
            if (checkAll) {
                for (var i = 0; i < checkedListBoxCampos.Items.Count; i++) {
                    checkedListBoxCampos.SetItemChecked(i, true);
                }
            }
            checkedListBoxCampos.Enabled = !checkAll;
        }
    }
}
