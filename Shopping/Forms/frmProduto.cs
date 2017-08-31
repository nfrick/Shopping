using System;
using System.Windows.Forms;

namespace Shopping {
    public partial class frmProduto : Form {
        public clsProduto Produto { get; set; }

        public frmProduto() {
            InitializeComponent();
        }

        private void frmProduto_Load(object sender, EventArgs e) {
            propGridProduto.SelectedObject = Produto;
        }

        private void propGridProduto_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            Produto.Updated = true;
        }
    }
}
