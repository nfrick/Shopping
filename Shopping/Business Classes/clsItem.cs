using System;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Shopping {
    [Serializable()]
    public class clsItem : clsProduto {
        [XmlIgnore]
        public int ListaID { get; set; }
        [XmlIgnore]
        public int ProdutoID { get; set; }
        public string Categoria { get; set; }
        public decimal? QtdPrevista { get; set; }
        public decimal? QtdReal { get; set; }
        public string Marca { get; set; }
        public decimal? Preco { get; set; }
        public int CorredorNum { get; set; }
        public string CorredorDescricao { get; set; }
        public decimal? SubTotal => (QtdReal == null || Preco == null) ? null : QtdReal * Preco;
        public clsItem()
            : base() { }
        public clsItem(SqlDataReader r)
            : base(r) {
            ListaID = (int)r["ListaID"];
            ProdutoID = (int)r["ProdutoID"];
            Categoria = r["Categoria"].ToString();
            QtdPrevista = r["QtdPrevista"] == DBNull.Value ? (decimal?)null : (decimal)r["QtdPrevista"];
            QtdReal = (r["QtdReal"] == DBNull.Value) ? (decimal?)null : (decimal)r["QtdReal"];
            Marca = r["Marca"].ToString();
            Preco = r["Preco"] == DBNull.Value ? (decimal?)null : (decimal)r["Preco"];
            CorredorNum = r["CorredorNum"] == DBNull.Value ? 0 : (int)r["CorredorNum"];
            CorredorDescricao = r["CorredorDescricao"] == DBNull.Value ? "indefinido" : r["CorredorDescricao"].ToString();
        }
    }
}
