using System;
using System.Windows.Forms;

namespace Shopping {
    public partial class frmProdutoGrafico : Form {
        public clsProduto Produto { get; set; }
        private SortableBindingList<clsProdutoCompra> _compras;
        private BindingSource _sourceCompras = null;
        public frmProdutoGrafico() {
            InitializeComponent();
        }

        private void frmProdutoGrafico_Load(object sender, EventArgs e) {
            this.Text = Produto.Produto;
            _compras = Database.ProdutoComprasGet(Produto.ID);
            _sourceCompras = new BindingSource {DataSource = _compras};
            bindingSourceCompras.DataSource = _sourceCompras;
            
            foreach (var pc in _compras) {
                chartQtd.Series["Series1"].Points.AddXY(pc.Data, pc.Qtd);
                chartPreco.Series["Series1"].Points.AddXY(pc.Data, pc.Preco);
            }
        }
    }
}
