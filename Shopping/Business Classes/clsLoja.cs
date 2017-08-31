using System.Data.SqlClient;

namespace Shopping {
    class clsLoja : BaseData {
        public string Loja { get; set; }

        public clsLoja()
            : base() {
            Loja = string.Empty;
        }
        public clsLoja(SqlDataReader r)
            : base(r) {
            Loja = r["Loja"].ToString();
        }
    }
}
