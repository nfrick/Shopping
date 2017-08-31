using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataLayer {
    public class ValidateUniqueCategoriaAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            var novo = value as Categoria;
            var db = new ShoppingEntities();
            return !db.Categorias.Any(p => p.Nome == novo.Nome);
        }
    }

    public class ValidateUniqueLojaAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            var novo = value as Loja;
            var db = new ShoppingEntities();
            return !db.Lojas.Any(p => p.Nome == novo.Nome);
        }
    }

    public class ValidateUniqueProdutoAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            var novo = value as Produto;
            var db = new ShoppingEntities();
            return !db.Produtos.Any(p => p.Nome == novo.Nome);
        }
    }
}