using System;
using System.Data.SqlClient;

namespace Shopping {
    class clsProdutoCompra {
        public DateTime Data { get; set; }
        public decimal Qtd { get; set; }
        public string Marca { get; set; }
        public decimal Preco { get; set; }

        public clsProdutoCompra(SqlDataReader r) {
            Data = (DateTime)r["Data"];
            Qtd = (decimal)r["QtdReal"];
            Marca = r["Marca"].ToString();
            Preco = (decimal)r["Preco"];
        }
    }
}
