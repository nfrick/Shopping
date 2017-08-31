using System.Data.SqlClient;

namespace Shopping {
    public class clsCategoria : BaseData {
        public string Categoria { get; set; }
        public int Produtos { get; }

        public override string ToString() {
            return Categoria;
        }

        public clsCategoria()
            : base() {
            Categoria = string.Empty;
            Produtos = 0;
        }

        public clsCategoria(string nome)
            : base() {
            Categoria = nome;
            Produtos = 0;
        }

        public clsCategoria(SqlDataReader r)
            : base(r) {
            Categoria = r["Categoria"].ToString();
            Produtos = (int)r["Produtos"];
        }
    }
}
