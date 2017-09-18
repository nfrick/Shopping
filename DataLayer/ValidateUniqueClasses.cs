using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataLayer {
    public class ValidateUniqueCategoriaAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            if (value == null)
                return true;
            var categoria = value as Categoria;
            using (var db = new ShoppingEntities()) {
                return !db.Categorias.Any(c => c.ID != categoria.ID && c.Nome == categoria.Nome);
            }
        }
    }

    public class ValidateUniqueLojaAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            if (value == null)
                return true;
            var loja = value as Loja;
            using (var db = new ShoppingEntities()) {
                return !db.Lojas.Any(l => l.ID != loja.ID && l.Nome == loja.Nome);
            } 
        }
    }

    public class ValidateUniqueProdutoAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            if (value == null)
                return true;
            var produto = value as Produto;
            using (var db = new ShoppingEntities()) {
                return !db.Produtos.Any(p => p.ID != produto.ID && p.Nome == produto.Nome);
            }
        }
    }
}