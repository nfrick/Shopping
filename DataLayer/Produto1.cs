using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataLayer {
    [MetadataType(typeof(ProdutoMetadata))]
    [ValidateUniqueProduto(ErrorMessage= "Produto já cadastrada!")]
    public partial class Produto {
        // Note this class has nothing in it.  It's just here to add the class-level attribute.
        public decimal? QtdMedia => Itens.Average(i => i.QtdReal);
        public decimal? PrecoMed => Itens.Average(i => i.Preco);
        public decimal? PrecoMax => Itens.Max(i => i.Preco);
        public decimal? PrecoMin => Itens.Min(i => i.Preco);

        public ProdutoImagem Imagem => new ProdutoImagem(ID);

        public EditControl EControl => new EditControl(ID, !Itens.Any());
    }

    public class ProdutoMetadata {
        // Name the field the same as EF named the property - "FirstName" for example.
        // Also, the type needs to match.  Basically just redeclare it.
        // Note that this is a field.  I think it can be a property too, but fields definitely should work.

        public int ID { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria é obrigatória")]
        public int CategoriaID { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Produto é obrigatório")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "{0} precisa ter entre {2} e {1} letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Unidade é obrigatório")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "{0} precisa ter entre {2} e {1} letras.")]
        public string Unidade { get; set; }

        [Display(Name = "Qtd Normal")]
        [Range(0.01, 50, ErrorMessage = "{0} deve ser um número entre {1} e {2}.")]
        public decimal? QtdNormal { get; set; }

        [Display(Name = "Marcas Boas")]
        [StringLength(100, ErrorMessage = "{0} deve ter no máximo {1} letras.")]
        public string MarcasSim { get; set; }

        [Display(Name = "Não Comprar")]
        [StringLength(100, ErrorMessage = "{0} deve ter no máximo {1} letras.")]
        public string MarcasNao { get; set; }

        [Display(Name = "Lista Padrão")]
        [UIHint("BoolSimNao")]
        public bool? ListaPadrao { get; set; }

        [Display(Name = "Qtd Média")]
        public decimal? QtdMedia => Itens.Average(i => i.QtdReal);

        [Display(Name = "Preço Médio")]
        [DataType(DataType.Currency)]
        public decimal? PrecoMed => Itens.Average(i => i.Preco);

        [Display(Name = "Preço Máx.")]
        [DataType(DataType.Currency)]
        public decimal? PrecoMax => Itens.Max(i => i.Preco);

        [Display(Name = "Preço Mín.")]
        [DataType(DataType.Currency)]
        public decimal? PrecoMin => Itens.Min(i => i.Preco);
        
        [Display(Name = "Categoria")]
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Item> Itens { get; set; }

        public ProdutoImagem Imagem { get; }
    }
}
