using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Shopping {
    [Serializable()]
    public class clsLista : BaseData {
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public int LojaID { get; set; }

        public clsLista()
            : base() {
            Data = null;
            Descricao = string.Empty;
            LojaID = 1;
        }
        public clsLista(SqlDataReader r)
            : base(r) {
            Data = (DateTime)r["Data"];
            Descricao = r["Descricao"].ToString();
            LojaID = (int)r["LojaID"];
        }
    }

    [Serializable()]
    public class clsListaCompleta {
        public int ListaID { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public int LojaID { get; set; }
        public List<clsItem> Itens { get; set; }
        public clsListaCompleta() { }
        public clsListaCompleta(clsLista lista, SortableBindingList<clsItem> itens) {
            ListaID = lista.ID;
            Data = lista.Data;
            Descricao = lista.Descricao;
            LojaID = lista.LojaID;
            Itens = itens.OriginalList;
        }
    }
}
