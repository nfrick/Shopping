using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Shopping {
    [Serializable()]
    public class clsProduto : BaseData {
        #region 1. Identificação
        //[XmlIgnore]
        [Category(@"1. Identificação"), DisplayName(@"a. Produto"), Description(@"Nome do produto")]
        public string Produto { get; set; }

        [Category(@"1. Identificação"), DisplayName(@"b. Categoria"), Description(@"Categoria"),]
        [TypeConverter(typeof(CategoriaConverter))]
        public int CategoriaID { get; set; }

        [Category(@"1. Identificação"), DisplayName(@"c. Unidade"), Description(@"Unidade: un, kg, gramas, litros, etc.")]
        [TypeConverter(typeof(UnidadeConverter))]
        public string Unidade { get; set; }

        [XmlIgnore]
        [TypeConverter(typeof(SimNaoConverter))]
        [Category(@"1. Identificação"), DisplayName(@"d. Lista Padrão"), Description(@"Indica se Produto é comprado frequentemente")]
        public bool ListaPadrao { get; set; }
        #endregion

        #region 2. Estatística
        [XmlIgnore]
        [Category(@"2. Estatística"), DisplayName(@"a. Ocorrências"), Description(@"Número de listas onde produto aparece")]
        public int Ocorrencias { get; }

        [XmlIgnore]
        [Category(@"2. Estatística"), DisplayName(@"b. Última Compra"), Description(@"Data da última compra")]
        public DateTime? DataUlt { get; }
        #endregion

        #region 3. Marcas
        [Category(@"3. Marcas"), DisplayName(@"a. Boas"), Description(@"Marcas a serem compradas")]
        public string MarcasSim { get; set; }

        [Category(@"3. Marcas"), DisplayName(@"b. Evitar"), Description(@"Marcas a serem evitadas")]
        public string MarcasNao { get; set; }

        [XmlIgnore]
        [Category(@"3. Marcas"), DisplayName(@"c. Compradas"), Description(@"Marcas efetivamente compradas")]
        public string MarcasCompradas { get; }
        #endregion

        #region 4. Quantidades
        [Category(@"4. Quantidades"), DisplayName(@"a. Normal"), Description(@"Quantidade normal a ser comprada")]
        public decimal? QtdNormal { get; set; }

        [XmlIgnore]
        [Category(@"4. Quantidades"), DisplayName(@"b. Última"), Description(@"Última quantidade comprada")]
        public decimal? QtdUlt { get; }

        [XmlIgnore]
        [Category(@"4. Quantidades"), DisplayName(@"c. Mínima"), Description(@"Menor quantidade comprada")]
        public decimal? QtdMin { get; }

        [XmlIgnore]
        [Category(@"4. Quantidades"), DisplayName(@"d. Média"), Description(@"Média das quantidades compradas")]
        public decimal? QtdMed { get; }

        [XmlIgnore]
        [Category(@"4. Quantidades"), DisplayName(@"e. Máxima"), Description(@"Maior quantidade comprada")]
        public decimal? QtdMax { get; }
        #endregion

        #region 5. Preços
        [Category(@"5. Preços"), DisplayName(@"a. Último"), Description(@"Último preço pago")]

        public decimal? PrecoUlt { get; set; }
        [XmlIgnore]
        [Category(@"5. Preços"), DisplayName(@"b. Mínimo"), Description(@"Menor preço pago")]
        public decimal? PrecoMin { get; }

        [XmlIgnore]
        [Category(@"5. Preços"), DisplayName(@"c. Médio"), Description(@"Preço médio")]
        public decimal? PrecoMed { get; }

        [XmlIgnore]
        [Category(@"5. Preços"), DisplayName(@"d. Máximo"), Description(@"Maior preço pago")]
        public decimal? PrecoMax { get; }


        #endregion

        [Browsable(false)]
        public Boolean QtdDif => (QtdNormal == null || QtdNormal == 0 || QtdMed == null) ?
                    false :
                    Math.Abs(((decimal)QtdNormal - (decimal)QtdMed) / (decimal)QtdNormal) >= 0.2m;

        public clsProduto()
                : base() {
            CategoriaID = 1;
            Produto = string.Empty;
            Unidade = string.Empty;
            QtdNormal = 0.0m;
            MarcasSim = string.Empty;
            MarcasNao = string.Empty;
            MarcasCompradas = string.Empty;
            ListaPadrao = false;
            Ocorrencias = 0;
            QtdMin = null; // 0.0m;
            QtdMed = null; // 0.0m;
            QtdMax = null; // 0.0m;
            QtdUlt = null; // 0.0m;
            PrecoMin = null; // 0.0m;
            PrecoMed = null; // 0.0m;
            PrecoMax = null; // 0.0m;
            PrecoUlt = null; // 0.0m;
            DataUlt = null;
        }

        public clsProduto(SqlDataReader r)
                : base(r) {
            CategoriaID = (int)r["CategoriaID"];
            Produto = r["Produto"].ToString();
            Unidade = r["Unidade"].ToString();
            QtdNormal = r["QtdNormal"] == DBNull.Value ? (decimal?)null : (decimal)r["QtdNormal"];
            MarcasSim = r["MarcasSim"].ToString();
            MarcasNao = r["MarcasNao"].ToString();
            MarcasCompradas = HasColumn(r, "MarcasCompradas") ? r["MarcasCompradas"].ToString() : string.Empty;
            ListaPadrao = (bool)r["ListaPadrao"];
            Ocorrencias = HasColumn(r, "Ocorrencias") ? (int)r["Ocorrencias"] : 0;
            QtdMin = HasColumn(r, "QtdMin") ? ((r["QtdMin"] == DBNull.Value) ? (decimal?)null : ((decimal)r["QtdMin"])) : (decimal?)null;
            QtdMed = HasColumn(r, "QtdMed") ? ((r["QtdMed"] == DBNull.Value) ? (decimal?)null : ((decimal)r["QtdMed"])) : (decimal?)null;
            QtdMax = HasColumn(r, "QtdMax") ? ((r["QtdMax"] == DBNull.Value) ? (decimal?)null : ((decimal)r["QtdMax"])) : (decimal?)null;
            QtdUlt = HasColumn(r, "QtdUlt") ? ((r["QtdUlt"] == DBNull.Value) ? (decimal?)null : ((decimal)r["QtdUlt"])) : (decimal?)null;
            PrecoMin = HasColumn(r, "PrecoMin") ? ((r["PrecoMin"] == DBNull.Value) ? (decimal?)null : ((decimal)r["PrecoMin"])) : (decimal?)null;
            PrecoMed = HasColumn(r, "PrecoMed") ? ((r["PrecoMed"] == DBNull.Value) ? (decimal?)null : ((decimal)r["PrecoMed"])) : (decimal?)null;
            PrecoMax = HasColumn(r, "PrecoMax") ? ((r["PrecoMax"] == DBNull.Value) ? (decimal?)null : ((decimal)r["PrecoMax"])) : (decimal?)null;
            PrecoUlt = HasColumn(r, "PrecoUlt") ? ((r["PrecoUlt"] == DBNull.Value) ? (decimal?)null : ((decimal)r["PrecoUlt"])) : (decimal?)null;
            DataUlt = HasColumn(r, "DataUlt") ? ((r["DataUlt"] == DBNull.Value) ? (DateTime?)null : ((DateTime)r["DataUlt"])) : (DateTime?)null;
        }

        private static bool HasColumn(IDataReader reader, string columnName) {
            var schemaTable = reader.GetSchemaTable();
            return schemaTable != null && schemaTable.Rows.Cast<DataRow>().Any(row => row["ColumnName"].ToString() == columnName);
        }
    }
}
