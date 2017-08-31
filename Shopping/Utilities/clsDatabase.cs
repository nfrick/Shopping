using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shopping {
    internal class Database {
        private static void ShowError(string function, Exception ex) {
            MessageBox.Show($"Erro em {function}:\n\nTipo: {ex.GetType()}\n\nMensagem: {ex.Message}.",
                "Erro em acesso ao banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #region Connection
        /// <summary>
        /// Adjusts and returns connection string according to computer
        /// </summary>
        private static SqlConnection GetConnectionShopping() {
            return GetConnection(ConfigurationManager.ConnectionStrings["Shopping"].ToString());
        }

        /// <summary>
        /// Returns an opened connection object to Access DB
        /// </summary>
        /// <returns>OleDbConnection conn</returns>
        private static SqlConnection GetConnection(string connectionString) {
            try {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex) {
                MessageBox.Show($"Error in Database.GetConnection()\nString: {connectionString}\n{ex.Message}");
                return null;
            }
        }
        #endregion

        #region HasRecords
        public static int HasRecords() {
            try {
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_HasRecords", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    var pResult = cmd.Parameters.Add("@Result", SqlDbType.Int);
                    pResult.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    return (int)pResult.Value;
                }
            }
            catch (Exception ex) {
                ShowError("Database.HasRecords()", ex);
                return 0;
            }
        }
        #endregion

        #region Categoria
        public static SortableBindingList<clsCategoria> CategoriasGet() {
            try {
                var Categorias = new SortableBindingList<clsCategoria>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_Categorias", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        Categorias.Add(new clsCategoria(r));
                    r.Close();
                    return Categorias;
                }
            }
            catch (Exception ex) {
                ShowError("Database.CategoriasGet()", ex);
                return null;
            }
        }
        public static bool CategoriasUpdate(List<clsCategoria> Categorias, List<clsCategoria> Deleted) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_CategoriaUpsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        foreach (clsCategoria cat in Categorias) {
                            cmd.Parameters.Add(new SqlParameter("@ID", cat.ID));
                            cmd.Parameters.Add(new SqlParameter("@Categoria", cat.Categoria));
                            var pNewID = cmd.Parameters.Add("@NewId", SqlDbType.Int);
                            pNewID.Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            var NewID = pNewID.Value as int?;
                            cat.ID = NewID ?? cat.ID;
                            cmd.Parameters.Clear();
                        }
                        cmd.CommandText = "sp_CategoriaDelete";
                        foreach (var cat in Deleted) {
                            cmd.Parameters.Add(new SqlParameter("@ID", cat.ID));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.CategoriaUpdate", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.CategoriaUpdate", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.CategoriaUpdate", ex);
                return false;
            }
        }

        #endregion

        #region Produto
        public static SortableBindingList<clsProduto> ProdutosGet(bool getAllRecords) {
            try {
                var produtos = new SortableBindingList<clsProduto>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_Produtos", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Modo", getAllRecords));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        produtos.Add(new clsProduto(r));
                    r.Close();
                    return produtos;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutosGet()", ex);
                return null;
            }
        }

        public static bool ProdutosUpdate(List<clsProduto> produtos, List<clsProduto> deleted) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ProdutoUpsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        foreach (var prod in produtos) {
                            cmd.Parameters.Add(new SqlParameter("@ID", prod.ID));
                            cmd.Parameters.Add(new SqlParameter("@CategoriaID", prod.CategoriaID));
                            cmd.Parameters.Add(new SqlParameter("@Produto", prod.Produto));
                            cmd.Parameters.Add(new SqlParameter("@Unidade", prod.Unidade));
                            cmd.Parameters.Add(new SqlParameter("@QtdNormal", prod.QtdNormal));
                            cmd.Parameters.Add(new SqlParameter("@MarcasSim", prod.MarcasSim));
                            cmd.Parameters.Add(new SqlParameter("@MarcasNao", prod.MarcasNao));
                            cmd.Parameters.Add(new SqlParameter("@ListaPadrao", prod.ListaPadrao));
                            var pNewID = cmd.Parameters.Add("@NewId", SqlDbType.Int);
                            pNewID.Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            var NewID = pNewID.Value as int?;
                            prod.ID = NewID ?? prod.ID;
                            cmd.Parameters.Clear();
                        }
                        cmd.CommandText = "sp_ProdutoDelete";
                        foreach (var cat in deleted) {
                            cmd.Parameters.Add(new SqlParameter("@ID", cat.ID));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ProdutoUpdate", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ProdutoUpdate", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoUpdate", ex);
                return false;
            }
        }
        public static List<clsProdutoPicklist> ProdutoPicklistGet(int ListaID) {
            try {
                var produtos = new List<clsProdutoPicklist>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_ProdutosPicklist", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@listaID", ListaID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        produtos.Add(new clsProdutoPicklist(r));
                    r.Close();
                    return produtos;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoPicklistGet()", ex);
                return null;
            }
        }

        public static List<clsProdutoPicklist> ProdutosDisponiveisGet(int LojaID) {
            try {
                var produtos = new List<clsProdutoPicklist>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_ProdutosNaoMapeados", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@lojaID", LojaID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        produtos.Add(new clsProdutoPicklist(r));
                    r.Close();
                    return produtos;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoNaoMapeadosGet()", ex);
                return null;
            }
        }

        public static List<clsProdutoPicklist> ProdutoMapeadosGet(int MapaID) {
            try {
                List<clsProdutoPicklist> produtos = new List<clsProdutoPicklist>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_ProdutosMapeados", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@MapaID", MapaID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        produtos.Add(new clsProdutoPicklist(r));
                    r.Close();
                    return produtos;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoMapeadosGet()", ex);
                return null;
            }
        }
        #endregion

        #region Lista
        public static SortableBindingList<clsLista> ListasGet() {
            try {
                var listas = new SortableBindingList<clsLista>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_Listas", conn) {CommandType = CommandType.StoredProcedure};
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        listas.Add(new clsLista(r));
                    r.Close();
                    return listas;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ListasGet()", ex);
                return null;
            }
        }

        public static bool ListaUpdate(clsLista lista, List<clsItem> itens) {
            try {
                var produtoCorredor = ProdutoMapaLojaGet(lista.LojaID);
                var corredorMapaId = MapaLojaGet(lista.LojaID);
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ListaUpsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        if (lista.Updated) {
                            cmd.Parameters.Add(new SqlParameter("@ID", lista.ID));
                            cmd.Parameters.Add(new SqlParameter("@Data", lista.Data));
                            cmd.Parameters.Add(new SqlParameter("@Descricao", lista.Descricao));
                            cmd.Parameters.Add(new SqlParameter("@lojaID", lista.LojaID));
                            var pNewID = cmd.Parameters.Add("@NewId", SqlDbType.Int);
                            pNewID.Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            var NewID = pNewID.Value as int?;
                            lista.ID = NewID ?? lista.ID;
                        }

                        foreach (var item in itens) {
                            cmd.CommandText = "sp_ItemUpdate";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@ID", item.ID));
                            cmd.Parameters.Add(new SqlParameter("@Marca", item.Marca));
                            cmd.Parameters.Add(new SqlParameter("@Preco", item.Preco));
                            cmd.Parameters.Add(new SqlParameter("@QtdPrevista", item.QtdPrevista));
                            cmd.Parameters.Add(new SqlParameter("@QtdReal", item.QtdReal));
                            cmd.ExecuteNonQuery();

                            int oldCorredor;
                            var mustUpdate = true;
                            if (produtoCorredor.TryGetValue(item.ProdutoID, out oldCorredor))
                                mustUpdate = oldCorredor != item.CorredorNum;
                            else
                                mustUpdate = item.CorredorNum != 0;
                            if (!mustUpdate) continue;
                            int oldMapaId, newMapaId;
                            corredorMapaId.TryGetValue(oldCorredor, out oldMapaId);
                            corredorMapaId.TryGetValue(item.CorredorNum, out newMapaId);
                            if(! (item.CorredorNum > 0 && newMapaId == 0)) // Não fazer se CorredorNum não existir
                                ProdutoMapaUpsert(item.ProdutoID, oldMapaId, newMapaId);
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ListaUpdate", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ListaUpdate", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ListaUpdate", ex);
                return false;
            }
        }

        public static bool ListaUpdate(List<clsLista> listas, List<clsItem> itens) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ListaUpsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        foreach (clsLista lista in listas) {
                            cmd.Parameters.Add(new SqlParameter("@ID", lista.ID));
                            cmd.Parameters.Add(new SqlParameter("@Data", lista.Data));
                            cmd.Parameters.Add(new SqlParameter("@Descricao", lista.Descricao));
                            cmd.Parameters.Add(new SqlParameter("@lojaID", lista.LojaID));
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = "sp_ItemUpdate";
                        foreach (clsItem item in itens) {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@ID", item.ID));
                            cmd.Parameters.Add(new SqlParameter("@Marca", item.Marca));
                            cmd.Parameters.Add(new SqlParameter("@Preco", item.Preco));
                            cmd.Parameters.Add(new SqlParameter("@QtdPrevista", item.QtdPrevista));
                            cmd.Parameters.Add(new SqlParameter("@QtdReal", item.QtdReal));
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ListaUpdate", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ListaUpdate", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ListaUpdate", ex);
                return false;
            }
        }

        public static bool ListaDelete(int listaID) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ListaDelete", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        cmd.Parameters.Add(new SqlParameter("@ID", listaID));
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ListaDelete", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ListaDelete", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ListaDelete", ex);
                return false;
            }
        }
        #endregion

        #region Item
        public static SortableBindingList<clsItem> ItensGet(int ListaID) {
            try {
                var Itens = new SortableBindingList<clsItem>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_Itens", conn) {CommandType = System.Data.CommandType.StoredProcedure};
                    cmd.Parameters.Add(new SqlParameter("@listaID", ListaID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        Itens.Add(new clsItem(r));
                    r.Close();
                    return Itens;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ItensGet()", ex);
                return null;
            }
        }

        public static bool ItemInsert(List<clsProdutoPicklist> itens, int listaID) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ItemInsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        foreach (var item in itens) {
                            cmd.Parameters.Add(new SqlParameter("@produtoID", item.ID));
                            cmd.Parameters.Add(new SqlParameter("@listaID", listaID));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ItemInsert", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ItemInsert", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ItemInsert", ex);
                return false;
            }
        }

        public static bool ItemDelete(int itemID) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ItemDelete", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        cmd.Parameters.Add(new SqlParameter("@ID", itemID));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ItemDelete", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ItemDelete", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ItemDelete", ex);
                return false;
            }
        }

        internal static bool ItemReplace(ListView.SelectedListViewItemCollection sel, int itemID) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ItemReplace", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        cmd.Parameters.Add(new SqlParameter("@ID", itemID));
                        cmd.Parameters.Add(new SqlParameter("@NewProduct", sel[0].Tag));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ItemReplace", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ItemReplace", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ItemReplace", ex);
                return false;
            }
        }

        public static bool ItemMove(int itemID, int novaLista) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ItemMove", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        cmd.Parameters.Add(new SqlParameter("@ID", itemID));
                        cmd.Parameters.Add(new SqlParameter("@NovaLista", novaLista));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ItemMove", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ItemMove", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ItemMove", ex);
                return false;
            }
        }

        #endregion

        #region Loja
        public static SortableBindingList<clsLoja> LojasGet() {
            try {
                var lojas = new SortableBindingList<clsLoja>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_Lojas", conn) {CommandType = System.Data.CommandType.StoredProcedure};
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        lojas.Add(new clsLoja(r));
                    r.Close();
                    return lojas;
                }
            }
            catch (Exception ex) {
                ShowError("Database.LojasGet()", ex);
                return null;
            }
        }

        public static bool LojaUpdate(clsLoja loja, List<clsMapa> lojaMapa) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_LojaUpsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        if (loja.Updated) {
                            cmd.Parameters.Add(new SqlParameter("@ID", loja.ID));
                            cmd.Parameters.Add(new SqlParameter("@Loja", loja.Loja));
                            var pNewID = cmd.Parameters.Add("@NewId", SqlDbType.Int);
                            pNewID.Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            var NewID = pNewID.Value as int?;
                            loja.ID = NewID ?? loja.ID;
                        }

                        foreach (var mapa in lojaMapa) {
                            cmd.CommandText = "sp_MapaUpsert";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@ID", mapa.ID));
                            cmd.Parameters.Add(new SqlParameter("@lojaID", loja.ID));
                            cmd.Parameters.Add(new SqlParameter("@Corredor", mapa.Corredor));
                            cmd.Parameters.Add(new SqlParameter("@Descricao", mapa.Descricao));
                            var pNewID = cmd.Parameters.Add("@NewId", SqlDbType.Int);
                            pNewID.Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            var NewID = pNewID.Value as int?;
                            mapa.ID = NewID ?? mapa.ID;
                            cmd.CommandText = "sp_ProdutoMapaDelete";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MapaID", mapa.ID));
                            cmd.ExecuteNonQuery();
                            foreach (var p in mapa.Produtos) {
                                cmd.CommandText = "sp_ProdutoMapaAdd";
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add(new SqlParameter("@MapaID", mapa.ID));
                                cmd.Parameters.Add(new SqlParameter("@produtoID", p.ID));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.LojaUpdate", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.LojaUpdate", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.LojaUpdate", ex);
                return false;
            }
        }

        public static bool LojaUpdate(List<clsLoja> lojas, List<clsMapa> lojaMapa) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_LojaUpsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        foreach (var loja in lojas) {
                            cmd.Parameters.Add(new SqlParameter("@ID", loja.ID));
                            cmd.Parameters.Add(new SqlParameter("@Loja", loja.Loja));
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = "sp_MapaUpsert";
                        foreach (var mapa in lojaMapa) {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@ID", mapa.ID));
                            cmd.Parameters.Add(new SqlParameter("@lojaID", mapa.LojaID));
                            cmd.Parameters.Add(new SqlParameter("@Corredor", mapa.Corredor));
                            cmd.Parameters.Add(new SqlParameter("@Descricao", mapa.Descricao));
                            SqlParameter pNewID = cmd.Parameters.Add("@NewId", SqlDbType.Int);
                            pNewID.Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            var NewID = pNewID.Value as int?;
                            mapa.ID = NewID ?? mapa.ID;
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.LojaUpdate", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.LojaUpdate", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.LojaUpdate", ex);
                return false;
            }
        }

        public static bool LojaDelete(int lojaID) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_LojaDelete", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        cmd.Parameters.Add(new SqlParameter("@ID", lojaID));
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.LojaDelete", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.LojaDelete", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.LojaDelete", ex);
                return false;
            }
        }
        #endregion

        #region Mapa
        public static SortableBindingList<clsMapa> MapasGet(int ListaID) {
            try {
                var mapas = new SortableBindingList<clsMapa>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_Mapas", conn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.Add(new SqlParameter("@lojaID", ListaID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        mapas.Add(new clsMapa(r));
                    r.Close();
                    return mapas;
                }
            }
            catch (Exception ex) {
                ShowError("Database.MapasGet()", ex);
                return null;
            }
        }

        public static bool ProdutoMapaUpsert(int produtoID, int oldMapaID, int newMapaID) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_ProdutoMapaUpsert", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        cmd.Parameters.Add(new SqlParameter("@produtoID", produtoID));
                        cmd.Parameters.Add(new SqlParameter("@oldMapaID", oldMapaID));
                        cmd.Parameters.Add(new SqlParameter("@newMapaID", newMapaID));
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.ProdutoMapaUpsert", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.ProdutoMapaUpsert", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoMapaUpsert", ex);
                return false;
            }
        }

        public static bool MapaDelete(int MapaID) {
            try {
                using (var conn = GetConnectionShopping()) {
                    var transaction = conn.BeginTransaction("Transaction");
                    var cmd = new SqlCommand("sp_MapaDelete", conn) {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    try {
                        cmd.Parameters.Add(new SqlParameter("@ID", MapaID));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) {
                        ShowError("Database.MapaDelete", ex);

                        // Attempt to roll back the transaction. 
                        try {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception ex2) {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            ShowError("Database.MapaDelete", ex2);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ShowError("Database.MapaDelete", ex);
                return false;
            }
        }
        #endregion

        public static Dictionary<int, int> ProdutoMapaLojaGet(int LojaID) {
            try {
                var mapas = new Dictionary<int, int>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_ProdutoMapaLoja", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@lojaID", LojaID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        mapas.Add((int)r["produtoID"], (int)r["CorredorNum"]);
                    r.Close();
                    return mapas;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoMapaLojaGet()", ex);
                return null;
            }
        }

        public static Dictionary<int, int> MapaLojaGet(int lojaID) {
            try {
                var mapas = new Dictionary<int, int>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_Mapas", conn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.Add(new SqlParameter("@lojaID", lojaID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        mapas.Add((int)r["Corredor"], (int)r["ID"]);
                    r.Close();
                    return mapas;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoMapaLojaGet()", ex);
                return null;
            }
        }

        public static SortableBindingList<clsProdutoCompra> ProdutoComprasGet(int produtoID) {
            try {
                var compras = new SortableBindingList<clsProdutoCompra>();
                using (var conn = GetConnectionShopping()) {
                    var cmd = new SqlCommand("sp_ProdutoCompras", conn) {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@produtoID", produtoID));
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        compras.Add(new clsProdutoCompra(r));
                    r.Close();
                    return compras;
                }
            }
            catch (Exception ex) {
                ShowError("Database.ProdutoComprasGet()", ex);
                return null;
            }
        }
    }
}
