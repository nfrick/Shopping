using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace DataLayer {

    [MetadataType(typeof(ProdutoPicklistMetadata))]
    public partial class ProdutoPicklist {
        public bool Adicionar { get; set; }

        public string Lista => ListaPadrao ? "Lista Padrão" : "Eventuais";

        public ProdutoImagem Imagem => new ProdutoImagem(ID);
    }

    public class ProdutoPicklistMetadata {
        // Name the field the same as EF named the property - "FirstName" for example.
        // Also, the type needs to match.  Basically just redeclare it.
        // Note that this is a field.  I think it can be a property too, but fields definitely should work.

        //[ReadOnly(true)] Se for usado ReadOnly o ID é perdido no POST
        public int ID { get; set; }

        //[ReadOnly(true)]
        public int Categoria { get; set; }

        //[ReadOnly(true)]
        public string Produto { get; set; }

        //[ReadOnly(true)]
        public string Unidade { get; set; }

        [Display(Name = "Quantidade")]
        [Range(0.01, 50, ErrorMessage = "{0} deve ser um número entre {1} e {2}.")]
        public decimal? QtdNormal { get; set; }

        [Display(Name = "Lista Padrão")]
        //[ReadOnly(true)]
        public bool ListaPadrao { get; set; }

        public bool Adicionar { get; set; }

        public ProdutoImagem Imagem { get; }
    }
}
