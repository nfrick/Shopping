using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shopping {
    class clsMapa : BaseData {
        public int LojaID { get; set; }
        public int Corredor { get; set; }
        public string Descricao { get; set; }
        public List<clsProdutoPicklist> Produtos { get; set; }

        public clsMapa()
            : base() {
            LojaID = 0;
            Corredor = 0;
            Descricao = string.Empty;
            Produtos = new List<clsProdutoPicklist>();
        }
        public clsMapa(SqlDataReader r)
            : base(r) {
            LojaID = (int)r["LojaID"];
            Corredor = (int)r["Corredor"];
            Descricao = r["Descricao"].ToString();
            Produtos = Database.ProdutoMapeadosGet(ID);
        }

        public void ProdutosUpdate(ListView lv) {
            Produtos = new List<clsProdutoPicklist>();
            foreach (ListViewItem lvi in lv.Items) {
                Produtos.Add(new clsProdutoPicklist(lvi));
            }
            Updated = true;
        }

        public void ProdutoRemove(ListViewItem lvi) {
            var produto = Produtos.Find(p => p.ID == (int)lvi.Tag);
            Produtos.Remove(produto);
            Updated = true;
        }

        public void ProdutoAdd(ListViewItem lvi) {
            var produto = new clsProdutoPicklist(lvi);
            Produtos.Add(produto);
            Updated = true;
        }
    }
}
