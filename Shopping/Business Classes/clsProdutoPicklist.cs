using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shopping {
    public class clsProdutoPicklist : BaseData {
        public string Produto { get; set; }
        public string Categoria { get; set; }
        public bool ListaPadrao { get; set; }
        public bool Checked { get; set; }

        public clsProdutoPicklist(SqlDataReader r)
            : base(r) {
            Produto = r["Produto"].ToString();
            Categoria = r["Categoria"].ToString();
            ListaPadrao = (bool) r["ListaPadrao"];
            Checked = false;
        }

        public clsProdutoPicklist(ListViewItem lvi)
            : base() {
            Produto = lvi.Text;
            Categoria = lvi.Group.Name;
            ID = (int)lvi.Tag;
            Checked = true;
        }
    }
}
